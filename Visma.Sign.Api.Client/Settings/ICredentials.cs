namespace Visma.Sign.Api.Client.Settings
{
    public interface ICredentials
    {
        string Secret();
        string Identifier();
    }
}
