using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaberRockKamen
{
    public partial class BotvsBot : Form
    {

        static string[] kartinkibot1 = { "kamen.jpg", "noznice.jpg", "bumaga.jpg" };
        static string[] kartinkibot2 = { "kamen.jpg", "noznice.jpg", "bumaga.jpg" };
        public Random rnd = new Random();


        PictureBox ptb;
        PictureBox ptb2;
        Button btn;
        Label lbl;
        Label lbl2;
        Label lbl3;
        Label lbl4;
        ListBox lb;

        public BotvsBot()
        {
            this.Height = 700;//свойство высота формы
            this.Width = 1200;//свойство ширины формы, если это свойство то после, ставится =
            this.Text = "Botiga mängimine";//Text - название, заголовок формы
            this.BackColor = Color.Gainsboro;

            MainMenu menu = new MainMenu();
            MenuItem menuFile = new MenuItem("Seaded");
            menuFile.MenuItems.Add("Teema", new EventHandler(menuFile_Tema_Select)).Shortcut = Shortcut.CtrlS;
            menuFile.MenuItems.Add("Audio", new EventHandler(menuFile_Zvuk_Select)).Shortcut = Shortcut.CtrlP;
            menuFile.MenuItems.Add("Mängu reeglid", new EventHandler(menureeglid_Tema_Select));
            menuFile.MenuItems.Add("Tagasi", new EventHandler(menuFile_Tagasi_Select)).Shortcut = Shortcut.CtrlX;
            //menuFile.MenuItems.Add("Размер", new EventHandler());
            //menuFile.MenuItems.Add("Postimees", new EventHandler());
            menu.MenuItems.Add(menuFile);

            this.Menu = menu;

            ptb = new PictureBox();//создали PictureBox
            ptb.Size = new Size(300, 200);
            ptb.Location = new Point(70, 100);//(x,y)
            ptb.SizeMode = PictureBoxSizeMode.StretchImage;
            ptb.Image = Image.FromFile(@"..\..\image\vopros.jpg");

            ptb2 = new PictureBox();//создали PictureBox
            ptb2.Size = new Size(300, 200);
            ptb2.Location = new Point(830, 100);//(x,y)
            ptb2.SizeMode = PictureBoxSizeMode.StretchImage;
            ptb2.Image = Image.FromFile(@"..\..\image\vopros.jpg");


            btn = new Button();
            btn.BackColor = Color.Honeydew;//фон кнопки
            btn.Text = "Start";//текст внутри кнопки
            btn.Location = new Point(500, 100);//Point(x,y) - местоположение кнопки
            btn.Height = 60;//высота кнопки
            btn.Width = 180;//ширина кнопки
            btn.Click += Btn_Click;


            lbl = new Label();// создали Label
            lbl.Text = "Bot Ivan";
            lbl.Size = new Size(600, 200);//Size(width,height)
            lbl.Location = new Point(150, 25); //Point(x,y) - местоположение Label
            lbl.Font = new Font("Oswald", 16, FontStyle.Bold);

            lbl2 = new Label();// создали Label
            lbl2.Text = "Bot Vasja";
            lbl2.Size = new Size(600, 200);//Size(width,height)
            lbl2.Location = new Point(920, 25); //Point(x,y) - местоположение Label
            lbl2.Font = new Font("Oswald", 16, FontStyle.Bold);

            lbl3 = new Label();// создали Label
            lbl3.Text = "0";
            lbl3.Size = new Size(600, 200);//Size(width,height)
            lbl3.Location = new Point(190, 400); //Point(x,y) - местоположение Label
            lbl3.Font = new Font("Oswald", 16, FontStyle.Bold);

            lbl4 = new Label();// создали Label
            lbl4.Text = "0";
            lbl4.Size = new Size(600, 200);//Size(width,height)
            lbl4.Location = new Point(960, 400); //Point(x,y) - местоположение Label
            lbl4.Font = new Font("Oswald", 16, FontStyle.Bold);



            this.Controls.Add(ptb);
            this.Controls.Add(ptb2);
            this.Controls.Add(btn);
            this.Controls.Add(lbl);
            this.Controls.Add(lbl2);
            this.Controls.Add(lbl3);
            this.Controls.Add(lbl4);
            this.Controls.Add(lb);
        }

        private void menureeglid_Tema_Select(object sender, EventArgs e)
        {
            var reglid = File.ReadAllText(@"..\..\image\reeglid.txt");
            var mangureglid = MessageBox.Show(reglid, "Mängu reeglid");
        }

        int scetcikzvuk = 0;
        private void menuFile_Zvuk_Select(object sender, EventArgs e)
        {
            scetcikzvuk++;
            if (scetcikzvuk == 1)
            {
                using (var soundPlayer = new SoundPlayer(@"../../sound/muzekaigraofficial.wav"))
                {
                    soundPlayer.Stop();
                }
            }
            else if (scetcikzvuk == 2)
            {
                using (var soundPlayer = new SoundPlayer(@"../../sound/muzekaigraofficial.wav"))
                {
                    soundPlayer.Play();
                }
                scetcikzvuk = 0;
            }
        }

        int scetcik = 0;
        private void menuFile_Tema_Select(object sender, EventArgs e)
        {
            scetcik++;
            if (scetcik == 1)
            {
                this.BackColor = Color.Black;
                lbl.ForeColor = Color.White;
                lbl2.ForeColor = Color.White;
                lbl3.ForeColor = Color.White;
                lbl4.ForeColor = Color.White;
                btn.ForeColor = Color.Black;
                btn.BackColor = Color.White;
            }
            else if (scetcik == 2)
            {
                this.BackColor = Color.White;
                lbl.ForeColor = Color.Black;
                lbl2.ForeColor = Color.Black;
                lbl3.ForeColor = Color.Black;
                lbl4.ForeColor = Color.Black;

                btn.ForeColor = Color.White;
                btn.BackColor = Color.Black;
            }
            else if (scetcik == 3)
            {
                this.BackColor = Color.Gainsboro;
                lbl.ForeColor = Color.Black;
                lbl2.ForeColor = Color.Black;
                lbl3.ForeColor = Color.Black;
                lbl4.ForeColor = Color.Black;
                btn.ForeColor = Color.Black;
                btn.BackColor = Color.Honeydew;

                scetcik = 0;
            }
        }

        private void menuFile_Tagasi_Select(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        int scetcikIvan = 0;
        int scetcikVasja = 0;
        private void Btn_Click(object sender, EventArgs e)
        {
            int randombot1 = rnd.Next(1, 4);
            int randombot2 = rnd.Next(1, 4);

            if (randombot1 == 1)
            {
                ptb.Image = Image.FromFile(@"..\..\image\" + kartinkibot1[0]);
            }
            else if (randombot1 == 2)
            {

                ptb.Image = Image.FromFile(@"..\..\image\" + kartinkibot1[1]);
            }
            else if (randombot1 == 3)
            {

                ptb.Image = Image.FromFile(@"..\..\image\" + kartinkibot1[2]);
            }

            if (randombot2 == 1)
            {
                //string str1 = scetcik.ToString();
                ptb2.Image = Image.FromFile(@"..\..\image\" + kartinkibot2[0]);
                //lbl.Text = str1;
            }
            else if (randombot2 == 2)
            {

                ptb2.Image = Image.FromFile(@"..\..\image\" + kartinkibot2[1]);
            }
            else if (randombot2 == 3)
            {

                ptb2.Image = Image.FromFile(@"..\..\image\" + kartinkibot2[2]);
            }

            
            if (randombot1==1 && randombot2==2 || randombot1==2 && randombot2== 3 || randombot1 == 3 && randombot2 == 1)
            {
                scetcikIvan++;
                string str1 = scetcikIvan.ToString();
                
                lbl3.Text = "";
                lbl3.Text = str1;
                if (scetcikIvan==3)
                {
                    using (StreamWriter srb = new StreamWriter(@"..\..\image\Rezultat.txt", true))
                    {
                        srb.WriteLine("Bot Ivan võita");
                    }

                    var answer = MessageBox.Show("Bot Ivan võita. Restart?", "Tulemus", MessageBoxButtons.YesNo);
                    if (answer == DialogResult.Yes)
                    {
                        BotvsBot botvsBot = new BotvsBot();
                        botvsBot.Show();
                        this.Hide();
                    }
                    else
                    {
                        Form1 form1 = new Form1();
                        form1.Show();
                        this.Hide();
                    }

                }
            }
            else if (randombot2 == 1 && randombot1 == 2 || randombot2 == 2 && randombot1 == 3 || randombot2 == 3 && randombot1 == 1)
            {
                scetcikVasja++;
                string str2 = scetcikVasja.ToString();
                lbl4.Text = "";
                lbl4.Text = str2;
                if (scetcikVasja==3)
                {
                    using (StreamWriter srb = new StreamWriter(@"..\..\image\Rezultat.txt", true))
                    {
                        srb.WriteLine("Bot Vasja võita");
                    }

                    var answer = MessageBox.Show("Bot Vasja võita. Restart?", "Tulemus", MessageBoxButtons.YesNo);
                    if (answer == DialogResult.Yes)
                    {
                        BotvsBot botvsBot = new BotvsBot();
                        botvsBot.Show();
                        this.Hide();
                    }
                    else
                    {
                        Form1 form1 = new Form1();
                        form1.Show();
                        this.Hide();
                    }

                }
            }



        }

        /*int scetcikkartinok = 0;
        private void Ptb_DoubleClick(object sender, EventArgs e)
        {
            scetcikkartinok++; //тут я увеличиваю значения счетчика на 1
            if (scetcikkartinok == 1)
            {

                //string str1 = scetcik.ToString();
                ptb.Image = Image.FromFile(@"..\..\image\" + kartinkibot1[0]);
                //lbl.Text = str1;
            }
            else if (scetcikkartinok == 2)
            {

                ptb.Image = Image.FromFile(@"..\..\image\" + kartinkibot1[1]);
            }
            else if (scetcikkartinok == 3)
            {

                scetcikkartinok = 0; //сбрасывает счетчик, что бы начать все заново
                ptb.Image = Image.FromFile(@"..\..\image\" + kartinkibot1[2]);
            }
        }*/
    }
}
