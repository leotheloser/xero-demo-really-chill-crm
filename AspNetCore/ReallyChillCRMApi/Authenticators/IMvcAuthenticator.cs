using System.Threading.Tasks;
using Xero.Api.Infrastructure.Interfaces;

namespace ReallyChillCRMApi.Authenticators
{
  public interface IMvcAuthenticator
    {
        Task<string> GetRequestTokenAuthorizeUrlAsync(string userId);
        Task<IToken> RetrieveAndStoreAccessTokenAsync(string userId, string tokenKey, string verifier);
        Task DestroyAccessTokenAsync(string userId);
    }
}