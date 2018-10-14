using Gunnsoft.Api.Models.Error;

namespace Gunnsoft.Api.Models.AuthenticatedUserNotFound
{
    public class AuthenticatedUserNotFoundResponse : ErrorResponse
    {
        public AuthenticatedUserNotFoundResponse()
            : base
            (
                "AuthenticatedUserNotFound",
                "The authenticted member cannot be found."
            )
        {
        }
    }
}