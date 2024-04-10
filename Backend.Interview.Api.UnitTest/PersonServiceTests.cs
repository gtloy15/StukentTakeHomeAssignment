using System.Reflection.Emit;

namespace Backend.Interview.Api.UnitTest
{
    public class PersonServiceTests
    {
        private readonly PersonService _sut;
        private readonly Exception _expectedException = new Exception("Submission is missing a required field.");
        private readonly Person _personWithNoId = new Person()
        {
            Id = "",
            FirstName = "Michael",
            LastName = "Scott",
            Dob = new DateTime(1962, 8, 16),
            Address = new Address()
            {
                Line1 = "123 Office Rd",
                City = "Scranton",
                State = "PA",
                ZipCode = "12345"
            }
        };

        public PersonServiceTests()
        {
            _sut = new PersonService();
        }

        [Fact]
        public void AddNewPerson_IdIsNotNullAfterRun()
        {
            var result = _sut.AddNewPerson(_personWithNoId);

            Assert.NotEmpty(result.Id);
            Assert.NotNull(result.Id);
        }

        [Fact]
        public void EditPerson_InvalidPersonThrowsException()
        {
            Assert.Throws<Exception>(() => _sut.EditPerson("1", _personWithNoId));
        }
    }
}
