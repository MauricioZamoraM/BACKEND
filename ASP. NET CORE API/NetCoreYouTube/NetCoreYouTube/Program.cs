using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",new OpenApiInfo { Title = "Sofware Lion", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Jwt Authorization",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "",
        Scheme = "Bearer"

    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
    {
        new OpenApiSecurityScheme
        {
            Reference= new OpenApiReference
            {
                Type=ReferenceType.SecurityScheme,
                Id="Bearer"
            },

        },
        new string[]{ }
    }});

    //var documentationFilePath = Path.Combine(System.AppContext.BaseDirectory, "InsAPIGeneric.API.xml");
    //c.IncludeXmlComments(documentationFilePath);

    //var documentationFilePath2 = Path.Combine(System.AppContext.BaseDirectory, "InsAPIGeneric.Models.xml");
    //c.IncludeXmlComments(documentationFilePath2);
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => 
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {    // Valida el emisor, donde se estan publicando las apis
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))

    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();    
app.UseAuthorization();

app.MapControllers();

app.Run();








//using InsAPIGenerics.Logic.Utils;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.IdentityModel.Tokens;
//using Microsoft.OpenApi.Models;
//using Newtonsoft.Json.Serialization;
//using System.Text;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Configuration
//        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
//builder.Services.AddControllers()
//    .AddNewtonsoftJson(options =>
//    {
//        options.SerializerSettings.ContractResolver = new DefaultContractResolver
//        {
//            NamingStrategy = new DefaultNamingStrategy()
//        };
//    });

//builder.Services.Configure<IISServerOptions>(options =>
//{
//    options.MaxRequestBodySize = int.MaxValue;
//});

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: "MyCors", builder =>
//    {
//        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
//    }
//   );
//}
//);

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API_DAVIVIENDA_SINPEMOVIL", Version = "v1" });
//    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        In = ParameterLocation.Header,
//        Description = "Jwt Authorization",
//        Name = "Authorization",
//        Type = SecuritySchemeType.ApiKey,
//        BearerFormat = "",
//        Scheme = "Bearer"

//    });
//    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
//    {
//        new OpenApiSecurityScheme
//        {
//            Reference= new OpenApiReference
//            {
//                Type=ReferenceType.SecurityScheme,
//                Id="Bearer"
//            },

//        },
//        new string[]{ }
//    }});

//    //var documentationFilePath = Path.Combine(System.AppContext.BaseDirectory, "InsAPIGeneric.API.xml");
//    //c.IncludeXmlComments(documentationFilePath);

//    //var documentationFilePath2 = Path.Combine(System.AppContext.BaseDirectory, "InsAPIGeneric.Models.xml");
//    //c.IncludeXmlComments(documentationFilePath2);
//});

//builder.Services.AddControllers().AddNewtonsoftJson();

////configure settings service
//builder.WebHost.ConfigureKestrel(serverOptions =>
//{
//    serverOptions.Limits.KeepAliveTimeout = TimeSpan.FromSeconds(Int32.Parse(General_Functions.Get_Configuration_Key("concurrencia:KeepAliveTimeoutSeg")));
//    serverOptions.Limits.MaxConcurrentConnections = Int32.Parse(General_Functions.Get_Configuration_Key("concurrencia:MaxConcurrentConnections"));
//    serverOptions.Limits.MaxConcurrentUpgradedConnections = Int32.Parse(General_Functions.Get_Configuration_Key("concurrencia:MaxConcurrentUpgradedConnections"));
//    serverOptions.Limits.Http2.MaxStreamsPerConnection = Int32.Parse(General_Functions.Get_Configuration_Key("concurrencia:MaxStreamsPerConnection"));
//    serverOptions.Limits.Http2.KeepAlivePingDelay = TimeSpan.FromSeconds(Int32.Parse(General_Functions.Get_Configuration_Key("concurrencia:KeepAlivePingDelaySeg")));
//    serverOptions.Limits.Http2.KeepAlivePingTimeout = TimeSpan.FromMinutes(Int32.Parse(General_Functions.Get_Configuration_Key("concurrencia:KeepAlivePingTimeoutMinute")));
//});

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
//    {    // Valida el emisor, donde se estan publicando las apis
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = builder.Configuration["Jwt:Issuer"],
//        ValidAudience = builder.Configuration["Jwt:Audience"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))

//    };
//});


//var app = builder.Build();

////if (app.Environment.IsDevelopment())
////{
////    app.UseSwagger();
////    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "dotnetClaimAuthorization v1"));
////}

//if (app.Environment.IsProduction())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

////configurar para que levante swagger al iniciar el servicio
//app.UseSwagger();
//app.UseSwaggerUI(c =>
//{
//    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API_DAVIVIENDA_SINPEMOVIL v1");
//    c.RoutePrefix = string.Empty;
//});


//// Configure the HTTP request pipeline.
//app.UseCors("MyCors");

//app.UseHttpsRedirection();
//app.UseAuthentication();
//app.UseAuthorization();


//app.Run();

