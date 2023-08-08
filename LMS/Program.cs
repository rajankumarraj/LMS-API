using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LMS.DATA;
using LMS.DATA.Model;
using AutoMapper;
using LMS.SERVICES.Intefaces;
using LMS.SERVICES.Services;
using LMS.REPOSITORIES.Interfaces;
using LMS.REPOSITORIES.Repositories;
using LMS.API.CommonHelper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LMSDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LMSConnection")));
builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
   .AddRoles<IdentityRole>()
   .AddEntityFrameworkStores<LMSDbContext>()
   .AddEntityFrameworkStores<LMSDbContext>()
   .AddDefaultTokenProviders()
   .AddTokenProvider<EmailConfirmationTokenProvider<ApplicationUser>>("emailconfirmation"); 

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
     .AddEntityFrameworkStores<LMSDbContext>();
builder.Services.Configure<IdentityOptions>(opts =>
{
    opts.Password.RequiredLength = 8;
    opts.Password.RequireNonAlphanumeric = true;
    opts.Password.RequireLowercase = false;
    opts.Password.RequireUppercase = true;
    opts.Password.RequireDigit = true;
});

var config = new MapperConfiguration(cfg =>
{
    cfg.AddMaps("LMS.MODELS");
});
IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
builder.Services.AddTransient<ICompanyService, CompanyService>();
builder.Services.AddTransient <IEmailRepository, EmailRepository>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient <IUserRepository, UserRepository>();
builder.Services.AddTransient <IUserService, UserService>();

//Set Email Token Expiration for 7 days 
builder.Services.Configure<EmailConfirmationTokenProviderOptions>(opt =>
     opt.TokenLifespan = TimeSpan.FromMinutes(Convert.ToDouble(10080)));
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
