using FitemaAPI.Database;
using FitemaAPI.Helpers;
using FitemaAPI.Repository.Contracts;
using FitemaAPI.Repository.Impl;
using FitemaAPI.Services.Contracts;
using FitemaAPI.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
services.AddCors();
services.AddControllers();

// configure strongly typed settings object
services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

services.AddTransient<IDatabaseConnectionFactory, DatabaseConnectionFactory>();

services.AddScoped<IBillRepository, BillRepository>();
services.AddScoped<ICustomerRepository, CustomerRepository>();
services.AddScoped<IFitemaDataRepository, FitemaDataRepository>();
services.AddScoped<IOrganizationRepository, OrganizationRepository>();
services.AddScoped<IOrgOptionRepository, OrgOptionRepository>();
services.AddScoped<IPlanRepository, PlanRepository>();
services.AddScoped<IProductRepository, ProductRepository>();
services.AddScoped<ISystemLogRepository, SystemLogRepository>();
services.AddScoped<ITransactionRepository, TransactionRepository>();
services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IVoucherRepository, VoucherRepository>();

services.AddScoped<IAuthService, AuthService>();
services.AddScoped<IBillService, BillService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// global cors policy
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// custom jwt auth middleware
app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
