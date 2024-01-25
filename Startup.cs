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

namespace Mantenedor
{
    public class Startup{
        public Startup(IConfiguration configuration){
            Configuration = configuration;
        }

        public IConfiguration Configuration {get;}

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MantenedorContext>(opt => opt.UseSqlServer
            (Configuration.GetConnectionString("MantenedorConnection")));

            services.AddControllers(); 

            services.AddScoped<IMantenedorRepo,MockMantenedorRepo>();
            
        }
    }
}