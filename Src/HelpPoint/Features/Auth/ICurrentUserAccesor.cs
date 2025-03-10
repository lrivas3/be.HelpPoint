namespace HelpPoint.Features.Auth;

public interface ICurrentUserAccessor
{
    public string GetCurrentUsername();
    public string GetCurrentRole();
}
