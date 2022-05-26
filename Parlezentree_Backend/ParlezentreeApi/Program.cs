using Microsoft.EntityFrameworkCore;
using ParlezentreeDl;

var builder = WebApplication.CreateBuilder(args);


var userPolicy = "allowedOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: userPolicy,
            policy =>
            {
                policy.WithOrigins("http://127.0.0.1:5500").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
            });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ParlezentreeDl.Entities.parlez_entreeContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ParlezEntreeDb")));
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();


if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(userPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();

