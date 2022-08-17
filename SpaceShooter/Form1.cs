using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZInput;
namespace SpaceShooter
{
    public partial class FormMain : Form
    {
        PictureBox pbPlayerShip;
        PictureBox pbEnemyBlack1;
        Random rand=new Random();
        string enemyDirection1 = "moveRight";
        List<PictureBox> playerFires = new List<PictureBox>();
        public FormMain()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                if (pbPlayerShip.Left-30 >= 0)

                {
                    pbPlayerShip.Left = pbPlayerShip.Left - 25;
                }
                
            }
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                if ((pbPlayerShip.Left + pbPlayerShip.Width+50) <=this.Width)
                {
                    pbPlayerShip.Left = pbPlayerShip.Left + 25;
                }
            }
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                PictureBox pbfire = new PictureBox();
                Image img = SpaceShooter.Properties.Resources.laserRed07;
                pbfire.Image = img;
                pbfire.Height = img.Height;
                pbfire.Width = img.Width;
                pbfire.BackColor = Color.Transparent;
                System.Drawing.Point fireLocation = new System.Drawing.Point();
                fireLocation.X = pbPlayerShip.Left + (pbPlayerShip.Width / 2) - 5;
                fireLocation.Y = pbPlayerShip.Top;
                pbfire.Location = fireLocation;
                playerFires.Add(pbfire);
                this.Controls.Add(pbfire);


            }
            foreach(var fire in playerFires)
            {
                if (fire.Bounds.IntersectsWith(pbEnemyBlack1.Bounds))
                {
                    pbEnemyBlack1.Hide();
                    
                }
                fire.Top = fire.Top - 20;
            }
            for(int i = 0; i < playerFires.Count; i++)
            {
                
                if (playerFires[i].Bottom<0)
                {
                    playerFires.Remove(playerFires[i]);
                }
            }
            if ((pbEnemyBlack1.Left + pbEnemyBlack1.Width + 50) > this.Width)
            {
                enemyDirection1 = "moveLeft";
            }
            if(pbEnemyBlack1.Left - 30 <= 0)
            {
                enemyDirection1 = "moveRight";

            }

            if (enemyDirection1 == "moveRight")
            {
                pbEnemyBlack1.Left = pbEnemyBlack1.Left + 5;

            }
            if (enemyDirection1 == "moveLeft")
            {
                pbEnemyBlack1.Left = pbEnemyBlack1.Left - 5;

            }
            


        }
        private void create_pbPlayerShip()
        {
            pbPlayerShip = new PictureBox();
            Image img = SpaceShooter.Properties.Resources.PlayerSpaceShip;
            pbPlayerShip.Image = img;
            pbPlayerShip.Width = img.Width;
            pbPlayerShip.Height = img.Height;
            pbPlayerShip.BackColor = Color.Transparent;
            pbPlayerShip.Left = 10;
            pbPlayerShip.Top = this.Height - (img.Height) -50;
            this.Controls.Add(pbPlayerShip);
        }
        private void create_pbEnemyShip()
        {
            pbEnemyBlack1 = new PictureBox();
            Image img = SpaceShooter.Properties.Resources.enemyRed4;
            pbEnemyBlack1.Image = img;
            pbEnemyBlack1.Width = img.Width;
            pbEnemyBlack1.Height = img.Height;
            pbEnemyBlack1.Width = img.Width;
            pbEnemyBlack1.BackColor = Color.Transparent;
            pbEnemyBlack1.Left =rand.Next(30,this.Width);
            pbEnemyBlack1.Top = rand.Next(5,img.Height+20);
            this.Controls.Add(pbEnemyBlack1);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            create_pbPlayerShip();
            create_pbEnemyShip();
        }
        

    }
}
