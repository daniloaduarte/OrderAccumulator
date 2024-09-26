using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace OrderAccumulator
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Adiciona o serviço CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularApp", builder =>
                {
                    builder.WithOrigins("http://localhost:4200") // Permitir a origem do Angular
                           .AllowAnyMethod() // Permitir qualquer método (GET, POST, etc.)
                           .AllowAnyHeader(); // Permitir qualquer cabeçalho
                });
            });

            services.AddControllers(); // Adicione este serviço se ainda não estiver presente
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Use o CORS antes de definir as rotas
            app.UseCors("AllowAngularApp");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Mapeia os controladores
            });
        }
    }
}
