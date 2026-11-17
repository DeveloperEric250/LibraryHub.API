using LibraryHub.Api.Models;

namespace LibraryHub.Api.Data;

/// <summary>
/// LibraryHub keeps its data in static lists for now. Session 01B replaces this
/// with a service, and session 02A with a database.
/// </summary>
public static class LibraryData
{
    public static readonly IReadOnlyList<Branch> Branches =
    [
        new("KGL", "Kigali Central Library", "Kigali"),
        new("HYE", "Huye Reading Room", "Huye"),
        new("MUS", "Musanze Community Library", "Musanze"),
        new("RUB", "Rubavu Lakeside Library", "Rubavu"),
        new("NYA", "Nyagatare Library", "Nyagatare"),
    ];

    public static readonly IReadOnlyList<Book> Books =
    [
        new(1, "Things Fall Apart", "Chinua Achebe", "KGL"),
        new(2, "Our Lady of the Nile", "Scholastique Mukasonga", "HYE"),
        new(3, "Half of a Yellow Sun", "Chimamanda Ngozi Adichie", "KGL"),
        new(4, "Weep Not, Child", "Ngugi wa Thiong'o", "MUS"),
        new(5, "The Pragmatic Programmer", "David Thomas and Andrew Hunt", "RUB"),
        new(6, "Clean Code", "Robert C. Martin", "NYA"),
    ];
}