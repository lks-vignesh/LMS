using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection.Extensions;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddNotyf(config => { config.DurationInSeconds = 5; config.IsDismissable = true; config.Position = NotyfPosition.TopRight; });

builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    //app.UseExceptionHandler(exceptionHandlerApp =>
    //{
    //    exceptionHandlerApp.Run(async context =>
    //    {
    //        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

    //        // using static System.Net.Mime.MediaTypeNames;
    //        context.Response.ContentType = Text.Plain;

    //        await context.Response.WriteAsync("An exception was thrown.");

    //        var exceptionHandlerPathFeature =
    //            context.Features.Get<IExceptionHandlerPathFeature>();

    //        if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
    //        {
    //            await context.Response.WriteAsync(" The file was not found.");
    //        }

    //        if (exceptionHandlerPathFeature?.Path == "/")
    //        {
    //            await context.Response.WriteAsync(" Page: Home.");
    //        }
    //    });
    //});

    //app.UseExceptionHandler("/Home/Error");
    //The default HSTS value is 30 days.You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseSession();
app.UseNotyf();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=LogIn}/{id?}");

app.Run();
