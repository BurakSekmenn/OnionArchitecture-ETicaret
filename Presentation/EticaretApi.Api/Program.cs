


using EticaretApi.Persistence;
using EticaretApi.Application;

using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPersistanceServices();
builder.Services.AddApplicationServices();

//builder.Services.AddAddInfrastructureService();
builder.Services.AddCors(options=>options.AddDefaultPolicy(policy=>
    policy.WithOrigins("http://localhost:3000", "https://localhost:3000").AllowAnyHeader()
));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin",options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateAudience = true, // Oluþturulacak token deðerini kimler/hangi originlerin sitelern kullanýcýný berlilerdiðimiz deðerdir. örnek : www.bilmemne.com
            ValidateIssuer = true, // Oluþturlaacak token kimin daðýtýný ifade edeceðimiz alandýr. örnek : www.mypapi.com
            ValidateLifetime = true, // Tokenin ne kadar süreyle geçerli olacaðýný belirleyen alan
            ValidateIssuerSigningKey = true, // Tokenin hangi key ile imzalandýðýný belirleyen alan. Üretilecek token deðerinin uygulamamýza ait bir deðer olduðunu ifade eden security key verisini doðrulanmasýdýr.



            ValidAudience = builder.Configuration["Token:Audience"], 
            ValidIssuer = builder.Configuration["Token:Issuer"], 
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
        };// Gelen tokenda gelen keylere bakacak iþlemleri yapacak
    }
    );


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();


app.UseAuthorization();

app.MapControllers();

app.Run();
