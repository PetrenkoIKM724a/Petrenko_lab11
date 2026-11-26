using lab11.Repositories;
using lab11.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Реєстрація HttpClient для репозиторію та самого сервісу
builder.Services.AddHttpClient<WeatherRepository>();
builder.Services.AddScoped<WeatherService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();