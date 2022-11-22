using Microsoft.EntityFrameworkCore;
using VideoStream.Data;
using VideoStream.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = builder.Configuration["DatabaseOptions:ConnectionStrings:SQL"];

builder.Services.AddDbContext<StorageDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<IVideoFileRepo, VideoFileRepo>();
builder.Services.AddScoped<IVideoManager , VideoManager >();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
