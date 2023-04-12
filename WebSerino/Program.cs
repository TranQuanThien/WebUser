using BusinessLogic.Business;
using BusinessLogic.IService;
using DataRepository.Data;
using DataRepository.IServiceRepo;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using MudBlazor.Services;
using WebSerino.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthenticationCore();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddSingleton<UserAccountService>();

builder.Services.AddMudServices();
builder.Services.AddMudBlazorDialog();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ISerinoRepoService, SerinoRepoService>();
builder.Services.AddScoped<IActivationLogic, ActivationLogic>();
builder.Services.AddScoped<IUserRepository, UserRepoService>();
builder.Services.AddScoped<IUserLogic, UserLogic>();

//builder.Services.AddBlazoredToast();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<DataContext>();
// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
