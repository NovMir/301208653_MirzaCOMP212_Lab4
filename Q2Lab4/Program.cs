// See https://aka.ms/new-console-template for more information
using Q2Lab4.Models;

Console.WriteLine("Question 02 - Lab 04");

// Invokes methods
Question2_1();

Console.WriteLine("-----------------");
Console.WriteLine("-----------------");
Question2_2();
Console.WriteLine("-----------------");
Console.WriteLine("-----------------");
Question2_3();

//1.Get a list of all the titles and the authors who wrote them. Sort the results by title. [2 marks]
void Question2_1()
{
    using (var context = new BooksDbContext())
    {
        var query = context.Titles
                        .OrderBy(t => t.Title1)
                        .Select(t => new
                        {
                            Title = t.Title1,
                            Authors = t.Authors
                                       .Select(a => $"{a.FirstName} {a.LastName}")
                        });

        foreach (var item in query)
        {
            Console.WriteLine($"Title: {item.Title}");
            foreach (var author in item.Authors)
            {
                Console.WriteLine($"  Author: {author}");
            }
            Console.WriteLine();
        }

    }
}

//2.Get a list of all the titles and the authors who wrote them. Sort the results by title.  Each title sort the authors alphabetically by last name, then first name[4 marks]
void Question2_2()
{
    using (var context = new BooksDbContext())
    {
        var query2 = context.Titles
                            .OrderBy(b => b.Title1)
                            .Select(b => new
                            {
                                Title = b.Title1,
                                Authors = b.Authors
                                                        .OrderBy(a => a.LastName)
                                                        .ThenBy(a => a.FirstName)
                                                        .Select(a => $"{a.FirstName} {a.LastName}")
                            });

        foreach (var book in query2)
        {
            Console.WriteLine($"Title: {book.Title}");
            foreach (var author in book.Authors)
            {
                Console.WriteLine($"  Author: {author}");
            }
        }
    }

}

//3.Get a list of all the authors grouped by title, sorted by title; for a given title sort the author names alphabetically by last name then first name.[4 marks]
void Question2_3()
{
    using (var context = new BooksDbContext())
    {
        var query = context.Authors
                      .SelectMany(a => a.Isbns.Select(t => new { a, t.Title1 }))
                      .OrderBy(at => at.Title1)
                      .ThenBy(at => at.a.LastName)
                      .ThenBy(at => at.a.FirstName)
                      .GroupBy(at => at.Title1)
                      .Select(g => new
                      {
                          Title = g.Key,
                          Authors = g.Select(x => $"{x.a.FirstName} {x.a.LastName}")
                      });

        foreach (var group in query)
        {
            Console.WriteLine($"Title: {group.Title}");
            foreach (var author in group.Authors)
            {
                Console.WriteLine($"  Author: {author}");
            }
            Console.WriteLine();
        }

    }
}
