


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
            ValidateAudience = true, // Oluşturulacak token değerini kimler/hangi originlerin sitelern kullanıcını berlilerdiğimiz değerdir. örnek : www.bilmemne.com
            ValidateIssuer = true, // Oluşturlaacak token kimin dağıtını ifade edeceğimiz alandır. örnek : www.mypapi.com
            ValidateLifetime = true, // Tokenin ne kadar süreyle geçerli olacağını belirleyen alan
            ValidateIssuerSigningKey = true, // Tokenin hangi key ile imzalandığını belirleyen alan. Üretilecek token değerinin uygulamamıza ait bir değer olduğunu ifade eden security key verisini doğrulanmasıdır.



            ValidAudience = builder.Configuration["Token:Audience"], 
            ValidIssuer = builder.Configuration["Token:Issuer"], 
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
        };// Gelen tokenda gelen keylere bakacak işlemleri yapacak
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
