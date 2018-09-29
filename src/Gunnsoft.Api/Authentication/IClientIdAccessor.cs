namespace Gunnsoft.Api.Authentication
{
    // TODO Move to a shared library (Gunnsoft.Api)
    public interface IClientIdAccessor
    {
        string ClientId { get; }
    }
}
