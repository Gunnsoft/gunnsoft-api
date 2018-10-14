using Gunnsoft.Api.Models.Error;

namespace Gunnsoft.Api.Models.InsecureRequest
{
    public class InsecureRequestResponse : ErrorResponse
    {
        public InsecureRequestResponse()
            : base
            (
                "InsecureRequest",
                "Requests must be made using HTTPS."
            )
        {
        }
    }
}