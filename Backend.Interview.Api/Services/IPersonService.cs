namespace Backend.Interview.Api.Services;

public interface IPersonService
{
    List<Person> GetAllPeople();
    Person AddNewPerson(Person person);
    Person EditPerson(string id, Person person);
    void DeletePerson(string id);
}
