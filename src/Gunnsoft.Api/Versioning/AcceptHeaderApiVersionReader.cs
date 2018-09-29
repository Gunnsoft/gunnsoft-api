using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace Gunnsoft.Api.Versioning
{
    public class AcceptHeaderApiVersionReader : IApiVersionReader
    {
        private readonly Regex _versionRegex;

        public AcceptHeaderApiVersionReader
        (
            string apiName
        )
        {
            _versionRegex = new Regex($@"^application\/vnd\.{apiName}.v(\d+)\+json$");
        }

        public void AddParameters
        (
            IApiVersionParameterDescriptionContext context
        )
        {
        }

        public string Read
        (
            HttpRequest request
        )
        {
            var acceptHeader = request.Headers.ContainsKey("Accept")
                ? request.Headers["Accept"].First()
                : "";
            var match = _versionRegex.Match(acceptHeader);

            if (!match.Success)
            {
                return null;
            }

            return !int.TryParse(match.Groups[1].Value, out var version) ? null : version.ToString();
        }
    }
}