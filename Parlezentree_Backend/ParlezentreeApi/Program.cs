using Microsoft.EntityFrameworkCore;
using ParlezentreeDl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var pokemonPolicy = "allowedOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: pokemonPolicy,
            policy =>
            {
                policy.WithOrigins("http://127.0.0.1:5500").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
            });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ParlezentreeDl.Entities.parlez_entreeContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ParlezEntreeDb")));
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(pokemonPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();

