using backend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();


app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseCors(builder => builder.WithOrigins("https://localhost:3000").AllowAnyMethod().AllowAnyHeader().WithExposedHeaders("post-count"));

app.MapControllers();

app.Run();
