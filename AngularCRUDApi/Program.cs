using AngularCRUDApi.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add Cors
builder.Services.AddCors(p => p.AddPolicy("angularcorsapp", builder => {
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));
// Add Sql DbContext class
builder.Services.AddDbContext<SqlDatabaseContext>(
    options => 
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlDatabaseContext"));
    }    
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
// app cors
app.UseCors("angularcorsapp");

app.UseAuthorization();

app.MapControllers();

app.Run();
