using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLMusicApp
{
    internal class AlbumsDAO
    {
        string connectionString = "datasource=localhost;port=3306;username=root;password=;database=musik;"; // Skapar en sträng som innehåller information om anslutningen till databasen

        public List<Album> getAllAlbums() // Hämtar alla album
        {
            List<Album> albums = new List<Album>(); 

            MySqlConnection connection = new MySqlConnection(connectionString); // Länkar till databasen
            connection.Open(); // Öppnar anslutningen till databasen

            MySqlCommand command = new MySqlCommand("SELECT * FROM album", connection); // Väljer alla album från databasen

            using (MySqlDataReader reader = command.ExecuteReader()) // Läser från databasen
            {
                while (reader.Read())
                {
                    Album a = new Album 
                    {
                        ID = reader.GetInt32(0), 
                        Title = reader.GetString(1),
                        ArtistName = reader.GetString(2),
                        ReleaseYear = reader.GetInt32(3),
                        Image = reader.GetString(4),
                        Description = reader.GetString(5),
                    }; 

                    a.Tracks = getTrackForAlbum(a.ID); // Hämtar låtarna för varje album

                    albums.Add(a); // Lägger till albumet i listan
                }
            }
            connection.Close(); // Stänger anslutningen till databasen

            return albums;
        }

        public List<Album> searchTitels(String searchTerm) //Söker efter album i listan
        {
            List<Album> albums = new List<Album>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open(); 

            String searchWildPharse = "%" + searchTerm + "%"; // Lägger till % före och efter söktermen
            MySqlCommand command = new MySqlCommand(); // Skapar en MySqlCommand
            command.CommandText = "SELECT * FROM album WHERE ALBUM_TITEL LIKE @searchTerm"; // Väljer album från databasen där albumtiteln innehåller söktermen
            command.Parameters.AddWithValue("@searchTerm", searchWildPharse); // Hämtar söktermen från det användaren skrivit in
            command.Connection = connection; // Ansluter till databasen

            using (MySqlDataReader reader = command.ExecuteReader()) //Läser från databasen
            {
                while (reader.Read())
                {
                    Album a = new Album
                    {
                        ID = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        ArtistName = reader.GetString(2),
                        ReleaseYear = reader.GetInt32(3),
                        Image = reader.GetString(4),
                        Description = reader.GetString(5),
                    };
                    albums.Add(a); // Lägger till albumet i listan
                }
            }
            connection.Close(); // Stänger anslutningen till databasen

            return albums;
        }

        public int addOneAlbum(Album album) // Lägger till album
        {
            MySqlConnection connection = new MySqlConnection(connectionString); 
            connection.Open();

            MySqlCommand command = new MySqlCommand("INSERT INTO `album`(`ALBUM_TITEL`, `ARTIST`, `YEAR`, `IMAGE_NAME`, `DESCRIPTION`) VALUES (@titel , @artistname, @releaseyear, @image ,@description)", connection); // Lägger till album i databasen

            // Hämtar information om albumet från användaren
            command.Parameters.AddWithValue("@titel", album.Title);
            command.Parameters.AddWithValue("@artistname", album.ArtistName);
            command.Parameters.AddWithValue("@releaseyear", album.ReleaseYear);
            command.Parameters.AddWithValue("@image", album.Image);
            command.Parameters.AddWithValue("@description", album.Description);
            
            int newRows = command.ExecuteNonQuery(); // Lägger till albumet i databasen
            connection.Close();

            return newRows;
        }

        public List<Track> getTrackForAlbum(int albumID)
        {
            List<Track> albums = new List<Track>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM tracks WHERE album_ID = @albumid";
            command.Parameters.AddWithValue("@albumid", albumID);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Track t = new Track
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Number = reader.GetInt32(2),
                        VideoURL = reader.GetString(3),
                        Lyrics = reader.GetString(4),
                        album = reader.GetInt32(5),
                    };
                    albums.Add(t);
                }
            }
            connection.Close();

            return albums;
        }

        public List<JObject> getTrackUsingJoin(int albumID)
        {
            List<JObject> returnThese = new List<JObject>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();


            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT tracks.ID AS trackID, album.ALBUM_TITEL, `track_titel`, `video_url`, `lyrics` FROM `tracks` JOIN album ON album_ID = album.ID WHERE album_ID = @albumid";
            command.Parameters.AddWithValue("@albumid", albumID);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    JObject newTrack = new JObject();

                    for (int i = 0; i <reader.FieldCount; i++)
                    {
                        newTrack.Add(reader.GetName(i).ToString(), reader.GetValue(i).ToString());
                    }

                    returnThese.Add(newTrack);
                }
            }
            connection.Close();

            return returnThese;
        }

        internal int deleteOneTrack(int trackID)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("DELETE FROM tracks WHERE `tracks`.`TrackID` = @trackID", connection);

            command.Parameters.AddWithValue("@trackID", trackID);
            

            int result = command.ExecuteNonQuery();
            connection.Close();

            return result;
        }

        public int TrackCount(int albumID)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM tracks WHERE album_ID = @albumid", connection);
            command.Parameters.AddWithValue("@albumid", albumID);

            int count = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            return count;
        }
        
        public int addOneTrack(Track track)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("INSERT INTO `tracks`(`track_titel`, `number`, `video_url`, `lyrics`, `album_ID`) VALUES (@titel, @number, @video_url, @lyrics, @album_Id)", connection);

            command.Parameters.AddWithValue("@titel", track.Name);
            command.Parameters.AddWithValue("@number", track.Number);
            command.Parameters.AddWithValue("@video_url", track.VideoURL);
            command.Parameters.AddWithValue("@lyrics", track.Lyrics);
            command.Parameters.AddWithValue("@album_Id", track.album);

            int newRows = command.ExecuteNonQuery();
            connection.Close();

            return newRows;
        }

        public int CheckIfAlbumExsists(int Name)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = new MySqlCommand("SELECT ID FROM album WHERE ID IN (SELECT ID FROM album WHERE ID = @trackName)", connection);
            command.Parameters.AddWithValue("@trackName", Name);

            int check = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            return check;
        }

        public int UpdateTrack(Track track, int ID)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand command = new MySqlCommand("UPDATE `tracks` SET `track_titel` = @titel, `number` = @number, `video_url` = @video_url, `lyrics` = @lyrics, `album_ID` = @album_Id WHERE `TrackID` = @trackID", connection);

            command.Parameters.AddWithValue("@titel", track.Name);
            command.Parameters.AddWithValue("@number", track.Number);
            command.Parameters.AddWithValue("@video_url", track.VideoURL);
            command.Parameters.AddWithValue("@lyrics", track.Lyrics);
            command.Parameters.AddWithValue("@album_Id", track.album);
            command.Parameters.AddWithValue("@trackID", ID);

            int result = command.ExecuteNonQuery();
            connection.Close();
            return result;
        }

        // Add a place to see how many people liked the song
        // Simon: Bad, Isak: Beat It, Vilhelm: Xscape, Christofer: Smooth Criminal, George: Thriller 
    }
}
