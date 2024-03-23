using Controller.Controller;
using Data.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
namespace UnitTests {
    [TestFixture]
    public class AlbumControllerIntegrationTests {
        private AlbumController _albumController;
        private UnitTestDbContext _unitTestDbContext;

        [SetUp]
        public void Setup() {
            _albumController = new AlbumController();
        }

        [Test]
        public void GetAll_ReturnsAllAlbums() {
            using(_unitTestDbContext = new UnitTestDbContext()) {
                var result = _albumController.GetAll();

                // Assert
                Assert.NotNull(result);
                Assert.IsInstanceOf<List<Album>>(result);
                Assert.Greater(result.Count, 0);
            }
        }

        [Test]
        public void Get_ValidId_ReturnsAlbum() {

            using(_unitTestDbContext = new UnitTestDbContext()) {
                int id = 1;

                // Act
                var result = _albumController.Get(id);

                // Assert
                Assert.NotNull(result);
                Assert.IsInstanceOf<Album>(result);
                Assert.AreEqual(id, result.Id);
            }       
        }

        [Test]
        public void Get_InvalidId_ReturnsNull() {
            // Arrange
            int id = -1;

            // Act
            var result = _albumController.Get(id);

            // Assert
            Assert.Null(result);
        }

        [Test]
        public void Add_AddsNewAlbum() {
            // Arrange
            var newAlbum = new Album { Name = "New Album", ReleaseYear = 2022, SongCount = 10, BandId = 1 };

            // Act
            _albumController.Add(newAlbum);

            // Assert
            var retrievedAlbum = _albumController.Get(newAlbum.Id);
            Assert.NotNull(retrievedAlbum);
            Assert.AreEqual(newAlbum.Name, retrievedAlbum.Name);
        }

        [Test]
        public void Update_UpdatesAlbum() {
            // Arrange
            var albumToUpdate = _albumController.Get(1);
            albumToUpdate.Name = "Updated Album";

            // Act
            _albumController.Update(albumToUpdate);

            // Assert
            var updatedAlbum = _albumController.Get(albumToUpdate.Id);
            Assert.NotNull(updatedAlbum);
            Assert.AreEqual(albumToUpdate.Name, updatedAlbum.Name);
        }

        [Test]
        public void Delete_DeletesAlbum() {
            // Arrange
            var albumToDelete = new Album { Name = "To be Deleted", ReleaseYear = 2022, SongCount = 5, BandId = 2 };
            _albumController.Add(albumToDelete);

            // Act
            _albumController.Delete(albumToDelete.Id);

            // Assert
            var deletedAlbum = _albumController.Get(albumToDelete.Id);
            Assert.Null(deletedAlbum);
        }
    }

}
