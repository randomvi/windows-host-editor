using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Quick_Host_Editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            ipinfo.Text = "LOCALHOST IP: 127.0.0.1 \n";
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            string address="C:\\Windows\\System32\\Drivers\\etc\\hosts";
            FileStream fik = new FileStream(address, FileMode.Append, FileAccess.Write);
            StreamWriter hfile = new StreamWriter(fik);
            hfile.WriteLine("\n{0} {1}",iptext.Text,hosttext.Text);
            MessageBox.Show("Saved successfully");
            hfile.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           iptext.Clear();
           hosttext.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please make sure your hosts file \n is allowed to be edited by an application");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IPHostEntry hoster;
            string localIpAddress = "";
            hoster = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in hoster.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIpAddress = ip.ToString();
                    ipinfo.Text = "IP Address :  " + localIpAddress;
                }
            }
            if (localIpAddress == "127.0.0.1")
            {
                MessageBox.Show("Please Check your WiFi");
            }
        }

        

        

    }
}
