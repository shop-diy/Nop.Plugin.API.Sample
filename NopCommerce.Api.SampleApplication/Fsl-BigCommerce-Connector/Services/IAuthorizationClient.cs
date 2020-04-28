using Fsl.BigCommerce.Api.Connector.Models.Request;

namespace Fsl.BigCommerce.Api.Connector.Services
{
    public interface IAuthorizationClient
    {
        string GetAuthorizationData(AuthParameters authParameters);
        string GetAuthorizationUrl(string redirectUrl, string[] scope, string state = null);
        string RefreshToken(string refreshToken, string grantType);
        void ValidateParameter(AuthParameters authParameters);
    }
}
