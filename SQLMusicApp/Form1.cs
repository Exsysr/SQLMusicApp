using System.Windows.Forms;

namespace SQLMusicApp
{
    public partial class Form1 : Form
    {
        BindingSource abs = new BindingSource(); // Skapar en ny instans av BindingSource
        BindingSource tbs = new BindingSource(); // Skapar en ny instans av BindingSource

        List<Album> albums = new List<Album>(); // Skapar en ny lista av Album

        static bool trackPressed;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // Visar alla album
        {
            AlbumsDAO albumsDAO = new AlbumsDAO(); // Skapar en ny instans av AlbumsDAO


            // Connect the lists to the grid view control 

            albums = albumsDAO.getAllAlbums(); // Hämtar alla album

            abs.DataSource = albums; // Visar albumen i dataGridView1
            dataGridView1.DataSource = abs;


        }

        private void button2_Click(object sender, EventArgs e) // Söker efter album
        {
            AlbumsDAO albumsDAO = new AlbumsDAO(); // Skapar en ny instans av AlbumsDAO


            // Connect the lists to the grid view control
            abs.DataSource = albumsDAO.searchTitels(textBox1.Text); // Söker efter album

            dataGridView1.DataSource = abs; // Visar albumen i dataGridView1
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) // Visar albumets bild och låtar
        {
            DataGridView dataGridView = (DataGridView)sender; // Hämtar dataGridView1

            AlbumsDAO albumsDAO = new AlbumsDAO(); // Skapar en ny instans av AlbumsDAO

            int rowClicked = dataGridView.CurrentRow.Index; // Hämtar vilken rad som är klickad

            if (dataGridView.Rows[rowClicked].Cells[4].Value == null) // Om det inte finns någon bild att visa
            {
                return;
            }

            string imageUrl = dataGridView.Rows[rowClicked].Cells[4].Value.ToString(); // Hämtar ImageURL från en cell i dataGridView1
            pictureBox1.Load(imageUrl); // Visar ImageURL i en pictureBox

            tbs.DataSource = albums[rowClicked].Tracks; // Visar låtarna i dataGridView2

            dataGridView2.DataSource = tbs; // Visar låtarna i dataGridView2

            if (dataGridView.Rows[rowClicked].Cells[0].Value == null) // Om det inte finns något album att ta bort
            {
                MessageBox.Show("No");
                return;
            }
            int albumID = albums[rowClicked].ID; // Hämtar AlbumID från en cell i dataGridView1
            int numberOfTracks = albumsDAO.TrackCount(albumID); // Hämtar antalet låtar i albumet

            if (numberOfTracks > 0) // Om det finns låtar i albumet
            {
                button4.Enabled = true;
            }

        }

        private void button3_Click(object sender, EventArgs e) // Lägger till ett album
        {
            if (txt_AlbumName.Text == "" || txt_Artist.Text == "" || txt_Year.Text == "" || txt_ImageURL.Text == "" || txt_Description.Text == "") // Ser till att alla fält är ifyllda
            {
                MessageBox.Show("One or more fields are empty");
                return;
            }

            Album album = new Album // Skapar en ny instans av Album
            {
                Title = txt_AlbumName.Text,
                ArtistName = txt_Artist.Text,
                ReleaseYear = int.Parse(txt_Year.Text),
                Image = txt_ImageURL.Text,
                Description = txt_Description.Text
            };


            AlbumsDAO albumsDAO = new AlbumsDAO(); // Skapar en ny instans av AlbumsDAO
            int result = albumsDAO.addOneAlbum(album); // Lägger till albumet
            MessageBox.Show("Added " + result + " rows"); // Skriver ut hur många rader som har lagts till
        }

        private void button4_Click(object sender, EventArgs e) // Tar bort en låt
        {
            AlbumsDAO albumsDAO = new AlbumsDAO(); // Skapar en ny instans av AlbumsDAO

            int rowClicked2 = dataGridView2.CurrentRow.Index; // Hämtar vilken rad som är klickad
            if (dataGridView2.Rows[rowClicked2].Cells[0].Value == null) // Om det inte finns någon låt att ta bort
            {
                MessageBox.Show("No");
                return;
            }
            int trackID = int.Parse(dataGridView2.Rows[rowClicked2].Cells[0].Value.ToString()); // Hämtar TrackID från en cell i dataGridView2

            albumsDAO.deleteOneTrack(trackID); // Tar bort låten

            dataGridView2.DataSource = null; // Tömmer dataGridView2

            albums = albumsDAO.getAllAlbums(); // Hämtar alla album

            button4.Enabled = false; // Gör knappen oanvändbar 
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) // Visar en video i en webview
        {
            DataGridView dataGridView = (DataGridView)sender; // Hämtar dataGridView2

            int rowClicked = dataGridView.CurrentRow.Index; // Hämtar vilken rad som är klickad

            String VideoURL = dataGridView.Rows[rowClicked].Cells[3].Value.ToString(); // Hämtar VideoURL från en cell i dataGridView2

            webView21.Source = new Uri(VideoURL); // Visar VideoURL i en webview
        }

        private void button5_Click(object sender, EventArgs e) // Legger Till en låt
        {
            AlbumsDAO albumsDAO = new AlbumsDAO(); // Skapar en ny instans av AlbumsDAO
            Album album = new Album(); // Skapar en ny instans av Album

            if (txt_TrackTitel.Text == "" || txt_TrackNumber.Text == "" || txt_VideoURL.Text == "" || txt_Lyrics.Text == "" || txt_AlbumID.Text == "") // Ser till att alla fält är ifyllda
            {
                MessageBox.Show("One or more fields are empty");
                return;
            }

            int Checked = albumsDAO.CheckIfAlbumExsists(int.Parse(txt_AlbumID.Text)); // Kollar om albumet existerar

            if (Checked == int.Parse(txt_AlbumID.Text) && int.Parse(txt_AlbumID.Text) != 0) // Om albumet existerar
            {
                Track track = new Track // Skapar en ny låt
                {
                    Name = txt_TrackTitel.Text,
                    Number = int.Parse(txt_TrackNumber.Text),
                    VideoURL = txt_VideoURL.Text,
                    Lyrics = txt_Lyrics.Text,
                    album = int.Parse(txt_AlbumID.Text),
                };

                int result = albumsDAO.addOneTrack(track); // Lägger till låten
                MessageBox.Show("Added " + result + " rows"); // Skriver ut hur många rader som har lagts till
            }
            else
            {
                MessageBox.Show("Album does not exsist"); // Om albumet inte existerar
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            AlbumsDAO albumsDAO = new AlbumsDAO(); // Skapar en ny instans av AlbumsDAO
            Album album = new Album(); // Skapar en ny instans av Album

            if (txt_TrackTitel.Text == "" || txt_TrackNumber.Text == "" || txt_VideoURL.Text == "" || txt_Lyrics.Text == "" || txt_AlbumID.Text == "") // Ser till att alla fält är ifyllda
            {
                MessageBox.Show("One or more fields are empty");
                return;
            }

            if (trackPressed)
            {
                int rowClicked = dataGridView2.CurrentRow.Index; // Hämtar vilken rad som är klickad
                int Checked = albumsDAO.CheckIfAlbumExsists(int.Parse(txt_AlbumID.Text)); // Kollar om albumet existerar


                if (Checked == int.Parse(txt_AlbumID.Text) && int.Parse(txt_AlbumID.Text) != 0) // Om albumet existerar
                {
                    Track track = new Track // Skapar en ny låt
                    {
                        Name = txt_TrackTitel.Text,
                        Number = int.Parse(txt_TrackNumber.Text),
                        VideoURL = txt_VideoURL.Text,
                        Lyrics = txt_Lyrics.Text,
                        album = int.Parse(txt_AlbumID.Text),
                    };

                    int result = albumsDAO.UpdateTrack(track, (int)dataGridView2.Rows[rowClicked].Cells[0].Value); // Uppdaterar låten

                }
                else
                {
                    MessageBox.Show("Album does not exsist"); // Om albumet inte existerar
                }
            }
            else
            {
                MessageBox.Show("No track selected");
            }
        }

        private void GridClicked(object sender, EventArgs e)
        {
            trackPressed = true;
            MessageBox.Show("true");
        }
    }
}
