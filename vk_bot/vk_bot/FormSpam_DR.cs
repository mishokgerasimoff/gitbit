﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Drawing.Text;


namespace vk_bot
{

    public partial class FormSpam_DR : Form
    {

        private Point mouseOffset;
        private bool isMouseDown = false;



        int r;
        int k;
        string id;
        int qwerty;
        public string access_token;
        string mess;
        public FormSpam_DR()
        {
            InitializeComponent();
        }
        private void FormDR_Load(object sender, EventArgs e)
        {
            fontsProjects();
            fonts();
            Opacity = 0;
            FADERSTART.Start();
        }

        PrivateFontCollection font;
        private void fontsProjects()
        {
            this.font = new PrivateFontCollection();
            this.font.AddFontFile("FONTS/RLL.ttf");
            this.font.AddFontFile("FONTS/WS.ttf");



        }

        private void fonts()
        {
            label1.Font = new Font(font.Families[0], 36);
            label2.Font = new Font(font.Families[0], 20);
            label3.Font = new Font(font.Families[0], 20);
            labelbree.Font = new Font(font.Families[0], 20);
            labelENT.Font = new Font(font.Families[0], 20);
            labelrrr.Font = new Font(font.Families[0], 20);
            buttonSPAM.Font = new Font(font.Families[0], 36);
            textBoxID.Font = new Font(font.Families[0], 24);
            textBoxMess.Font = new Font(font.Families[0], 24);
            numericUpDownqwe.Font = new Font(font.Families[0], 24);
            numericUpDownrr.Font = new Font(font.Families[0], 24);
            Minimize_Button.Font = new Font(font.Families[0], 24);
            Button_Exit.Font = new Font(font.Families[0], 24);
            ORG.Font = new Font(font.Families[0], 24);



        }


        private void webBrowserWWW_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //string url = e.Url.ToString();

            //if (url.Contains("error"))
            //{
            //    MessageBox.Show("Ошибка");
            //}
            //if (url.Contains("access_token"))
            //{
            //    //Выделяю access_token
            //    int IndexAccTok = url.IndexOf("access_token");
            //    access_token = url.Remove(0, IndexAccTok + 13);
            //    int IndexAmp = access_token.IndexOf("&");
            //    access_token = access_token.Remove(IndexAmp);
            //    webBrowserWWW.Visible = false;
            //}

        }

        private void spam_Click(object sender, EventArgs e)
        {

        }

        private void buttonWWW_Click(object sender, EventArgs e)
        {
            //FormDR q = new FormDR();
            //q.Show();
        }

        private void timerQwerty_Tick(object sender, EventArgs e)
        {
            mess = textBoxMess.Text;

            //Зпрашиваю информацию о пользователе

            //Создаю XML документ
            XmlDocument doc = new XmlDocument();
            doc.Load("https://api.vk.com/method/messages.send.xml?user_id="+id+"&message=" + mess + "&access_token=" + access_token + "&v=5.74");
            //XmlNode response = doc.SelectSingleNode("response");
            //XmlNode user = response.SelectSingleNode("user");

            //XmlNode FirstName = user.SelectSingleNode("first_name");
            //labelFirstName.Text = FirstName.InnerText;

            //XmlNode LastName = user.SelectSingleNode("last_name");
            //labelLastName.Text = LastName.InnerText;

            //pictureBoxAvatar.ImageLocation = user.SelectSingleNode("photo_100").InnerText
            qwerty += 1;
            labelbree.Text = qwerty.ToString();
            if(r == qwerty)
            {
                qwerty = 0;
                timerQwerty.Enabled = false;
            }

        }

        private void buttonSPAM_Click(object sender, EventArgs e)
        {
            
            XmlDocument docqwe = new XmlDocument();
            if (textBoxID.Text.Contains("https://vk.com/"))
            {
                id = textBoxID.Text;
                k = id.IndexOf("/");
                id = id.Remove(0, k + 1);
                k = id.IndexOf("/");
                id = id.Remove(0, k + 1);
                k = id.IndexOf("/");
                id = id.Remove(0, k + 1);
                docqwe.Load("https://api.vk.com/method/users.get.xml?user_ids=" + id + "&message=qwerty&access_token=" + access_token + "&v=5.74");
                string url = docqwe.InnerXml.ToString();
                int IndexAccTok = url.IndexOf("<id>");
                id = url.Remove(0, IndexAccTok + 4);
                int IndexAmp = id.IndexOf("</id>");
                id = id.Remove(IndexAmp);
                webBrowserWWW.Visible = false;
                if (1 == 1)
                {
                    int w = Convert.ToInt32(numericUpDownqwe.Text);
                    r = Convert.ToInt32(numericUpDownrr.Text);
                    timerQwerty.Interval = w * 1000;
                    timerQwerty.Enabled = true;
                }
            }
        }

        private void FormDR_Load_1(object sender, EventArgs e)
        {

            Opacity = 0;
            FADERSTART.Start();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Minimize_Button_Click(object sender, EventArgs e)
        {
            FADERMINI.Start();
        }

        private void Button_Exit_Click(object sender, EventArgs e)
        {
            FADER.Start();
        }

        private void FADERSTART_Tick(object sender, EventArgs e)
        {
            Opacity = Opacity += 0.1;
            if (Opacity == 1)
            {

                FADERSTART.Stop();

            }
        }

        private void FADERMINI_Tick(object sender, EventArgs e)
        {
            Opacity = Opacity -= 0.1;
            if (this.Opacity == 0)
            {

                this.WindowState = FormWindowState.Minimized;
                FADERMINI.Stop();
                Opacity = 1;
            }
        }

        private void FADER_Tick(object sender, EventArgs e)
        {
            Opacity = Opacity -= 0.1;
            if (this.Opacity == 0)
            {

                Close();

            }
        }
        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset;
            int yOffset;

            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
                yOffset = -e.Y - SystemInformation.CaptionHeight -
                    SystemInformation.FrameBorderSize.Height;
                mouseOffset = new Point(xOffset, yOffset);
                isMouseDown = true;
            }
        }
        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }
        }
        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }
    }
}
