namespace ReallyChillCRMApi.Models
{
  public class RCContact
  {
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string SkypeUserName { get; set; }
    public bool IsSyncedWithXero { get; set; }
    public string XeroContactId { get; set; }
  }
}