using Blazored.LocalStorage;
using Memoreyes;
using Memoreyes.Components;
using Microsoft.Extensions.FileProviders;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddHttpClient();
builder.Services.AddBlazoredLocalStorage();



var app = builder.Build();
app.UseStaticFiles(new StaticFileOptions {
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, builder.Environment.EnvironmentName, "unsafe_uploads")),
    RequestPath = "/unsafe_uploads"
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
