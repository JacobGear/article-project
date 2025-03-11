using ArticleBackend.Interfaces;
using Microsoft.EntityFrameworkCore;
using ArticleBackend.Data;
using ArticleBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add Entity Framework and connect to SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
   options.AddPolicy("AllowReactApp",
       policy => policy.WithOrigins("http://localhost:3000") // Change this if your frontend is hosted elsewhere
                       .AllowAnyMethod()
                       .AllowAnyHeader());
});

builder.Services.AddScoped<IArticleService, DbArticleService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}

app.UseCors("AllowReactApp");
app.UseHttpsRedirection();
app.MapControllers();
app.Run();