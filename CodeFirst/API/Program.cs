using System;
using System.Linq;
using DATA;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API
{
    class Program
    {
        private readonly CodeFirstDbContext _context;

        public Program(CodeFirstDbContext context)
        {
            _context = context;
        }

        static IHostBuilder CreateHostBuilder(string[] args)
        => Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(
                webBuilder => webBuilder.UseStartup<Startup>());

        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            host.Services.GetRequiredService<Program>().Run();
        }

        void Run()
        {
            var product = _context.Products.Include(n => n.Category)
                                           .FirstOrDefault(n => n.ID == 1);
            Console.WriteLine(product.Name);
            Console.WriteLine(product.Category.Name);
        }
    }
}
