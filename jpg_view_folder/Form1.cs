using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.IO;


namespace jpg_view_folder
{


    public partial class Form1 : Form
    {

        int size_diff = 0;
        int save_x;
        int save_y;
        public Form1()
        {
            InitializeComponent();
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            save_x = pictureBox1.Width;
            save_y = pictureBox1.Height;

            openFileDialog1.Filter = "JPEGファイル|*.jpg";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                //ファイルパスをテキストボックスに入れる
                textBox1.Text = openFileDialog1.FileName;
                pictureBox1.Width = int.Parse(textBox5.Text);
                pictureBox1.Height = int.Parse(textBox6.Text); ;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.ImageLocation = textBox1.Text;
            }
            button2_Click(sender, e);
        }
        

        private void button2_Click(object sender, EventArgs e)
        {


            string s = textBox1.Text;
            string s3="";

            s3 = System.IO.Path.GetDirectoryName(s);


            string[] files = System.IO.Directory.GetFiles(
                s3, "*.jpg", System.IO.SearchOption.AllDirectories);

            listBox1.Items.AddRange(files);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            pictureBox2.Visible = false;


            string s = listBox1.Text;

            textBox3.Clear();
            textBox2.Text = s;
            pict_disp();


            var fileName = s+".txt";

//            if (!Directory.Exists("test"))
//                Directory.CreateDirectory("test");

            string fileName2 = string.Format(fileName);




            var encoding = System.Text.Encoding.GetEncoding("UTF-8");

            try
            {
                var reader = new System.IO.StreamReader(fileName, encoding);
                while (!reader.EndOfStream)
                {
                    var record = reader.ReadLine();

                    textBox3.Text = textBox3.Text + record + "\r\n";

                }
                reader.Close();
            }
            catch (Exception)
            {
                textBox3.Text = "";


            }
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = listBox1.Text;


            textBox2.Text = s;
            pict_disp();


            var fileName = s + ".txt";

            if (!Directory.Exists("test"))
                Directory.CreateDirectory("test");

            string fileName2 = string.Format(fileName);



            string contents = string.Format(textBox3.Text);
            File.WriteAllText(fileName2, contents);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        public void pict_disp()


        {
            pictureBox1.Width = int.Parse(textBox5.Text) + size_diff;
            pictureBox1.Height = int.Parse(textBox6.Text) + size_diff;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.ImageLocation = textBox2.Text;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {


                pictureBox2.Visible = true;

            Color col;
            int i, j, nx, ny, r, g, b, aa, bb, cc;



            Bitmap bmp = new Bitmap(pictureBox1.Image);

            nx = bmp.Width;
            ny = bmp.Height;

            if (textBox7.Text == "") { aa = 100; textBox7.Text = "100"; }
            if (textBox8.Text == "") { bb = 100; textBox8.Text = "100"; }
            if (textBox9.Text == "") { cc = 100; textBox9.Text = "100"; }

            aa = int.Parse(textBox7.Text);
            bb = int.Parse(textBox8.Text);
            cc = int.Parse(textBox9.Text);
            for (j = 0; j < ny; j++)
            {
                for (i = 0; i < nx; i++)
                {
                    col = bmp.GetPixel(i, j);
                    r = 255-col.R;
                    g = 255-col.G;
                    b = 255-col.B;
                    bmp.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            pictureBox2.Width = int.Parse(textBox5.Text);
            pictureBox2.Height = int.Parse(textBox6.Text); ;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = bmp;


            }
            catch (Exception)
            {
                MessageBox.Show("写真を表示してください");
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            listBox1_SelectedIndexChanged(sender, e);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            listBox1_SelectedIndexChanged(sender, e);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            size_diff = size_diff + 10;
            listBox1_SelectedIndexChanged(sender, e);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            size_diff = size_diff - 10;
            listBox1_SelectedIndexChanged(sender, e);

        }
    }
}

