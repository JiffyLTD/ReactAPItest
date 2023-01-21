var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

app.UseCors(builder => builder.WithOrigins("https://localhost:3000").AllowAnyMethod().AllowAnyHeader().WithExposedHeaders("post-count"));

app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
});

app.Run();
