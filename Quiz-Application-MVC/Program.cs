using Microsoft.EntityFrameworkCore;
using Quiz.DB;
using Quiz.Facade.Facades;
using Quiz.Logic;
using Quiz.Services;
using Quiz.Services.ModelPreparatorService;
using Quiz.Services.ResultCalculatorService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<QuizDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<RepositoryFactory>();
builder.Services.AddScoped<FacadeFactory>();
builder.Services.AddScoped<IQuizViewModelPreparator, QuizViewModelPreparator>();
builder.Services.AddScoped<IResultCalculatorService, ResultCalculatorService>();
builder.Services.AddSingleton<TempDataStorage>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Main/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Main}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
