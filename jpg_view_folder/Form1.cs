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
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                //ファイルパスをテキストボックスに入れる
                textBox1.Text = openFileDialog1.FileName;
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
            string s = listBox1.Text; 


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

                    textBox3.Text = record;
                }
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
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.ImageLocation = textBox2.Text;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

