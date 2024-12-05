using Emp_Dapper_Useing_3databases;
using Emp_Dapper_Useing_3databases.Interface;
using Emp_Dapper_Useing_3databases.Repository;
using Emp_Dapper_Useing_3databases.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IDepartmentRepository, DepartementRepository>();
builder.Services.AddScoped<IDepartementService, DepartementService>();
builder.Services.AddScoped<IEmpConnectionFactory, EmpConnectionFactory>();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<IOrdersService, OrdersService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
