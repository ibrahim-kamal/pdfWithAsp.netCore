using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.FileProviders;

//context.LoadUnmanagedLibrary(Path.GetFullPath(@"C:\Users\User\source\repos\WebSolution\WebApp\libwkhtmltox.dll"));
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
builder.Services.AddRazorTemplating();
var app = builder.Build();
var env = app.Environment;

app.UseStaticFiles(new StaticFileOptions
{
       FileProvider = new PhysicalFileProvider(
        Path.Combine(env.ContentRootPath,"Exports")),
        RequestPath = "/Files"
});
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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}",
    defaults: new { controller = "Home", action = "Index" });
    endpoints.MapControllers();
});



app.UseAuthorization();

app.MapRazorPages();

app.Run();
