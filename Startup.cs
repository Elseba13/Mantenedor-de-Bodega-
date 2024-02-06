using System; 
using System.Collections.Generic;
using System.Linq; 
using System.Threading.Tasks;
using Mantenedor.Data;
using Microsoft.AspNetCore.Builder; 
using Microsoft.AspNetCore.Hosting; 
using Microsoft.AspNetCore.HttpsPolicy; 
using Microsoft.EntityFrameworkCore; 
using Microsoft.Extensions.Configuration; 
using Microsoft.Extensions.DependencyInjection; 
using Microsoft.Extensions.Hosting; 
using Microsoft.Extensions.Logging; 
using Newtonsoft.Json.Serialization;
using Microsoft.OpenApi.Models;

namespace Mantenedor.program
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Configuración de los servicios que se inyectarán en la aplicación
        public void ConfigureServices(IServiceCollection services)
        {
            // Configura el contexto de la base de datos utilizando SQL Server
            services.AddDbContext<MantenedorContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("MantenedorConnection")));

            // Configura los controladores y personaliza la serialización JSON utilizando CamelCase
            services.AddControllers().AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            // Configura AutoMapper para la asignación automática de objetos
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Configura la inyección de dependencias para el repositorio de Mantenedor
            services.AddScoped<IMantenedorRepo, SqlMantenedorRepo>();

            // Configura Swagger para documentar la API
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mantenedor API", Version = "v1" });
            }); 
            
        }

        // Configuración del pipeline de solicitud HTTP
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Habilita Swagger
            app.UseSwagger();

            // Configura Swagger UI
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mantenedor API v1");
            });
            
            
            // Configuración específica para el entorno de desarrollo
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); 
            } 

            // Redirección a HTTPS
            app.UseHttpsRedirection(); 
            
            // Habilita el uso de archivos estáticos (por ejemplo, HTML, CSS, imágenes)
            app.UseStaticFiles(); 

            app.UseRouting(); // Configuración del enrutamiento

            app.UseAuthorization(); // Configuración de la autorización

            // Configuración de los endpoints de la aplicación
            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllers();
            });
        }
    }
}
