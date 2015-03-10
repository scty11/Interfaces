﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonRepository.Fake;
using PersonRepository.Interface;
using System.Linq;

namespace PeopleViewer.Test
{
    [TestClass]
    public class FakeVMTest
    {
        [TestInitialize]
        public void Setup()
        {
            SimpleContainer.MapInstance<IPersonRepository>(new FakeRepository());
        }

        [TestMethod]
        public void People_WithFakeOnFetchData_IsPopulated()
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
        public void RepositoryType_WithFakeOnCreation_ReturnsFakeRepositoryString()
        {
            // Arrange / Act
            var viewModel = new MainViewModel();
            var expectedString = "PersonRepository.Fake.FakeRepository";

            // Assert
            Assert.AreEqual(expectedString, viewModel.RepositoryType);
        }
    }
}