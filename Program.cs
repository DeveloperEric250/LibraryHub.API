using System.Diagnostics.Eventing.Reader;
using LibraryHub.Api.Models;

using LibraryHub.Api.Data;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "WElcome to LibraryHubd");
app.MapGet("/api/status", () => new { name = "LibraryHub", status = "open" });
app.MapGet("/api/branches", () => LibraryData.Branches);
app.MapGet("/api/books", () => LibraryData.Books);
app.MapGet("/api/books/titles", () => LibraryData.Books.Select(b => b.Title).Order().ToList());

app.Run();