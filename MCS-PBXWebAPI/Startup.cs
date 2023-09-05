using MCSDataLayer;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Extensions;
//using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
//using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;

using Microsoft.OpenApi.Models;
using MCS_PBXWebAPI.Common;

public class Startup
{
    readonly string MyAllowSpecificOrigins = "MCSAllowSpecificOrigins";
    public IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
        SqlHelper.strConnectionString = Configuration.GetSection("ConnectionStrings:DefaultConection").Value;
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(MyAllowSpecificOrigins,
                policy =>
                {
                    policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
        });
        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddControllersWithViews();
        services.Configure<CookiePolicyOptions>(options =>
        {
            options.HttpOnly = HttpOnlyPolicy.Always;
            options.Secure = CookieSecurePolicy.Always;
        });
        //services.AddDefaultIdentity<ApplicationUser>();
        //services.AddIdentity<IdentityUser, IdentityRole>(o =>
        //{
        //    o.Password.RequiredLength = 8;
        //})
        //.AddRoles<IdentityRole>()
        //.AddRoleManager<RoleManager<IdentityRole>>()
        //.AddDefaultTokenProviders();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = Configuration["Jwt:Issuer"],
                ValidAudience = Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true
            };
        });
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        // 5. Swagger authentication
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Wedding Planner API", Version = "v1" });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,

            },
            new List<string>()
        }
    });
        });

        // 6. Add CORS policy
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAngularDevClient",
                b =>
                {
                    b
                        .WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });


        Log.Logger.Information("testing");


    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }
        app.UseMiddleware<ErrorHandler>();
        app.UseCookiePolicy();
        app.UseStaticFiles();
        app.UseAuthentication();
        

        //app.UseOpenIdConnectAuthentication(new OpenIdConnectOptions
        //{
        //    ClientId = Configuration["ClientId"],
        //    ClientSecret = Configuration["ClientSecret"],
        //    Authority = Configuration["Authority"],
        //    ResponseType = OpenIdConnectResponseType.Code,
        //    GetClaimsFromUserInfoEndpoint = true
        //});
        app.UseRouting();
        app.UseCors("AllowAngularDevClient");
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
            pattern: "{controller}/{action=Index}/{id?}");
        });


    }
}