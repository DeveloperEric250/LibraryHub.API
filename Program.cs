var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "WElcome to LibraryHubd");
app.MapGet("api/status", () => new {name = "LibraryHub", status ="open"});

app.Run();