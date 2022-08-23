using Microsoft.EntityFrameworkCore;
using CountryApi.Modals;
var builder = WebApplication.CreateBuilder(args);
var MyCors = "MyCors";

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<CountryContext>(opt =>opt.UseInMemoryDatabase("countrylist"));

builder.Services.AddSwaggerGen();
builder.Services.AddCors(p => p.AddPolicy(name: MyCors, build =>
{
    build.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
}));


var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyCors);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
