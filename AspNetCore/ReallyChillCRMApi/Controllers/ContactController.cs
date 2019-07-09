using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReallyChillCRMApi.Models;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Status;
using Xero.Api.Core.Response;
using Xero.Api.Infrastructure.Exceptions;
using ReallyChillCRMApi.Helpers;

namespace ReallyChillCRMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ReallyChillCRMContext _context;


        public ContactController(ReallyChillCRMContext context)
        {
            _context = context;
        }

        // GET: api/Contact
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RCContact>>> GetContacts()
        {

            return await _context.RCContacts.ToListAsync();
        }

        // GET: api/Contact/1
        [HttpGet("{id}")]
        public async Task<ActionResult<RCContact>> GetContact(long id)
        {
            var RCContact = await _context.RCContacts.FindAsync(id);

            if (RCContact == null)
            {
                return NotFound();
            }

            return RCContact;
        }

        // POST: api/Contact
        [HttpPost]
        public async Task<ActionResult<RCContact>> PostContact(RCContact RCContact)
        {

            var api = XeroApiHelper.CoreApi();
            var xeroContact = new Contact();

            xeroContact.Name = RCContact.FirstName + " " + RCContact.LastName;
            xeroContact.FirstName = RCContact.FirstName;
            xeroContact.LastName = RCContact.LastName;
            xeroContact.EmailAddress = RCContact.Email;
            xeroContact.SkypeUserName = RCContact.SkypeUserName;

            try {
                var contactResponse = await api.Contacts.CreateAsync(xeroContact);
                RCContact.XeroContactId = contactResponse.Id.ToString();
                RCContact.IsSyncedWithXero = true;
            }
            catch (ValidationException e)
            {
                Console.WriteLine(e);
                RCContact.XeroContactId = null;
                RCContact.IsSyncedWithXero = false;
            }

            _context.RCContacts.Add(RCContact);
            await _context.SaveChangesAsync();

            _context.RCContacts.Update(RCContact);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContact), new { id = RCContact.Id }, RCContact);
        }


        // PUT: api/Contact/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(long id, RCContact RCContact)
        {  
            if (id != RCContact.Id) {
                return BadRequest();
            }

            var api = XeroApiHelper.CoreApi();
            var xeroContact = new Contact();

            if(RCContact.XeroContactId != null) {
                xeroContact.Name = RCContact.FirstName + " " + RCContact.LastName;
                xeroContact.FirstName = RCContact.FirstName;
                xeroContact.LastName = RCContact.LastName;
                xeroContact.EmailAddress = RCContact.Email;
                xeroContact.SkypeUserName = RCContact.SkypeUserName;
                xeroContact.Id = Guid.Parse(RCContact.XeroContactId);
                Console.WriteLine(xeroContact.Id.ToString());

                try {
                    var contactResponse = await api.Contacts.UpdateAsync(xeroContact);
                    Console.WriteLine(contactResponse.ToString());
                }
                catch (ValidationException e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            _context.Entry(RCContact).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Contact/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(long id)
        {
            var RCContact = await _context.RCContacts.FindAsync(id);

            if (RCContact == null)
            {
                return NotFound();
            }

            var api = XeroApiHelper.CoreApi();

            try {
                var xeroContact = await api.Contacts.FindAsync(Guid.Parse(RCContact.XeroContactId));
                xeroContact.ContactStatus = ContactStatus.Archived;
                try {
                   await api.Contacts.UpdateAsync(xeroContact);
                }
                catch (ValidationException e)
                {
                    Console.WriteLine(e);
                }
            }
            catch (ValidationException e)
            {
                Console.WriteLine(e);
            }

            _context.RCContacts.Remove(RCContact);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}