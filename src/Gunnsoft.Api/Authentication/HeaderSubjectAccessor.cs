using System;
using Microsoft.AspNetCore.Http;

namespace Gunnsoft.Api.Authentication
{
    public class HeaderSubjectAccessor : ISubjectAccessor
    {
        private readonly Lazy<string> _subject;

        public HeaderSubjectAccessor
        (
            IHttpContextAccessor httpContextAccessor
        )
        {
            _subject = new Lazy<string>(() => httpContextAccessor.HttpContext.Request.Headers["X-Subject"]);
        }

        public string Subject => _subject.Value;
    }
}