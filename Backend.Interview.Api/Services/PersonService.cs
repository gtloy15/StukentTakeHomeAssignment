namespace Backend.Interview.Api.Services;

public class PersonService : IPersonService
{
    private readonly string _jsonFilePath = Directory.GetCurrentDirectory() + @"\seed.json";

    public List<Person> GetAllPeople()
    {
        var people = GetDataFromJsonFile();
        return people;
    }

    public Person AddNewPerson(Person person)
    {
        var people = GetDataFromJsonFile();
        // I'm not intending to get the following ID to match the original seed.json ID format, just creating a
        // fairly secure standard ID
        person.Id = Guid.NewGuid().ToString();
        people.Add(person);
        SaveDataToFile(people);
        return person;
    }

    public Person EditPerson(string id, Person person)
    {
        if (!isValidPerson(person))
        {
            throw new Exception("Submission is missing a required field.");
        }

        var people = GetDataFromJsonFile();
        var index = people.FindIndex(p => p.Id == id);
        people[index] = person;
        SaveDataToFile(people);
        return person;
    }

    public void DeletePerson(string id)
    {
        var people = GetDataFromJsonFile();
        var personToRemove = people.Single(p => p.Id == id);
        people.Remove(personToRemove);
        SaveDataToFile(people);
        return;
    }

    private List<Person> GetDataFromJsonFile()
    {
        var data = File.ReadAllText(_jsonFilePath);
        var people = JsonConvert.DeserializeObject<List<Person>>(data.ToString());
        return people;
    }

    // This check is redundant as far as the frontend form goes, but will provide at least some safety if the API endpoint
    // was to be called directly
    private bool isValidPerson(Person person)
    {
        return !String.IsNullOrEmpty(person.Id) &&
               !String.IsNullOrEmpty(person.FirstName) &&
               !String.IsNullOrEmpty(person.LastName);
    }

    private void SaveDataToFile(List<Person> people)
    {
        var peopleJson = JsonConvert.SerializeObject(people, Formatting.Indented);
        File.WriteAllText(_jsonFilePath, peopleJson);
    }
}
