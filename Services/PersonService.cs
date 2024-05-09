using AspCore_Api_2.Models;
namespace AspCore_Api_2.Services
{
    public class PersonService : IPersonService
    {
        private static List<Person> _person = new List<Person>()
        {
            new Person {Id = Guid.NewGuid() ,FirstName = "Van A", LastName = "Nguyen", Gender = "Male", DateOfBirth = new DateTime(2000, 3, 15), BirthPlace = "Ha Noi" },
            new Person {Id = Guid.NewGuid() ,FirstName = "Van B", LastName = "Nguyen", Gender = "Male", DateOfBirth = new DateTime(1999, 6, 20),  BirthPlace = "Sai Gon" },
            new Person {Id = Guid.NewGuid() ,FirstName = "Thi C", LastName = "Nguyen", Gender = "Female", DateOfBirth = new DateTime(2001, 6, 20), BirthPlace = "Sai Gon" },
        };

        public List<Person> GetPerson()
        {
            return _person;
        }

        public Person GetById(Guid id)
        {
            return _person.FirstOrDefault(p => p.Id == id);
        }
        public Person AddPerson(Person person)
        {
            person.Id = Guid.NewGuid();
            _person.Add(person);
            return person;
        }
        public Person UpdatePerson(Guid id, Person person)
        {
            var existingPerson = _person.FirstOrDefault(p => p.Id == id);
            if (existingPerson != null)
            {
                existingPerson.FirstName = person.FirstName;
                existingPerson.LastName = person.LastName;
                existingPerson.DateOfBirth = person.DateOfBirth;
                existingPerson.Gender = person.Gender;
                existingPerson.BirthPlace = person.BirthPlace;
            }
            return existingPerson;
        }
        public bool DeletePerson(Guid id)
        {
            var existingPerson = _person.FirstOrDefault(p => p.Id == id);
            if (existingPerson != null)
            {
                _person.Remove(existingPerson);
                return true;
            }
            return false;
        }
        public List<Person> FilterPerson(string name, string gender, string birthPlace)
        {
            return _person.Where(p =>
                (string.IsNullOrEmpty(name) || (p.FullName).Contains(name, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(gender) || p.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(birthPlace) || p.BirthPlace.Equals(birthPlace, StringComparison.OrdinalIgnoreCase)))
                .ToList();
        }
    }
}
