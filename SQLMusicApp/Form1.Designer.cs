namespace SQLMusicApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            textBox1 = new TextBox();
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            button3 = new Button();
            txt_Description = new TextBox();
            txt_ImageURL = new TextBox();
            txt_Year = new TextBox();
            txt_Artist = new TextBox();
            txt_AlbumName = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label6 = new Label();
            dataGridView2 = new DataGridView();
            button4 = new Button();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            groupBox2 = new GroupBox();
            button6 = new Button();
            txt_Lyrics = new TextBox();
            txt_TrackNumber = new TextBox();
            txt_TrackTitel = new TextBox();
            txt_VideoURL = new TextBox();
            txt_AlbumID = new TextBox();
            button5 = new Button();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(269, 12);
            button1.Name = "button1";
            button1.Size = new Size(87, 23);
            button1.TabIndex = 0;
            button1.Text = "Load Albums";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(269, 41);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(643, 200);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // button2
            // 
            button2.Location = new Point(581, 12);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Search";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(362, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(213, 23);
            textBox1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(918, 41);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 200);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(txt_Description);
            groupBox1.Controls.Add(txt_ImageURL);
            groupBox1.Controls.Add(txt_Year);
            groupBox1.Controls.Add(txt_Artist);
            groupBox1.Controls.Add(txt_AlbumName);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 41);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(251, 200);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add Album";
            // 
            // button3
            // 
            button3.Location = new Point(90, 171);
            button3.Name = "button3";
            button3.Size = new Size(155, 23);
            button3.TabIndex = 10;
            button3.Text = "Add";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // txt_Description
            // 
            txt_Description.Location = new Point(90, 137);
            txt_Description.Name = "txt_Description";
            txt_Description.Size = new Size(155, 23);
            txt_Description.TabIndex = 9;
            // 
            // txt_ImageURL
            // 
            txt_ImageURL.Location = new Point(90, 108);
            txt_ImageURL.Name = "txt_ImageURL";
            txt_ImageURL.Size = new Size(155, 23);
            txt_ImageURL.TabIndex = 8;
            // 
            // txt_Year
            // 
            txt_Year.Location = new Point(90, 79);
            txt_Year.Name = "txt_Year";
            txt_Year.Size = new Size(155, 23);
            txt_Year.TabIndex = 7;
            // 
            // txt_Artist
            // 
            txt_Artist.Location = new Point(90, 50);
            txt_Artist.Name = "txt_Artist";
            txt_Artist.Size = new Size(155, 23);
            txt_Artist.TabIndex = 6;
            // 
            // txt_AlbumName
            // 
            txt_AlbumName.Location = new Point(90, 21);
            txt_AlbumName.Name = "txt_AlbumName";
            txt_AlbumName.Size = new Size(155, 23);
            txt_AlbumName.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 140);
            label5.Name = "label5";
            label5.Size = new Size(67, 15);
            label5.TabIndex = 4;
            label5.Text = "Description";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 111);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 3;
            label4.Text = "ImageURL";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 82);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 2;
            label3.Text = "Year";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 53);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 1;
            label2.Text = "Artist";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 24);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 0;
            label1.Text = "Album Name";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(780, 251);
            label6.Name = "label6";
            label6.Size = new Size(39, 15);
            label6.TabIndex = 6;
            label6.Text = "Tracks";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(269, 276);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(643, 200);
            dataGridView2.TabIndex = 7;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            dataGridView2.Click += GridClicked;
            // 
            // button4
            // 
            button4.Enabled = false;
            button4.Location = new Point(825, 247);
            button4.Name = "button4";
            button4.Size = new Size(87, 23);
            button4.TabIndex = 8;
            button4.Text = "Delet Track";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(918, 276);
            webView21.Name = "webView21";
            webView21.Size = new Size(200, 200);
            webView21.TabIndex = 9;
            webView21.ZoomFactor = 0.5D;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button6);
            groupBox2.Controls.Add(txt_Lyrics);
            groupBox2.Controls.Add(txt_TrackNumber);
            groupBox2.Controls.Add(txt_TrackTitel);
            groupBox2.Controls.Add(txt_VideoURL);
            groupBox2.Controls.Add(txt_AlbumID);
            groupBox2.Controls.Add(button5);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Location = new Point(12, 276);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(251, 200);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Add Track";
            // 
            // button6
            // 
            button6.Location = new Point(6, 171);
            button6.Name = "button6";
            button6.Size = new Size(81, 23);
            button6.TabIndex = 11;
            button6.Text = "Update";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // txt_Lyrics
            // 
            txt_Lyrics.Location = new Point(90, 108);
            txt_Lyrics.Name = "txt_Lyrics";
            txt_Lyrics.Size = new Size(155, 23);
            txt_Lyrics.TabIndex = 10;
            // 
            // txt_TrackNumber
            // 
            txt_TrackNumber.Location = new Point(90, 50);
            txt_TrackNumber.Name = "txt_TrackNumber";
            txt_TrackNumber.Size = new Size(155, 23);
            txt_TrackNumber.TabIndex = 9;
            // 
            // txt_TrackTitel
            // 
            txt_TrackTitel.Location = new Point(90, 21);
            txt_TrackTitel.Name = "txt_TrackTitel";
            txt_TrackTitel.Size = new Size(155, 23);
            txt_TrackTitel.TabIndex = 8;
            // 
            // txt_VideoURL
            // 
            txt_VideoURL.Location = new Point(90, 79);
            txt_VideoURL.Name = "txt_VideoURL";
            txt_VideoURL.Size = new Size(155, 23);
            txt_VideoURL.TabIndex = 7;
            // 
            // txt_AlbumID
            // 
            txt_AlbumID.Location = new Point(90, 137);
            txt_AlbumID.Name = "txt_AlbumID";
            txt_AlbumID.Size = new Size(155, 23);
            txt_AlbumID.TabIndex = 6;
            // 
            // button5
            // 
            button5.Location = new Point(90, 171);
            button5.Name = "button5";
            button5.Size = new Size(155, 23);
            button5.TabIndex = 5;
            button5.Text = "Add";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(6, 140);
            label11.Name = "label11";
            label11.Size = new Size(57, 15);
            label11.TabIndex = 4;
            label11.Text = "Album ID";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 111);
            label10.Name = "label10";
            label10.Size = new Size(36, 15);
            label10.TabIndex = 3;
            label10.Text = "Lyrics";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 82);
            label9.Name = "label9";
            label9.Size = new Size(61, 15);
            label9.TabIndex = 2;
            label9.Text = "Video URL";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 53);
            label8.Name = "label8";
            label8.Size = new Size(81, 15);
            label8.TabIndex = 1;
            label8.Text = "Track Number";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 24);
            label7.Name = "label7";
            label7.Size = new Size(59, 15);
            label7.TabIndex = 0;
            label7.Text = "Track Titel";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1123, 480);
            Controls.Add(groupBox2);
            Controls.Add(webView21);
            Controls.Add(button4);
            Controls.Add(dataGridView2);
            Controls.Add(label6);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private DataGridView dataGridView1;
        private Button button2;
        private TextBox textBox1;
        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private Label label1;
        private Label label3;
        private Label label2;
        private TextBox txt_Artist;
        private TextBox txt_AlbumName;
        private Label label5;
        private Label label4;
        private TextBox txt_Description;
        private TextBox txt_ImageURL;
        private TextBox txt_Year;
        private Button button3;
        private Label label6;
        private DataGridView dataGridView2;
        private Button button4;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private GroupBox groupBox2;
        private Label label9;
        private Label label8;
        private Label label7;
        private TextBox txt_Lyrics;
        private TextBox txt_TrackNumber;
        private TextBox txt_TrackTitel;
        private TextBox txt_VideoURL;
        private TextBox txt_AlbumID;
        private Button button5;
        private Label label11;
        private Label label10;
        private Button button6;
    }
}
