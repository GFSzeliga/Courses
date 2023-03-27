using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using TutorialsTeacher_ASPNETCORE.Config;
using TutorialsTeacher_ASPNETCORE.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.Configure<MyCustomKey>(builder.Configuration.GetSection("MyCustomKey"));

/*builder.Services.AddLogging(loggingBuilder => {
    var loggingSection = builder.Configuration.GetSection("Logging");
    loggingBuilder.AddFile(loggingSection);
    loggingBuilder.AddConsole();
});*/
/*builder.Host.ConfigureLogging(configure =>
{
    configure.ClearProviders();
    configure.AddConsole();
    configure.AddTraceSource("Information, ActivityTracing");
});*/
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    //app.UseDeveloperExceptionPage();
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

/*DefaultFilesOptions options = new DefaultFilesOptions();
options.DefaultFileNames.Clear();
options.DefaultFileNames.Add("htmlpage.html");


app.UseDefaultFiles(options);*/

app.UseStaticFiles();

/*app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), @"Images")),
    RequestPath = new PathString("/app-images")
}
);*/

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

/*app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/processname", async context =>
    {
        await context.Response.WriteAsync("Worker Process Name : " +
            System.Diagnostics.Process.GetCurrentProcess().ProcessName);
    });
    endpoints.MapGet("/processnames", async context =>
    {
        await context.Response.WriteAsync("Worker Process Name : " +
            System.Diagnostics.Process.GetCurrentProcess().ProcessName);
    });
});*/
/*app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Hello World From 1st Middleware!");

    await next();
});

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Hello World From 2st Middleware!");

    await next();
});


*/

//app.UseCustomMiddleware();
//app.UseWelcomePage();

//app.Run(context => { throw new Exception("asd"); });
app.Run();
