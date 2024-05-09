using AspCore_Api_2.Models;

namespace AspCore_Api_2.Services
{
    public interface IPersonService
    {
        List<Person> GetPerson();
        Person AddPerson(Person person);
        Person UpdatePerson(Guid id, Person person);
        bool DeletePerson(Guid id);
        List<Person> FilterPerson(string name, string gender, string birthPlace);
    }
}
