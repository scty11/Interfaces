using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PersonRepository.Fake;
using PersonRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PeopleViewer.Test
{
    [TestClass]
    public class MockVMTest
    {
        [TestInitialize]
        public void Setup()
        {
            //rather than creatign a whole class for testing we can create
            //a mock class which can perform the behaviour we wish to test.
            var people = new List<Person>()
            {
                new Person() {FirstName = "John", LastName = "Smith", 
                    Rating = 7, StartDate = DateTime.Parse("01/10/2000")},
                new Person() {FirstName = "Mary", LastName = "Thomas", 
                    Rating = 9, StartDate = DateTime.Parse("23/07/1971")},
            };
            //creates a object which implements the interface
            var mockRepo = new Mock<IPersonRepository>();
            //sets up what will be returned when the method specified is called.
            mockRepo.Setup(r => r.GetPeople()).Returns(people);

            SimpleContainer.MapInstance<IPersonRepository>(mockRepo.Object);
        }

        [TestMethod]
        public void People_WithMockOnFetchData_IsPopulated()
        {
            // Arrange
            var viewModel = new MainViewModel();

            // Act
            viewModel.FetchData();

            // Assert
            Assert.IsNotNull(viewModel.People);
            Assert.AreEqual(2, viewModel.People.Count());
        }

        [TestMethod]
        public void RepositoryType_WithMockOnCreation_ReturnsFakeRepositoryString()
        {
            // Arrange / Act
            var viewModel = new MainViewModel();
            var expectedString = "PersonRepository.Fake.FakeRepository";

            // Assert
            Assert.AreNotEqual(expectedString, viewModel.RepositoryType);
        }
    }
}
