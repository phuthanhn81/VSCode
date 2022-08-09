using DATA;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<CodeFirstDbContext>(options => options
                .UseMySql("server=localhost;port=3310;database=Shopee;user=phuthanh;password=1")
            );

            services.AddTransient<Program>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) { }
    }
}