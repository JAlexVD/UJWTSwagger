//0. Usings para trabajar con EntityFramework
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using myFirstBackend;
using myFirstBackend.DataAcces;
using myFirstBackend.Services;

var builder = WebApplication.CreateBuilder(args);

/*1. Conexion con la Base de Datos
 *2.Dependencias:
 *  -Microsoft.EntityFrameworkCore.SqlServer
 *  -Microsoft.EntityFrameworkCore.Tools, ejecutar desde terminal
 *  -Microsoft.VisualStudio.Web.CodeGeneration.Design, trae plantillas crud
 *  -Microsoft.VisualStudio.Web.CodeGeneration.Core,
 *  --Extension EF Core Power Tools, permite hacer un diagrama del DBContext
 *  ------AGREGAR DEPENDENCIAS PARA TRABAJAR CON JWT JSON WEB TOKEN
 *  ---System.IdentityModel.Tokens.Jwt
 *  ---Microsoft.AspNetCore.Authentication.JwtBearer
 *  ---Microsoft.IdentityModel.JsonWebTokens
 * */
//3.Conexxion con SQL Server
const string name = "DefaultConnection";

var connectionString=builder.Configuration.GetConnectionString(name);

//4. Añadir contexto-Usind Dta acces
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));


//8 Añadir servicio de JWT autorizacion
builder.Services.AddJwtTokenServices(builder.Configuration);


// Add services to the container.

builder.Services.AddControllers();

//5. AÑADIR LOS SERVICIOS - para inyectar servicops en los contrladores
builder.Services.AddScoped<IStudentService, StudentService>();




//9. Añadir autorizacion a nuestro proyecto
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserOnlyPolicy", policy => policy.RequireClaim("UserOnly", "User1"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//10. Indicar a Swagger que estamos haciendo uso de aurorizacion JWT
builder.Services.AddSwaggerGen( options =>
    {
        //Definimos la seguridad para la autorización
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type= SecuritySchemeType.Http,
            Scheme= "Bearer",
            BearerFormat="JWT",
            In=ParameterLocation.Header,//Donde va a ir el Bearer token => en la cabecera
            Description="JWT Authorization Heder Using Bearer Scheme"
        });

        //Otras opciones
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference= new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },

                new string[]{}
            }
            
        });

    }  
);

//6. HABILITAR EL CORS COFIGURATION
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin();//cualquier origen peticiones cconsultas
        builder.AllowAnyMethod();//post get cualquier metodo
        builder.AllowAnyHeader();//mandar cualquier cabecera

    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//7.DECIR A NUESTRA APP QUE HAGA USO DE CORS
app.UseCors("CorsPolicy");

app.Run();
