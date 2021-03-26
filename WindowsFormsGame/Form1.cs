using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsGame
{
    public partial class Form1 : Form
    {
        int x = 100;
        int y;
        int w = 50;
        int h = 70;
        int wM = 0;
        int hM = 0;
        int xM=0;
        int yM=0;
        bool isFired = true;
        int xE;
        int yE;
        int yE2;
        int score = 0;
        Random rnd = new Random();
        //plane112
        Bitmap src = new Bitmap("C:/Users/m.ibrahim/Pictures/pl.png");
        //  Bitmap src = new Bitmap("C:/Users/m.ibrahim/Pictures/unnamed.png");
        Bitmap srcr = new Bitmap("C:/Users/m.ibrahim/Pictures/rocket-ship-launch-missile-pngrepo-com.png");
        Bitmap srcE = new Bitmap("C:/Users/m.ibrahim/Pictures/unnamedE.png");
        public Form1()
        {
            InitializeComponent();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //    y=  this.Height/2;
         //   Random rnd = new Random();
            //    rnd.Next(1, 13);
          //  y = y;
            y = (this.Height / 2) + this.Height / 3;
            yE = 0;
            yE2 = 0;
            xE = rnd.Next( this.Width/2);
        }

        

        private void paint(object sender, PaintEventArgs e)
        {

            
            // Get the graphics object for the event
            Graphics g = e.Graphics;



           
           var bmp = new Bitmap(130, 130, PixelFormat.Format32bppPArgb);



       //     var srcr = new Bitmap("C:/Users/m.ibrahim/Pictures/rocket-ship-launch-missile-pngrepo-com.png");
            var bmpr = new Bitmap(100, 100, PixelFormat.Format32bppPArgb);



        //    var srcE = new Bitmap("C:/Users/m.ibrahim/Pictures/unnamedE.png");
            var bmpE = new Bitmap(100, 100, PixelFormat.Format32bppPArgb);
            //   var gr = Graphics.FromImage(bmp);

            //  gr.Clear(Color.Blue);
            //    g.DrawImage(src, new Rectangle(0, 0, bmp.Width, bmp.Height));
            //  bmp.Save("C:/Users/m.ibrahim/Pictures/result111.png", ImageFormat.Png);





            // New pen color
            Pen red = new Pen(Color.Red, 3);
            Pen green = new Pen(Color.Green, 3);
            Pen violet = new Pen(Color.DarkViolet, 3);
            // Draw a rect at Width=50, Height=80 at coordinate 10,20
            //  g.DrawRectangle(red, 10, 20, 50, 80);
            // Ellipse drawn within bounding rectangle at 50,10
            //    g.DrawEllipse(new Pen(Color.Purple), 50, 10, 40, 30);
            // Brush = solid, hatched, texture...
              Brush bru = new SolidBrush(Color.DarkViolet);
            Brush bru2 = new SolidBrush(Color.Brown);
            Brush bru3 = new SolidBrush(Color.Black);
            // Fill in the rectangle
            //********
            //     g.FillRectangle(bru, x, y, 10, 20);
            // Draw part of a pie
            //   g.FillPie(new SolidBrush(Color.Green), 130, 20, 100, 100, 30, 60);



            // ************

            //  Rectangle rect = new Rectangle(x ,  y, w, h);
            Rectangle rect = new Rectangle(x, y, bmp.Width, bmp.Height);
            g.DrawImage(src, rect);
        //    g.DrawRectangle(red, rect);

           
                //xM = x + (w / 2);
                //yM = y - (h / 2);
           
           //************
            //Rectangle lineRect = new Rectangle(xM , yM , wM, hM);
            //g.DrawRectangle(green, lineRect);
            Rectangle lineRect = new Rectangle(xM, yM, wM, hM);
            g.DrawImage(srcr, lineRect);

            //***********


            Rectangle rockRect = new Rectangle(xE, yE, 50, 70);
            Rectangle rockRect2 = new Rectangle(2*xE, yE2, 45, 75);


            g.DrawImage(srcE, rockRect);
            g.DrawImage(srcE, rockRect2);
            //g.FillRectangle(bru, rockRect);
            //g.FillRectangle(bru, rockRect2);


            //********
            Font scoreFont = new Font(SystemFonts.DefaultFont.FontFamily, 11, FontStyle.Regular);

            g.DrawString("score : "+score, scoreFont, bru3,this.Width-100,5);

            if (rect.IntersectsWith(rockRect)==true)
            {
                Font bigFont = new Font(SystemFonts.DefaultFont.FontFamily, 17, FontStyle.Regular);
                //  g.DrawString("game over",Font,bru,this.Width/2,this.Height/2);
                g.FillRectangle(bru2, rockRect);
                g.DrawString("game over", bigFont, bru, this.Width / 2, this.Height / 2);
                timer1.Stop();
            }
            if (rect.IntersectsWith(rockRect2) == true)
            {
                Font bigFont = new Font(SystemFonts.DefaultFont.FontFamily, 17, FontStyle.Regular);

                g.FillRectangle(bru2, rockRect2);

                //  g.DrawString("game over",Font,bru,this.Width/2,this.Height/2);
                g.DrawString("game over", bigFont, bru, this.Width / 2, this.Height / 2);
                timer1.Stop();
            }

            if (lineRect.IntersectsWith(rockRect) == true)
            {
                yE = -100;
               xE= rnd.Next(this.Width / 2);
                g.FillRectangle(bru2, rockRect);
              //  System.Media.SystemSounds.Hand.Play();
                //  rockRect.Inflate(10, 10);
                //  Font bigFont = new Font(SystemFonts.DefaultFont.FontFamily, 17, FontStyle.Regular);
                //  g.DrawString("game over",Font,bru,this.Width/2,this.Height/2);
                //   g.DrawString("game over", bigFont, bru, this.Width / 2, this.Height / 2);
                //  timer1.Stop();
                score++;
            }

            if (lineRect.IntersectsWith(rockRect2) == true)
            {
                yE2 = -50;
                xE = rnd.Next(this.Width / 2);
                g.FillRectangle(bru2, rockRect2);
           //     System.Media.SystemSounds.Question.Play();
                //  rockRect.Inflate(10, 10);
                //  Font bigFont = new Font(SystemFonts.DefaultFont.FontFamily, 17, FontStyle.Regular);
                //  g.DrawString("game over",Font,bru,this.Width/2,this.Height/2);
                //   g.DrawString("game over", bigFont, bru, this.Width / 2, this.Height / 2);
                //  timer1.Stop();
                score++;
            }

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (x >= this.Width) { x = 0; }


            if (yE >= this.Height) { yE = 0;

                xE = rnd.Next(this.Width / 2);
            }
            if (yE2 >= this.Height) { yE2 = 0;
                xE = rnd.Next(this.Width / 2);
            }
            //  x+=2;
            //  y++;
            //h++;
            //w++;
            //   y =( this.Height / 2)+this.Height/3;

            if (isFired == true)
            {
                yM -= 20;
             //   xM -= 3;
        }

            yE+=3;
            yE2+=3;
            this.Refresh();
           // Invalidate();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Space) // space click
            //{

            //    isFired = true;
            //    wM = 1;
            //    hM = h / 2;
            //    xM = x + (w / 2);
            //    yM = y - (h / 2);
            //    // MessageBox.Show("hi");
            //}

            //if (e.KeyChar == (char)Keys.Right) // space click
            //{
            //    x += 10;

            //    MessageBox.Show(x.ToString());
            //}
        }

        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Right:
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Space:
                    return true;
                case Keys.Shift | Keys.Right:
                case Keys.Shift | Keys.Left:
                case Keys.Shift | Keys.Up:
                case Keys.Shift | Keys.Down:
                    return true;
                
            }
            return base.IsInputKey(keyData);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Space)
            {

                isFired = true;
                //  wM = 1;
                wM = 25;
                hM = h / 2;
                xM = x + (w / 2);
                yM = y - (h / 2);

            }
            switch (e.KeyCode)
            {
                case Keys.Left:
                    x -= 20;
                    break;
                case Keys.Right:
                  
                        x += 20;

                   //     MessageBox.Show(x.ToString());
                    
                    break;

                case Keys.Up:
                    y -= 20;
                  //  MessageBox.Show(y.ToString());
                    break;
                case Keys.Down:
                    y += 20;
                    //if (e.Shift)
                    //{

                    //}
                    //else
                    //{
                    //}
                    break;
                //case Keys.Space:

                //    isFired = true;
                //    //  wM = 1;
                //    wM = 25;
                //    hM = h / 2;
                //    xM = x + (w / 2);
                //    yM = y - (h / 2);
                //    break;
                case Keys.Enter:

                    //  this.Refresh();
                    this.Hide();
                    Form1 frm1 = new Form1();
                    frm1.Show();
                  //  this.Close();
                 //   Dispose();
                    // Invalidate();
                    //  timer1.Start();

                    break;
            }
        }

    }
}
