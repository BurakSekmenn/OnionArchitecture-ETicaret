


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
            ValidateAudience = true, // Olu�turulacak token de�erini kimler/hangi originlerin sitelern kullan�c�n� berlilerdi�imiz de�erdir. �rnek : www.bilmemne.com
            ValidateIssuer = true, // Olu�turlaacak token kimin da��t�n� ifade edece�imiz aland�r. �rnek : www.mypapi.com
            ValidateLifetime = true, // Tokenin ne kadar s�reyle ge�erli olaca��n� belirleyen alan
            ValidateIssuerSigningKey = true, // Tokenin hangi key ile imzaland���n� belirleyen alan. �retilecek token de�erinin uygulamam�za ait bir de�er oldu�unu ifade eden security key verisini do�rulanmas�d�r.



            ValidAudience = builder.Configuration["Token:Audience"], 
            ValidIssuer = builder.Configuration["Token:Issuer"], 
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
        };// Gelen tokenda gelen keylere bakacak i�lemleri yapacak
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
