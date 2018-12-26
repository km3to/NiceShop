using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NiceShop.AutoMapping;
using NiceShop.Data;
using NiceShop.Data.Models;
using NiceShop.Data.Repositories;
using NiceShop.Data.Repositories.Contracts;
using NiceShop.Data.Services.Administration;
using NiceShop.Data.Services.Administration.Contracts;
using NiceShop.Web.Areas.Administration.Models.BindingModels;
using NiceShop.Web.Areas.Administration.Models.ViewModels;

namespace NiceShop.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AutoMapperConfig.RegisterMappings(typeof(DetailsShopViewModel).Assembly);

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<NiceShopDbContext>(options =>
                options.UseSqlServer(
                    this.Configuration.GetConnectionString("DefaultConnection")));

            // TODO: Change to AddIdentity<User, Role>
            // TODO: Possible problem with new PasswordOptions
            services.AddDefaultIdentity<AppUser>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 3;
                    options.Password.RequiredUniqueChars = 1;
                })
                .AddEntityFrameworkStores<NiceShopDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            AutoMapperConfig.RegisterMappings(typeof(DetailsShopViewModel).Assembly);
            services.AddAutoMapper(config =>
            {
                config.CreateMap<CreateShopBindingModel, Shop>();
                config.CreateMap<CreateProductBindingModel, Product>();
                config.CreateMap<Category, SelectListItem>()
                    .ForMember(x => x.Value, x => x.MapFrom(y => y.Id))
                    .ForMember(x => x.Text, x => x.MapFrom(y => y.Name));
                config.CreateMap<Shop, SelectListItem>()
                    .ForMember(x => x.Value, x => x.MapFrom(y => y.Id))
                    .ForMember(x => x.Text, x => x.MapFrom(y => y.Name));
            });

            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<ProductsService>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<ISubLayoutService, SubLayoutService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // TODO: Bring it back
            //app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "administration",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
