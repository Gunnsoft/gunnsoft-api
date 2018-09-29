using System;

namespace Gunnsoft.Api.Exceptions.AuthenticatedUserNotFound.Version1
{
    public class AuthenticatedUserNotFoundException : Exception
    {
        public AuthenticatedUserNotFoundException
        (
            string subject
        )
            : base
            (
                $"Authenticated user not found. Subject='{subject}'"
            )
        {
            Subject = subject;
        }

        public string Subject { get; }
    }
}