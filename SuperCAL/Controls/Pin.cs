﻿using System;
using System.Windows.Forms;

namespace SuperCAL
{
    public partial class Pin : UserControl
    {
        public static string UnlockPin = "";
        public static string UnlockMessage = "";
        private string pinBuffer = "";
        public Pin()
        {
            InitializeComponent();
            lblDisplay.Text = UnlockMessage;
        }
        private void TopTimer_Tick(object sender, EventArgs e)
        {
            BringToFront();
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            Button thisButton = (Button)sender;
            lblDisplay.Focus();
            if(thisButton.Text == "Enter")
            {
                if (pinBuffer == UnlockPin)
                {
                    Dispose();
                }
                else
                {
                    Application.Exit();
                }
            }
            else
            {
                pinBuffer += thisButton.Text;
            }
            UpdateDisplay();
        }
        public void Pin_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            e.SuppressKeyPress = true;
            int key;
            if (int.TryParse(e.KeyCode.ToString().Replace("NumPad", "").Replace("D", ""), out key))
            {
                pinBuffer += key.ToString();
                UpdateDisplay();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                btnEnter.PerformClick();
            }
        }
        private void UpdateDisplay()
        {
            string starDisplay = "";
            for(int count = 0; count != pinBuffer.Length; count++)
            {
                starDisplay += '*';
            }
            lblDisplay.Text = starDisplay;
        }
    }
}