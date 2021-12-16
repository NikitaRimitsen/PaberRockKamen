using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaberRockKamen
{


    
    public partial class Form2 : Form
    {
        static string[] kartinkicel = { "kamen.jpg", "noznice.jpg", "bumaga.jpg" };
        static string[] kartinkibot = { "kamen.jpg", "noznice.jpg", "bumaga.jpg" };
        public Random rnd = new Random();  
        

        PictureBox ptb;
        PictureBox ptb2;
        Button btn;
        Label lbl;
        Label lbl2;
        Label lbl3;
        Label lbl4;
        ListBox lb;
        RadioButton rdb;
        RadioButton rdb2;
        RadioButton rdb3;


        public Form2()
        {

            this.Height = 700;//свойство высота формы
            this.Width = 1200;//свойство ширины формы, если это свойство то после, ставится =
            this.Text = "Botiga mängimine";//Text - название, заголовок формы
            this.BackColor = Color.Gainsboro;

            ptb = new PictureBox();//создали PictureBox
            ptb.Size = new Size(300, 200);
            ptb.Location = new Point(70, 100);//(x,y)
            ptb.SizeMode = PictureBoxSizeMode.StretchImage;
            ptb.Image = Image.FromFile(@"..\..\image\vopros.jpg");
            //ptb.CheckedChanged += new EventHandler(Rdb_Click);

            //Добавить свою функцию для изменения картинок

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
            btn.Click += Btn_Click1;

            lbl4 = new Label();// создали Label
            var ctenie = File.ReadLines(@"..\..\image\Nameplayer.txt").Last();
            lbl4.Text = ctenie;
            lbl4.Size = new Size(600, 200);//Size(width,height)
            lbl4.Location = new Point(150, 15); //Point(x,y) - местоположение Label
            lbl4.Font = new Font("Oswald", 16, FontStyle.Bold);

            lbl = new Label();// создали Label
            lbl.Text = "0";
            lbl.Size = new Size(50, 50);//Size(width,height)
            lbl.Location = new Point(170, 60); //Point(x,y) - местоположение Label
            lbl.Font = new Font("Oswald", 16, FontStyle.Bold);


            lbl2 = new Label();// создали Label
            lbl2.Text = "0";
            lbl2.Size = new Size(50, 50);//Size(width,height)
            lbl2.Location = new Point(960, 60); //Point(x,y) - местоположение Label
            lbl2.Font = new Font("Oswald", 16, FontStyle.Bold);

            lbl3 = new Label();// создали Label
            lbl3.Text = "Bot Vasja";
            lbl3.Size = new Size(600, 200);//Size(width,height)
            lbl3.Location = new Point(920, 15); //Point(x,y) - местоположение Label
            lbl3.Font = new Font("Oswald", 16, FontStyle.Bold);

            //RadioButton1
            rdb = new RadioButton();
            rdb.Height = 30;
            rdb.Width = 130;
            rdb.Location = new Point(70, 320);
            rdb.Text = "Kivi";
            rdb.Click += Rdb_Click1;

            //RadioButton2
            rdb2 = new RadioButton();
            rdb2.Height = 30;
            rdb2.Width = 130;
            rdb2.Location = new Point(70, 350);
            rdb2.Text = "Kärid";
            rdb2.Click += Rdb2_Click1;

            //RadioButton3
            rdb3 = new RadioButton();
            rdb3.Height = 30;
            rdb3.Width = 130;
            rdb3.Location = new Point(70, 380);
            rdb3.Text = "Paber";
            rdb3.Click += Rdb3_Click1;



            this.Controls.Add(lb);

            this.Controls.Add(ptb);
            this.Controls.Add(ptb2);
            this.Controls.Add(btn);
            this.Controls.Add(lbl);
            this.Controls.Add(lbl2);
            this.Controls.Add(lbl3);
            this.Controls.Add(lbl4);
            this.Controls.Add(rdb);
            this.Controls.Add(rdb2);
            this.Controls.Add(rdb3);

        }

        private void Rdb3_Click1(object sender, EventArgs e)
        {
            ptb.Image = Image.FromFile(@"..\..\image\" + kartinkicel[2]);
        }

        private void Rdb2_Click1(object sender, EventArgs e)
        {
            ptb.Image = Image.FromFile(@"..\..\image\" + kartinkicel[1]);
        }

        private void Rdb_Click1(object sender, EventArgs e)
        {
            ptb.Image = Image.FromFile(@"..\..\image\" + kartinkicel[0]);
        }

        
        
        
        private void Btn_Click1(object sender, EventArgs e)
        {

            /*if (kartinkicel[0] == kartinkibot[1])
            {
                MessageBox.Show("MessageBox", "Самое обычное окно");
            }*/

        }


        int scetcikcel = 0;
        int scetcikbot = 0;
        private void Btn_Click(object sender, EventArgs e)
        {
            int randombot = rnd.Next(1, 4);
            /*string str1 = scetcik.ToString();
            lbl.Text = str1;*/

            //scetcik++;

            if (randombot == 1)
            {
                //string str1 = scetcik.ToString();
                ptb2.Image = Image.FromFile(@"..\..\image\"+ kartinkibot[0]);
                //lbl.Text = str1;
            }
            else if (randombot == 2)
            {

                ptb2.Image = Image.FromFile(@"..\..\image\"+ kartinkibot[1]);
            }
            else if (randombot == 3)
            {

                ptb2.Image = Image.FromFile(@"..\..\image\" + kartinkibot[2]);
            }

            
            if (rdb.Checked == true && randombot == 2 || rdb2.Checked == true && randombot == 3 || rdb3.Checked == true && randombot == 1)
            {
                scetcikcel++;
                string podcet = scetcikcel.ToString();

                lbl.Text = "";
                lbl.Text = podcet;
                if (scetcikcel == 3)
                {

                    /*string text = Interaction.InputBox("Напиши своё впечатление о погоде", "InputBox", "Mingi tekst");

                    string writePath = @"..\..\image\Nameplayer.txt";

                        using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                        {
                            sw.WriteLine(text);
                        }*/




                    var answer = MessageBox.Show(lbl4.Text + " võita. Restart?", "Tulemus", MessageBoxButtons.YesNo);
                    if (answer == DialogResult.Yes)
                    {
                        Form2 form2 = new Form2();
                        form2.Show();
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
            else if (randombot == 1 && rdb2.Checked == true || randombot == 2 && rdb3.Checked == true || randombot == 3 && rdb.Checked == true)
            {
                scetcikbot++;
                string podcetbot = scetcikbot.ToString();

                lbl2.Text = "";
                lbl2.Text = podcetbot;
                if (scetcikbot == 3)
                {

                    var answer = MessageBox.Show("Bot Vasja võita. Restart?", "Tulemus", MessageBoxButtons.YesNo);
                    if (answer == DialogResult.Yes)
                    {
                        Form2 form2 = new Form2();
                        form2.Show();
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

        //int scetcikkartinok = 0;
        /*private void Ptb_DoubleClick(object sender, EventArgs e)
        {
            //scetcikkartinok++; //тут я увеличиваю значения счетчика на 1
            if (rdb.Checked == true)
            {
                
                //string str1 = scetcik.ToString();
                ptb.Image = Image.FromFile(@"..\..\image\"+ kartinkicel[0]);
                //lbl.Text = str1;
            }
            else if (rdb2.Checked == true)
            {

                ptb.Image = Image.FromFile(@"..\..\image\"+ kartinkicel[1]);
            }
            else if (rdb3.Checked == true)
            {

                //scetcikkartinok = 0; //сбрасывает счетчик, что бы начать все заново
                ptb.Image = Image.FromFile(@"..\..\image\"+ kartinkicel[2]);
            }
        }*/
    }
}
