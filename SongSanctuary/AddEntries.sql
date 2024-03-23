use SongSanctuaryDb;

INSERT INTO Bands (Name, Active, MemberCount)
VALUES 
('The Beatles', 1, 4),
('Queen', 1, 4),
('Led Zeppelin', 0, 4),
('Pink Floyd', 1, 4),
('The Rolling Stones', 1, 4),
('Nirvana', 0, 4);

INSERT INTO Albums (Name, ReleaseYear, SongCount, BandId)
VALUES 
('Abbey Road', 1969, 17, 1),
('A Night at the Opera', 1975, 12, 2),
('Led Zeppelin IV', 1971, 8, 3),
('The Dark Side of the Moon', 1973, 10, 4),
('Sticky Fingers', 1971, 10, 5),
('Nevermind', 1991, 12, 6);

INSERT INTO Songs (Name, Length, Genre, AlbumId)
VALUES 
('Come Together', '04:20', 'Rock', 1),
('Bohemian Rhapsody', '05:55', 'Rock', 2),
('Stairway to Heaven', '08:02', 'Rock', 3),
('Money', '06:23', 'Rock', 4),
('Brown Sugar', '03:48', 'Rock', 5),
('Smells Like Teen Spirit', '05:01', 'Grunge', 6);

INSERT INTO Artists(FirstName, LastName, Alive, BandId)
VALUES 
('John', 'Lennon', 0, 1),
('Paul', 'McCartney', 1, 1),
('George', 'Harrison', 0, 1),
('Ringo', 'Starr', 1, 1),
('Freddie', 'Mercury', 0, 2),
('Brian', 'May', 1, 2),
('Roger', 'Taylor', 1, 2),
('John', 'Deacon', 1, 2),
('Robert', 'Plant', 1, 3),
('Jimmy', 'Page', 1, 3),
('John', 'Paul Jones', 1, 3),
('Syd', 'Barrett', 0, 4),
('Roger', 'Waters', 1, 4),
('David', 'Gilmour', 1, 4),
('Richard', 'Wright', 0, 4),
('Mick', 'Jagger', 1, 5),
('Keith', 'Richards', 1, 5),
('Charlie', 'Watts', 1, 5),
('Ron', 'Wood', 1, 5),
('Kurt', 'Cobain', 0, 6);
