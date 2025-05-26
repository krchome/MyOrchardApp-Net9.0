var builder = WebApplication.CreateBuilder(args);

// Add OrchardCore CMS services to the container.
builder.Services.AddOrchardCms();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Add OrchardCore to the request pipeline.
app.UseOrchardCore();

app.Run();