using Gunnsoft.Api.Models.Error;
using IdentityModel;

namespace Gunnsoft.Api.Models.UnknownSubject
{
    public class UnknownSubjectResponse : ErrorResponse
    {
        public UnknownSubjectResponse()
            : base
            (
                "UnknownSubject",
                $"The Subject must be specified using the '{JwtClaimTypes.Subject}' claim."
            )
        {
        }
    }
}