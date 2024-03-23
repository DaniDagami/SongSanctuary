using Controller.Controller;
using Data.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
namespace UnitTests {
    [TestFixture]
    public class AlbumControllerTests {
        private AlbumController _albumController;

        [SetUp]
        public void Setup() {
            _albumController = new AlbumController();
        }

        [Test]
        public void GetAll_ReturnsAllAlbums() {
            var result = _albumController.GetAll();

            Assert.NotNull(result);
            Assert.IsInstanceOf<List<Album>>(result);
            Assert.Greater(result.Count, 0);
        }

        [Test]
        public void Get_ValidId_ReturnsAlbum() {

            int id = 1;

            Album result = _albumController.Get(id);

            Assert.NotNull(result);
            Assert.IsInstanceOf<Album>(result);
            Assert.AreEqual(id, result.Id);
        }

        [Test]
        public void Get_InvalidId_ReturnsNull() {
            int id = -1;

            var result = _albumController.Get(id);

            Assert.Null(result);
        }

        [Test]
        public void Add_AddsNewAlbum() {
            var newAlbum = new Album { Name = "New Album", ReleaseYear = 2022, SongCount = 10, BandId = 1 };

            _albumController.Add(newAlbum);

            var retrievedAlbum = _albumController.Get(newAlbum.Id);
            Assert.NotNull(retrievedAlbum);
            Assert.AreEqual(newAlbum.Name, retrievedAlbum.Name);
        }

        [Test]
        public void Update_UpdatesAlbum() {
            var albumToUpdate = _albumController.Get(1);
            albumToUpdate.Name = "Updated Album";

            _albumController.Update(albumToUpdate);

            var updatedAlbum = _albumController.Get(albumToUpdate.Id);
            Assert.NotNull(updatedAlbum);
            Assert.AreEqual(albumToUpdate.Name, updatedAlbum.Name);
        }

        [Test]
        public void Delete_DeletesAlbum() {
            var albumToDelete = new Album { Name = "To be Deleted", ReleaseYear = 2022, SongCount = 5, BandId = 2 };
            _albumController.Add(albumToDelete);

            _albumController.Delete(albumToDelete.Id);

            var deletedAlbum = _albumController.Get(albumToDelete.Id);
            Assert.Null(deletedAlbum);
        }
    }
}
