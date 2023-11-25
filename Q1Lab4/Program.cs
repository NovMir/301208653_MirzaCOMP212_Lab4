// See https://aka.ms/new-console-template for more information
using Q1Lab4;

Console.WriteLine("Question 01 - Lab 04");

// Invokes methods
Question1_1();
Console.WriteLine("-----------------");
Console.WriteLine("-----------------");
Question1_2();
Console.WriteLine("-----------------");
Console.WriteLine("-----------------");
Question1_3();
Console.WriteLine("-----------------");
Console.WriteLine("-----------------");
Question1_4();
Console.WriteLine("-----------------");
Console.WriteLine("-----------------");
Question1_5();
Console.WriteLine("-----------------");
Console.WriteLine("-----------------");
Question1_6();
Console.WriteLine("-----------------");
Console.WriteLine("-----------------");


// 1.1 List the names of the countries in alphabetical order [0.5 mark]

void Question1_1()
{
    var countries = Country.GetCountries();

    var alphabeticalCountries = countries.OrderBy(c => c.Name);

    foreach (var country in alphabeticalCountries)
    {
        Console.WriteLine(country.Name);
    }


}

// 1.2 List the names of the countries in descending order of number of resources [0.5 mark]
void Question1_2()
{
    var countries = Country.GetCountries();
    var countriesByResources = countries.OrderByDescending(c => c.Resources.Count);

    foreach (var country in countriesByResources)
    {
        Console.WriteLine($"{country.Name} - Resources: {country.Resources.Count}");
    }

}

// 1.3 List the names of the countries that shares a border with Argentina [0.5 mark]
void Question1_3()
{
    var countries = Country.GetCountries();
    var argentinaNeighbors = countries.FirstOrDefault(c => c.Name == "Argentina")?.Borders;

    foreach (var neighbor in argentinaNeighbors)
    {
        Console.WriteLine(neighbor);
    }

}

// 1.4 List the names of the countries that has more than 10,000,000 population [0.5 mark]
void Question1_4()
{
    var countries = Country.GetCountries();
    var highlyPopulatedCountries = countries.Where(c => c.Population > 10000000);

    foreach (var country in highlyPopulatedCountries)
    {
        Console.WriteLine($"{country.Name} - Population: {country.Population}");
    }

}

// 1.5 List the country with highest population [1 mark]
void Question1_5()
{
    var countries = Country.GetCountries();
    var mostPopulatedCountry = countries.OrderByDescending(c => c.Population).FirstOrDefault();

    if (mostPopulatedCountry != null)
    {
        Console.WriteLine($"Country with the highest population: {mostPopulatedCountry.Name} - Population: {mostPopulatedCountry.Population}");
    }


}

// 1.6 List all the religion in south America in dictionary order [1 mark]
void Question1_6()
{
    var countries = Country.GetCountries();
    var religions = countries.SelectMany(c => c.Religions).Distinct().OrderBy(r => r);

    Console.WriteLine("Religions in South America:");
    foreach (var religion in religions)
    {
        Console.WriteLine(religion);
    }

}
