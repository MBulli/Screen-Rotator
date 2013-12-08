using Magic.Samples.DisplaySettings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenRotator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            if (!UACHelper.IsAdministrator())
                buttonBlockInput.Image = UACHelper.GetUACShieldIcon();
            else
                buttonBlockInput.Image = Properties.Resources.Lock;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            ShowWindow();
        }

        public void ShowWindow()
        {
            this.BringToFront();
            this.Activate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ScreenRotator.SetScreenOrientation(ScreenOrientation.Angle0);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ScreenRotator.SetScreenOrientation(ScreenOrientation.Angle90);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ScreenRotator.SetScreenOrientation(ScreenOrientation.Angle180);
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ScreenRotator.SetScreenOrientation(ScreenOrientation.Angle270);
            this.Close();
        }

        private void buttonBlockInput_Click(object sender, EventArgs e)
        {
            ScreenRotator.BlockInput();
            this.WindowState = FormWindowState.Minimized;
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
