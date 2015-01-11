using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
namespace Serial_receive
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       //search button  
        private void button1_Click(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
            }
        }
       /// read button
        string t;
      
        private void button2_Click(object sender, EventArgs e)
        {
             t = comboBox1.Text.ToString();
       
            sErial(t);
           
        }
       //method
        SerialPort sp;
        void sErial(string Port_name)
        {
            sp = new SerialPort(Port_name, 9600, Parity.None, 8, StopBits.One);
            sp.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            sp.Open();

        }
//
        private  void DataReceivedHandler(object sender,SerialDataReceivedEventArgs e)
    {

        SerialPort sp = (SerialPort)sender;
              
                string w = sp.ReadLine();

                //string msg = sp.ReadExisting();
                if (w != String.Empty)
                {
                    Invoke(new Action(() => richTextBox1.AppendText(w)));
                }


               
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.youtube.com/user/omar0103637");
        }
    }
}
