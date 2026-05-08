using Cadastro.Infrastructure.Data.Common;
using Cadastro.Infrastructure.ExtensionMethods;
using Cadastro.Infrastructure.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddRepositories().AddServices();

builder.Services.AddAutoMapper(typeof(AutoMapping));

builder.Services.AddDbContext<RegisterContext>(options =>
    options.UseInMemoryDatabase("Register"));

builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<RegisterContext>();
    if (!context.Categories.Any())
    {
        context.Categories.AddRange(
            new Cadastro.Domain.Entities.Category { Id = 1, Name = "Eletrônicos" },
            new Cadastro.Domain.Entities.Category { Id = 2, Name = "Informática" },
            new Cadastro.Domain.Entities.Category { Id = 3, Name = "Serviços" }
        );
        context.SaveChanges();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
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
