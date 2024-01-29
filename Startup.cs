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

namespace Mantenedor
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
        }

        // Configuración del pipeline de solicitud HTTP
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configuración específica para el entorno de desarrollo
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); 
            } 
            else
            {
                // Configuración para manejar excepciones en producción
                app.UseExceptionHandler("/Home/Error"); 
                app.UseHsts(); 
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
                endpoints.MapControllerRoute(
                    name: "default", 
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
