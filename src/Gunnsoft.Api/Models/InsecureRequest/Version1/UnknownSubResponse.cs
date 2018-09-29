using Gunnsoft.Api.Models.Error.Version1;

namespace Gunnsoft.Api.Models.InsecureRequest.Version1
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