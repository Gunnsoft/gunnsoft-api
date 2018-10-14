using Gunnsoft.Api.Models.Error;
using IdentityModel;

namespace Gunnsoft.Api.Models.UnknownClientId
{
    public class UnknownClientIdResponse : ErrorResponse
    {
        public UnknownClientIdResponse()
            : base
            (
                "UnknownClientId",
                $"The Client ID must be specified using the '{JwtClaimTypes.ClientId}' claim."
            )
        {
        }
    }
}