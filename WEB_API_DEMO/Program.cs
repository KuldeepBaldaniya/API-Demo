using Microsoft.EntityFrameworkCore;
using WEB_API_DEMO.Data;
using WEB_API_DEMO.Ripository.Ripository;
using WEB_API_DEMO.Service.EmployeeService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddCors(x =>
{
    x.AddPolicy("Policy", builder => builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader());
});

builder.Services.AddDbContext<EmployeeAPIDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefoultConnection")
));

var app = builder.Build();

app.UseCors("Policy");
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
