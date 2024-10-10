using Autofac.Extensions.DependencyInjection;
using Autofac;
//using DesignComplexityAPI.APIUtility.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Autofac.Core;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlClient;
//using DesignComplexityAPI.Domain.Global;
using Newtonsoft.Json.Linq;
//using DesignComplexityAPI.Persistence.Configuration;
using ProductOfferingSuiteAPI.Domain.Global;
using ProductOfferingSuiteAPI.APIUtility.Modules;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "ProductOfferingSuiteAPI", Description = "Product Offering Suite API" });

    // To Enable authorization using Swagger (JWT)    
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
         new OpenApiSecurityScheme
         {
         Reference = new OpenApiReference
         {
             Type = ReferenceType.SecurityScheme,
             Id = "Bearer"
         }
         },
        new string[] {}
        }
    });
});

var jwt = builder.Configuration.GetSection("JwtTokenConfig");
JwtTokenConfig jwtTokenConfig = jwt.Get<JwtTokenConfig>();
builder.Services.Configure<JwtTokenConfig>(jwt);
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuerSigningKey = jwtTokenConfig.ValidateIssuerSigningKey,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtTokenConfig.IssuerSigningKey)),
        ValidateIssuer = jwtTokenConfig.ValidateIssuer,
        ValidIssuer = jwtTokenConfig.ValidIssuer,
        ValidateAudience = jwtTokenConfig.ValidateAudience,
        ValidAudience = jwtTokenConfig.ValidAudience,
        RequireExpirationTime = jwtTokenConfig.RequireExpirationTime,
        ValidateLifetime = jwtTokenConfig.RequireExpirationTime,
        ClockSkew = TimeSpan.Zero

    };
    options.Events = new JwtBearerEvents
    {
        OnChallenge = async context =>
        {
            // Call this to skip the default logic and avoid using the default response
            context.HandleResponse();

            // Write to the response in any way you wish
            context.Response.StatusCode = 401;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(new TransactionDataModel<int>() { ReturnCode = -401, Message = "You are not authorized!" }));
        }
    };
});

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader()
           .WithExposedHeaders("Content-Disposition");
}));

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
IConfiguration comf = builder.Configuration;
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new ApplicationModuel(comf)));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseCors("MyPolicy");

// Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();
//app.MapControllerRoute(name:
//"POS"
//, pattern:
//"{controller=Home}/{action=Index}/{id?}"
//);
app.MapControllers();

app.Run();
