using Contact_Application.Models;
using Contact_Application.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Formatters.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contact_Application.Repository;
using Contact_Application.Repositories.Interfaces;
using Contact_Application.Repository.Interfaces;
using Contact_Application.Services;


namespace Contact_Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //dodano zbog camelCase u json objektu
            services.AddMvc()
                    .AddNewtonsoftJson(options =>
                    {
                        options.UseMemberCasing();
                    });

            services.AddControllersWithViews();           
            services.AddControllers();           
            //dodano zbog testiranja s postmanom
            services.AddCors();


            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

            });

            services.AddRazorPages();
            services.AddRazorPages().AddRazorRuntimeCompilation();

            //Mapper 
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ProfileMapper());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            //DI services
            services.AddSingleton(mapper);

            services.AddScoped<IContactRepositoryAsync, ContactRepository>();
            services.AddScoped<ITagRepositoryAsync, TagRepository>();
            services.AddScoped<IService, Service>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod()
                       .AllowAnyHeader());
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //dodano za pokretanje baze pri startu
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
                context.Database.Migrate();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();
         
            app.UseRouting();
            app.UseCors(builder => builder.WithOrigins("*")
         .AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}