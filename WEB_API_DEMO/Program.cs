using Microsoft.EntityFrameworkCore;
using API_DEMO.Data;
using API_DEMO.Ripository.Ripository;
using API_DEMO.Service.EmployeeService;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API DEMO", Version = "v1" });
    //c.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "APIDEMO.xml"));
});

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
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API DEMO V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
