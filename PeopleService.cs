using TestProject.Models;

namespace TestProject.Services;

public static class PeopleService
{
    static List<People> Employees { get; }
    static int nextId = 3;
    static PeopleService()
    {
        Employees = new List<People>
        {
            new People { FullName = "Eric Naughton", id = 6897, email = "naughton.eric@gmail.com", jobTitle = "IT Technician"},
            new People { FullName = "Dustin Hinkle", id = 5486, email = "dustin.hinkle@chukchansigold.com", jobTitle = "IT Supervisor"}
        };
    }

    public static List<People> GetAll() => Employees;

    public static People? Get(int id) => Employees.FirstOrDefault(p => p.id == id);

    public static void Add(People people)
    {
        people.id = nextId++;
        Employees.Add(people);
    }

    public static void Delete(int id)
    {
        var people = Get(id);
        if (people is null)
            return;
        Employees.Remove(people);
    }

    public static void Update(People people)
    {
        var index = Employees.FindIndex(p => p.id == people.id);
        if (index == -1)
            return;
        Employees[index] = people;
    }
}