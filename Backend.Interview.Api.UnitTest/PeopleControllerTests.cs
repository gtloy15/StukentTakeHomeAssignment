namespace Backend.Interview.Api.UnitTests
{
    public class PeopleControllerTests
    {
        private readonly PeopleController _sut;
        private readonly Mock<IPersonService> _personServiceMock;
        private readonly Mock<IMakeShiftLogger> _loggerMock;
        private readonly Exception _expectedException;

        private readonly List<Person> _personList;
        public PeopleControllerTests()
        {
            _personServiceMock = new Mock<IPersonService>();
            _loggerMock = new Mock<IMakeShiftLogger>();

            _sut = new PeopleController(_personServiceMock.Object, _loggerMock.Object);

            _personList = new List<Person>
            {
                new Person
                {
                    Id = "1",
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
                },
                new Person
                {
                    Id = "2",
                    FirstName = "Jimothy",
                    LastName = "Halpert",
                    Dob = new DateTime(1979, 10, 20),
                    Address = new Address()
                    {
                        Line1 = "234 Office Rd",
                        City = "Scranton",
                        State = "PA",
                        ZipCode = "12345"
                    }
                }
            };

            _expectedException = new Exception("Test Exception");
        }

        [Fact]
        public void GetAllPeople_ReturnsCorrectData()
        {
            // Arrange
            _personServiceMock.Setup(x => x.GetAllPeople()).Returns(_personList);

            // Act
            var result = _sut.GetAllPeople();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<Person>>(okResult.Value);
        }

        [Fact]
        public void GetAllPeople_ReturnsOkWithTheRightNumber()
        {
            // Arrange
            _personServiceMock.Setup(x => x.GetAllPeople()).Returns(_personList);

            // Act
            var result = _sut.GetAllPeople();
            var okResult = (OkObjectResult)result;
            var resultsList = (List<Person>)okResult.Value;

            // Assert
            Assert.Equal(_personList.Count, resultsList.Count);

            for (int i = 0; i < _personList.Count; i++)
            {
                Assert.Equal(_personList[i], resultsList[i]);
            }
        }

        [Fact]
        public void GetAllPeople_ReturnsBadRequestOnException()
        {
            // Arrange
            _personServiceMock.Setup(x => x.GetAllPeople()).Throws(_expectedException);

            // Act
            var result = _sut.GetAllPeople();
            var badRequestResult = (BadRequestObjectResult)result;
            var exception = (Exception)badRequestResult.Value;

            // Assert
            Assert.Equal("Test Exception", exception.Message);
        }

        [Fact]
        public void AddNewPerson_ReturnsCorrectResultTypeAndStatusCodeAndDataType()
        {
            // Arrange
            _personServiceMock.Setup(x => x.AddNewPerson(_personList[0])).Returns(_personList[0]);

            // Act
            var result = _sut.AddNewPerson(_personList[0]);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(objectResult.StatusCode, 201);
            Assert.IsType<Person>(objectResult.Value);
        }

        [Fact]
        public void AddNewPerson_ReturnsBadRequestOnException()
        {
            // Arrange
            _personServiceMock.Setup(x => x.AddNewPerson(_personList[0])).Throws(_expectedException);

            // Act
            var result = _sut.AddNewPerson(_personList[0]);
            var badRequestResult = (BadRequestObjectResult)result;
            var exception = (Exception)badRequestResult.Value;

            // Assert
            Assert.Equal("Test Exception", exception.Message);
        }

        [Fact]
        public void EditPerson_ReturnsCorrectResultTypeAndStatusCodeAndDataType()
        {
            // Arrange
            _personServiceMock.Setup(x => x.EditPerson(_personList[0].Id, _personList[0])).Returns(_personList[0]);

            // Act
            var result = _sut.EditPerson(_personList[0].Id, _personList[0]);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(objectResult.StatusCode, 201);
            Assert.IsType<Person>(objectResult.Value);
        }

        [Fact]
        public void EditPerson_ReturnsBadRequestOnException()
        {
            // Arrange
            _personServiceMock.Setup(x => x.EditPerson(_personList[0].Id, _personList[0])).Throws(_expectedException);

            // Act
            var result = _sut.EditPerson(_personList[0].Id, _personList[0]);
            var badRequestResult = (BadRequestObjectResult)result;
            var exception = (Exception)badRequestResult.Value;

            // Assert
            Assert.Equal("Test Exception", exception.Message);
        }

        [Fact]
        public void DeletePerson_ReturnsCorrectResultType()
        {
            // Act
            var result = _sut.DeletePerson(_personList[0].Id);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeletePerson_ReturnsBadRequestOnException()
        {
            // Arrange
            _personServiceMock.Setup(x => x.DeletePerson(_personList[0].Id)).Throws(_expectedException);

            // Act
            var result = _sut.DeletePerson(_personList[0].Id);
            var badRequestResult = (BadRequestObjectResult)result;
            var exception = (Exception)badRequestResult.Value;

            // Assert
            Assert.Equal("Test Exception", exception.Message);
        }
    }
}