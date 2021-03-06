using IoC.TasksList.Interfaces;
using IoC.TasksList.Models;
using IoC.TasksList.Repository;
using IoC.TasksList.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace IoC.TasksList
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //"Elegant" mode to inject dependency
            DependecyResolve(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseBrowserLink();                
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc();
        }

        private void DependecyResolve(IServiceCollection services)
        {
            services.AddTransient<ITaskService, TaskService>();
            services.AddScoped<IRepository<TaskModel>, TaskRepository>();
            services.AddScoped<IDbConnection>(e =>
            {
                string connStr = this.Configuration.GetSection("Config:TaskDb:ConnectionString").Get<string>();
                return new SqlConnection(connStr);
            });
            services.AddSingleton<IConfiguration>(e =>
            {
                return this.Configuration;
            });
        }
    }
}