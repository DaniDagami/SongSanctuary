using Controller.Controller;
using Data.Model;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
namespace UnitTests {
    [TestFixture]
    public class BandControllerTests {
        private BandController _bandController;

        [SetUp]
        public void Setup() {
            _bandController = new BandController();
        }

        [Test]
        public void GetAll_ReturnsAllBands() {
            // Act
            var result = _bandController.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<List<Band>>(result);
            Assert.Greater(result.Count, 0);
        }

        [Test]
        public void Get_ValidId_ReturnsBand() {
            // Arrange
            int id = 1;

            // Act
            var result = _bandController.Get(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<Band>(result);
            Assert.AreEqual(id, result.Id);
        }

        [Test]
        public void Get_InvalidId_ReturnsNull() {
            // Arrange
            int id = -1;

            // Act
            var result = _bandController.Get(id);

            // Assert
            Assert.Null(result);
        }

        [Test]
        public void Add_AddsNewBand() {
            // Arrange
            var newBand = new Band { Name = "New Band", Active = true, MemberCount = 5 };

            // Act
            _bandController.Add(newBand);

            // Assert
            var retrievedBand = _bandController.Get(newBand.Id);
            Assert.NotNull(retrievedBand);
            Assert.AreEqual(newBand.Name, retrievedBand.Name);
        }

        [Test]
        public void Update_UpdatesBand() {
            // Arrange
            var bandToUpdate = _bandController.Get(1);
            bandToUpdate.Name = "Updated Band";

            // Act
            _bandController.Update(bandToUpdate);

            // Assert
            var updatedBand = _bandController.Get(bandToUpdate.Id);
            Assert.NotNull(updatedBand);
            Assert.AreEqual(bandToUpdate.Name, updatedBand.Name);
        }

        [Test]
        public void Delete_DeletesBand() {
            // Arrange
            var bandToDelete = new Band { Name = "To be Deleted", Active = true, MemberCount = 3 };
            _bandController.Add(bandToDelete);

            // Act
            _bandController.Delete(bandToDelete.Id);

            // Assert
            var deletedBand = _bandController.Get(bandToDelete.Id);
            Assert.Null(deletedBand);
        }
    }

}
