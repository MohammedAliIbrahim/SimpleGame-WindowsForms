using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsGame
{
    public partial class Form1 : Form
    {
        int x = 100;
        int y;
        int w = 10;
        int h = 20;
        int wM = 0;
        int hM = 0;
        int xM=0;
        int yM=0;
        bool isFired = true;
        int xE;
        int yE;

        public Form1()
        {
            InitializeComponent();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //    y=  this.Height/2;
            Random rnd = new Random();
            //    rnd.Next(1, 13);
          //  y = y;
            y = (this.Height / 2) + this.Height / 3;
            yE = 0;
            xE= rnd.Next( this.Width);
        }

        

        private void paint(object sender, PaintEventArgs e)
        {

            
            // Get the graphics object for the event
            Graphics g = e.Graphics;
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
            // Fill in the rectangle
            //********
            //     g.FillRectangle(bru, x, y, 10, 20);
            // Draw part of a pie
            //   g.FillPie(new SolidBrush(Color.Green), 130, 20, 100, 100, 30, 60);



            // ************

            Rectangle rect = new Rectangle(x ,  y, w, h);
            g.DrawRectangle(red, rect);

           
                //xM = x + (w / 2);
                //yM = y - (h / 2);
           
           
            Rectangle lineRect = new Rectangle(xM , yM , wM, hM);
            g.DrawRectangle(green, lineRect);


            Rectangle rockRect = new Rectangle(xE, yE, w+30, h+30);
            g.FillRectangle(bru, rockRect);

            if (rect.IntersectsWith(rockRect)==true)
            {
                Font bigFont = new Font(SystemFonts.DefaultFont.FontFamily, 17, FontStyle.Regular);
                //  g.DrawString("game over",Font,bru,this.Width/2,this.Height/2);
                g.DrawString("game over", bigFont, bru, this.Width / 2, this.Height / 2);
                timer1.Stop();
            }

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (x >= this.Width) { x = 0; }
          //  x+=2;
          //  y++;
            //h++;
            //w++;
      //   y =( this.Height / 2)+this.Height/3;

            if (isFired == true)
            {
                yM -= 5;
             //   xM -= 3;
        }

            yE++;
            this.Refresh();
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
            switch (e.KeyCode)
            {
                case Keys.Left:
                    x -= 10;
                    break;
                case Keys.Right:
                  
                        x += 10;

                   //     MessageBox.Show(x.ToString());
                    
                    break;

                case Keys.Up:
                    y -= 10;
                  //  MessageBox.Show(y.ToString());
                    break;
                case Keys.Down:
                    y += 10;
                    //if (e.Shift)
                    //{

                    //}
                    //else
                    //{
                    //}
                    break;
                case Keys.Space:

                    isFired = true;
                    wM = 1;
                    hM = h / 2;
                    xM = x + (w / 2);
                    yM = y - (h / 2);
                    break;
            }
        }

    }
}
