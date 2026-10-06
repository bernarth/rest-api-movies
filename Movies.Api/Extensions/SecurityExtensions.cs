using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Movies.Api.Auth;

namespace Movies.Api.Extensions;

public static class SecurityExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddMoviesAuthentication(ConfigurationManager config)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.MapInboundClaims = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(
                        System.Text.Encoding.UTF8.GetBytes(config["Jwt:Key"]!)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = config["Jwt:Issuer"],
                    ValidAudience = config["Jwt:Audience"],
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    RoleClaimType = AuthConstants.UserRoleClaimName,
                    ValidAlgorithms = [SecurityAlgorithms.HmacSha256],
                };
            });

            return services;
        }

        public IServiceCollection AddMoviesAuthorization()
        {
            services
                .AddAuthorizationBuilder()
                .AddPolicy(AuthConstants.AdminUserPolicyName, p => p.RequireRole(AuthConstants.AdminUserClaimValue));

            return services;
        }
    }
}
