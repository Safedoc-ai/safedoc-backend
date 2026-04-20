using Microsoft.EntityFrameworkCore;
using SafeDocAI.API.Data;
using SafeDocAI.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<StatusDocumentoService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontEnd", policy =>
    {
        policy.WithOrigins("http://127.0.0.1:5500", "http://localhost:5500")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Durante a mini integração local, pode deixar comentado.
// Se depois quiser usar HTTPS, reativa.
// app.UseHttpsRedirection();

app.UseCors("FrontEnd");

app.UseAuthorization();

app.MapControllers();

app.Run();