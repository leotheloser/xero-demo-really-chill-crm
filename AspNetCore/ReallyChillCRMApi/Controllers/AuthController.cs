using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using ReallyChillCRMApi.Helpers;
using Xero.Api;
using Xero.Api.Core.Model;
using Xero.Api.Infrastructure.OAuth;
using Xero.Api.Infrastructure.Exceptions;
using IMvcAuthenticator = ReallyChillCRMApi.Authenticators.IMvcAuthenticator;

namespace ReallyChillCRMApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private readonly IMvcAuthenticator _authenticator;
        private readonly ApiUser _user;

        public AuthController(IOptions<XeroApiSettings> settings)
        {
            _user = XeroApiHelper.User();

            _authenticator = XeroApiHelper.MvcAuthenticator(settings.Value);
        }
        // GET: api/Auth
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var authorizeUrl = await _authenticator.GetRequestTokenAuthorizeUrlAsync(_user.Identifier);

            return Redirect(authorizeUrl);
        }

        // GET: api/Auth/Callback
        [HttpGet("Callback")]
        public async Task<ActionResult> CallBack([FromQuery]string oauth_token, string oauth_verifier, string org)
        {
            var accessToken = await _authenticator.RetrieveAndStoreAccessTokenAsync(_user.Identifier, oauth_token, oauth_verifier);
            if (accessToken == null)
                return Redirect("http://localhost:8080/integration?status=failed");

            return Redirect("http://localhost:8080/integration?status=success");
        }

        // GET: api/Auth/Check
        [HttpGet("Check")]
        public async Task<ActionResult<Organisation>> Check()
        {
            var api = XeroApiHelper.CoreApi();
            try
            {
                var organisation = await api.FindOrganisationAsync();

                return organisation;
            }
            catch (NotSupportedException e)
            {
                return BadRequest(e);
            }
        }

        // GET: api/Auth/Disconnect
        [HttpGet("Disconnect")]
        public async Task<ActionResult> Disconnect()
        {
            await _authenticator.DestroyAccessTokenAsync(_user.Identifier);

            return Redirect("http://localhost:8080/integration?status=disconnected");
        }
    }
}
