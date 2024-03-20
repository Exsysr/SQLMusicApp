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

            albums = albumsDAO.getAllAlbums(); // H�mtar alla album

            abs.DataSource = albums; // Visar albumen i dataGridView1
            dataGridView1.DataSource = abs;


        }

        private void button2_Click(object sender, EventArgs e) // S�ker efter album
        {
            AlbumsDAO albumsDAO = new AlbumsDAO(); // Skapar en ny instans av AlbumsDAO


            // Connect the lists to the grid view control
            abs.DataSource = albumsDAO.searchTitels(textBox1.Text); // S�ker efter album

            dataGridView1.DataSource = abs; // Visar albumen i dataGridView1
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) // Visar albumets bild och l�tar
        {
            DataGridView dataGridView = (DataGridView)sender; // H�mtar dataGridView1

            AlbumsDAO albumsDAO = new AlbumsDAO(); // Skapar en ny instans av AlbumsDAO

            int rowClicked = dataGridView.CurrentRow.Index; // H�mtar vilken rad som �r klickad

            if (dataGridView.Rows[rowClicked].Cells[4].Value == null) // Om det inte finns n�gon bild att visa
            {
                return;
            }

            string imageUrl = dataGridView.Rows[rowClicked].Cells[4].Value.ToString(); // H�mtar ImageURL fr�n en cell i dataGridView1
            pictureBox1.Load(imageUrl); // Visar ImageURL i en pictureBox

            tbs.DataSource = albums[rowClicked].Tracks; // Visar l�tarna i dataGridView2

            dataGridView2.DataSource = tbs; // Visar l�tarna i dataGridView2

            if (dataGridView.Rows[rowClicked].Cells[0].Value == null) // Om det inte finns n�got album att ta bort
            {
                MessageBox.Show("No");
                return;
            }
            int albumID = albums[rowClicked].ID; // H�mtar AlbumID fr�n en cell i dataGridView1
            int numberOfTracks = albumsDAO.TrackCount(albumID); // H�mtar antalet l�tar i albumet

            if (numberOfTracks > 0) // Om det finns l�tar i albumet
            {
                button4.Enabled = true;
            }

        }

        private void button3_Click(object sender, EventArgs e) // L�gger till ett album
        {
            if (txt_AlbumName.Text == "" || txt_Artist.Text == "" || txt_Year.Text == "" || txt_ImageURL.Text == "" || txt_Description.Text == "") // Ser till att alla f�lt �r ifyllda
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
            int result = albumsDAO.addOneAlbum(album); // L�gger till albumet
            MessageBox.Show("Added " + result + " rows"); // Skriver ut hur m�nga rader som har lagts till
        }

        private void button4_Click(object sender, EventArgs e) // Tar bort en l�t
        {
            AlbumsDAO albumsDAO = new AlbumsDAO(); // Skapar en ny instans av AlbumsDAO

            int rowClicked2 = dataGridView2.CurrentRow.Index; // H�mtar vilken rad som �r klickad
            if (dataGridView2.Rows[rowClicked2].Cells[0].Value == null) // Om det inte finns n�gon l�t att ta bort
            {
                MessageBox.Show("No");
                return;
            }
            int trackID = int.Parse(dataGridView2.Rows[rowClicked2].Cells[0].Value.ToString()); // H�mtar TrackID fr�n en cell i dataGridView2

            albumsDAO.deleteOneTrack(trackID); // Tar bort l�ten

            dataGridView2.DataSource = null; // T�mmer dataGridView2

            albums = albumsDAO.getAllAlbums(); // H�mtar alla album

            button4.Enabled = false; // G�r knappen oanv�ndbar 
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) // Visar en video i en webview
        {
            DataGridView dataGridView = (DataGridView)sender; // H�mtar dataGridView2

            int rowClicked = dataGridView.CurrentRow.Index; // H�mtar vilken rad som �r klickad

            String VideoURL = dataGridView.Rows[rowClicked].Cells[3].Value.ToString(); // H�mtar VideoURL fr�n en cell i dataGridView2

            webView21.Source = new Uri(VideoURL); // Visar VideoURL i en webview
        }

        private void button5_Click(object sender, EventArgs e) // Legger Till en l�t
        {
            AlbumsDAO albumsDAO = new AlbumsDAO(); // Skapar en ny instans av AlbumsDAO
            Album album = new Album(); // Skapar en ny instans av Album

            if (txt_TrackTitel.Text == "" || txt_TrackNumber.Text == "" || txt_VideoURL.Text == "" || txt_Lyrics.Text == "" || txt_AlbumID.Text == "") // Ser till att alla f�lt �r ifyllda
            {
                MessageBox.Show("One or more fields are empty");
                return;
            }

            int Checked = albumsDAO.CheckIfAlbumExsists(int.Parse(txt_AlbumID.Text)); // Kollar om albumet existerar

            if (Checked == int.Parse(txt_AlbumID.Text) && int.Parse(txt_AlbumID.Text) != 0) // Om albumet existerar
            {
                Track track = new Track // Skapar en ny l�t
                {
                    Name = txt_TrackTitel.Text,
                    Number = int.Parse(txt_TrackNumber.Text),
                    VideoURL = txt_VideoURL.Text,
                    Lyrics = txt_Lyrics.Text,
                    album = int.Parse(txt_AlbumID.Text),
                };

                int result = albumsDAO.addOneTrack(track); // L�gger till l�ten
                MessageBox.Show("Added " + result + " rows"); // Skriver ut hur m�nga rader som har lagts till
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

            if (txt_TrackTitel.Text == "" || txt_TrackNumber.Text == "" || txt_VideoURL.Text == "" || txt_Lyrics.Text == "" || txt_AlbumID.Text == "") // Ser till att alla f�lt �r ifyllda
            {
                MessageBox.Show("One or more fields are empty");
                return;
            }

            if (trackPressed)
            {
                int rowClicked = dataGridView2.CurrentRow.Index; // H�mtar vilken rad som �r klickad
                int Checked = albumsDAO.CheckIfAlbumExsists(int.Parse(txt_AlbumID.Text)); // Kollar om albumet existerar


                if (Checked == int.Parse(txt_AlbumID.Text) && int.Parse(txt_AlbumID.Text) != 0) // Om albumet existerar
                {
                    Track track = new Track // Skapar en ny l�t
                    {
                        Name = txt_TrackTitel.Text,
                        Number = int.Parse(txt_TrackNumber.Text),
                        VideoURL = txt_VideoURL.Text,
                        Lyrics = txt_Lyrics.Text,
                        album = int.Parse(txt_AlbumID.Text),
                    };

                    int result = albumsDAO.UpdateTrack(track, (int)dataGridView2.Rows[rowClicked].Cells[0].Value); // Uppdaterar l�ten

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
