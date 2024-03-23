using Controller.Controller;
using Data.Model;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
namespace UnitTests {
    [TestFixture]
    public class SongControllerTests {
        private SongController _songController;

        [SetUp]
        public void Setup() {
            _songController = new SongController();
        }

        [Test]
        public void GetAll_ReturnsAllSongs() {
            var result = _songController.GetAll();

            Assert.NotNull(result);
            Assert.IsInstanceOf<List<Song>>(result);
            Assert.Greater(result.Count, 0);
        }

        [Test]
        public void Get_ValidId_ReturnsSong() {
            int id = 1;

            var result = _songController.Get(id);

            Assert.NotNull(result);
            Assert.IsInstanceOf<Song>(result);
            Assert.AreEqual(id, result.Id);
        }

        [Test]
        public void Get_InvalidId_ReturnsNull() {
            int id = -1;

            var result = _songController.Get(id);

            Assert.Null(result);
        }

        [Test]
        public void Add_AddsNewSong() {
            var newSong = new Song { Name = "New Song", Length = TimeSpan.Parse("03:30"), Genre = "Rock", AlbumId = 1 };

            _songController.Add(newSong);

            var retrievedSong = _songController.Get(newSong.Id);
            Assert.NotNull(retrievedSong);
            Assert.AreEqual(newSong.Name, retrievedSong.Name);
        }

        [Test]
        public void Update_UpdatesSong() {
            var songToUpdate = _songController.Get(1);
            songToUpdate.Name = "Updated Song";

            _songController.Update(songToUpdate);

            var updatedSong = _songController.Get(songToUpdate.Id);
            Assert.NotNull(updatedSong);
            Assert.AreEqual(songToUpdate.Name, updatedSong.Name);
        }

        [Test]
        public void Delete_DeletesSong() {
            var songToDelete = new Song { Name = "To be Deleted", Length = TimeSpan.Parse("03:45"), Genre = "Pop", AlbumId = 2 };
            _songController.Add(songToDelete);

            _songController.Delete(songToDelete.Id);

            
            var deletedSong = _songController.Get(songToDelete.Id);
            Assert.Null(deletedSong);
        }
    }
}
