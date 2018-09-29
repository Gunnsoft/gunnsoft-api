namespace Gunnsoft.Api.Authentication
{
    public interface ISubjectAccessor
    {
        string Subject { get; }
    }
}