namespace Movies.Api.Auth;

public static class AuthConstants
{
    public const string UserRoleClaimName = "role";
    public const string UserIdClaimName = "sub";

    public const string AdminUserPolicyName = "AdminPolicy";
    public const string AdminUserClaimValue = "Admin";
}
