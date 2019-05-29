using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Con1
{
    public class Startup
    {
        #region Methods

        public void Configure(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment)
        {
            applicationBuilder.UseSwagger();

            applicationBuilder.UseSwaggerUI(sw =>
            {
                sw.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            applicationBuilder.UseMvc(route =>
            {
                route.MapRoute("default", "{controller}/{action}");
            });
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMvcCore().AddApiExplorer();
            serviceCollection.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        #endregion
    }
}
