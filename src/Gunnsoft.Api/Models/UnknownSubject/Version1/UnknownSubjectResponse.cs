using Gunnsoft.Api.Models.Error.Version1;
using IdentityModel;

namespace Gunnsoft.Api.Models.UnknownSubject.Version1
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