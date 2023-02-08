using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using myFirstBackend.Modelos.DataModels;

namespace myFirstBackend
{
    //añadir los setings para usarlo en nuestro programa
    public static class AddJwtTokenServicesExtensions
    {
        public static void AddJwtTokenServices(this IServiceCollection Services, IConfiguration Configuration)
        {
            //Añadir los settings de nuestro JWT
            var bindJwtSettings = new JWTSettings();

            //Clave en nuestro settings-todas las propiedades de JsonWebTokenKyes estar en la clase JWTSettings
            Configuration.Bind("JsonWebTokenKyes", bindJwtSettings);

            //añadir a nuestro services para tenerlas accesibles
            Services.AddSingleton(bindJwtSettings);

            //añadir autencitacion luego el JWTBearer
            Services.AddAuthentication(options=>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;//autenticar usuarios
                options.DefaultChallengeScheme= JwtBearerDefaults.AuthenticationScheme;//comprobar los usuarios

            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata= false;
                options.SaveToken = true;//si queremos guardar o no el token
                options.TokenValidationParameters = new TokenValidationParameters()//parametros de validacion de nuetsro token
                {
                    ValidateIssuerSigningKey = bindJwtSettings.ValidateIssuerSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(bindJwtSettings.IssuerSigningKey)),
                    ValidateIssuer=bindJwtSettings.ValidateIssuer,
                    ValidIssuer=bindJwtSettings.ValidIssuer,
                    ValidateAudience=bindJwtSettings.ValidateAudience,
                    ValidAudience=bindJwtSettings.ValidAudience,
                    RequireExpirationTime=bindJwtSettings.RequireExpirationTime,
                    ValidateLifetime=bindJwtSettings.ValidateLifeTime,
                    ClockSkew=TimeSpan.FromDays(1)
                };
            });

        }
    }
}
