using Bookshop.Data;
using Bookshop.Services.Authors;
using Bookshop.Services.Books;
using Bookshop.Web.ModelBinderProviders;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
}
);
builder.Services.AddControllersWithViews(options =>
{
    options.ModelBinderProviders.Insert(0, new BooksPagesModelBinderProviders());
}
);
builder.Services.AddTransient<IAuthorsService, AuthorsService>();
builder.Services.AddTransient<IBooksService, BooksService>();
builder.Services.AddSingleton<IWebHostEnvironment>(builder.Environment);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
