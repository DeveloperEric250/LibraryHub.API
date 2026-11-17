using System.Diagnostics.Eventing.Reader;
using LibraryHub.Api.Models;
using LibraryHub.Api.Middleware;
using LibraryHub.Api.Data;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseMiddleware<ElapsedTimeMiddleware>();
app.Use(async (context, next) =>
{
    Console.WriteLine("A: before");
    await next(context);
    Console.WriteLine("A: after");
});

app.Use(async (context, next) =>
{
    Console.WriteLine("B: before");
    await next(context);
    Console.WriteLine("B: after");
});

app.MapGet("/", () => "WElcome to LibraryHubd");
app.MapGet("/api/status", () => new { name = "LibraryHub", status = "open" });
app.MapGet("/api/branches", () => LibraryData.Branches);
app.MapGet("/api/books", () => LibraryData.Books);
app.MapGet("/api/books/titles", () => LibraryData.Books.Select(b => b.Title).Order().ToList());
app.Run(async context =>
    await context.Response.WriteAsync("LibraryHub"));
app.Run();