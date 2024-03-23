using Controller.Controller;
using Data.Model;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
namespace UnitTests {
    [TestFixture]
    public class ArtistControllerTests {
        private ArtistController _artistController;

        [SetUp]
        public void Setup() {
            _artistController = new ArtistController();
        }

        [Test]
        public void GetAll_ReturnsAllArtists() {
            // Act
            var result = _artistController.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<List<Artist>>(result);
            Assert.Greater(result.Count, 0);
        }

        [Test]
        public void Get_ValidId_ReturnsArtist() {
            // Arrange
            int id = 1;

            // Act
            var result = _artistController.Get(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<Artist>(result);
            Assert.AreEqual(id, result.Id);
        }

        [Test]
        public void Get_InvalidId_ReturnsNull() {
            // Arrange
            int id = -1;

            // Act
            var result = _artistController.Get(id);

            // Assert
            Assert.Null(result);
        }

        [Test]
        public void Add_AddsNewArtist() {
            // Arrange
            var newArtist = new Artist { FirstName = "John", LastName = "Doe", BandId = 1 };

            // Act
            _artistController.Add(newArtist);

            // Assert
            var retrievedArtist = _artistController.Get(newArtist.Id);
            Assert.NotNull(retrievedArtist);
            Assert.AreEqual(newArtist.FirstName, retrievedArtist.FirstName);
            Assert.AreEqual(newArtist.LastName, retrievedArtist.LastName);
        }

        [Test]
        public void Update_UpdatesArtist() {
            // Arrange
            var artistToUpdate = _artistController.Get(1);
            artistToUpdate.FirstName = "UpdatedFirstName";
            artistToUpdate.LastName = "UpdatedLastName";

            // Act
            _artistController.Update(artistToUpdate);

            // Assert
            var updatedArtist = _artistController.Get(artistToUpdate.Id);
            Assert.NotNull(updatedArtist);
            Assert.AreEqual(artistToUpdate.FirstName, updatedArtist.FirstName);
            Assert.AreEqual(artistToUpdate.LastName, updatedArtist.LastName);
        }

        [Test]
        public void Delete_DeletesArtist() {
            // Arrange
            var artistToDelete = new Artist { FirstName = "To be Deleted", LastName = "Artist", BandId = 2 };
            _artistController.Add(artistToDelete);

            // Act
            _artistController.Delete(artistToDelete.Id);

            // Assert
            var deletedArtist = _artistController.Get(artistToDelete.Id);
            Assert.Null(deletedArtist);
        }
    }
}
