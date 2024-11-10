using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Server;

public static class DependencyInjection
{
    public static IServiceCollection AddKeycloakService(this IServiceCollection services)
    {
        // Configuración de Keycloak
        services.AddAuthentication(configureOptions: options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Authority = "https://<tu-keycloak-server>/auth/realms/<tu-realm>";
                options.RequireHttpsMetadata = true;
                options.Audience = "<tu-client-id>";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String("<tu-client-secret>")),
                    ValidateIssuer = true,
                    ValidIssuer = "https://<tu-keycloak-server>/auth/realms/<tu-realm>",
                    ValidateAudience = true,
                    ValidAudience = "<tu-client-id>"
                };
            });

        services.AddAuthorization();

        return services;
    }
}