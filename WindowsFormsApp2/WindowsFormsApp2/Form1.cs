using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SerialPort myserialPort;

        //public SerialPort MyserialPort1 { get => myserialPort1; set => myserialPort1 = value; }

        public void button1_Click(object sender, EventArgs e)
        {
            string[] value = SerialHandle.FindPorts(); ;

            textBox1.Text = value[0];
            textBox2.Text = value[1];
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (myserialPort != null)
            {
                char[] array = new char[4];
                myserialPort.ReadTimeout = 10000;

                try
                {
                    array[0] = (char)myserialPort.ReadChar();
                }
                catch (Exception)
                {
                    textBox6.Text = "ReadChar() timeout";
                    myserialPort = SerialHandle.CloseCom(myserialPort);
                }

                string s = new string(array);
                textBox5.Text = s;
            }
            else
            {
                //do nothing
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            myserialPort = SerialHandle.OpenCom(textBox1.Text, myserialPort);
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            myserialPort = SerialHandle.OpenCom(textBox2.Text, myserialPort);
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            myserialPort = SerialHandle.CloseCom(myserialPort);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            //textBox1.Text
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class SerialHandle
    {
        //SerialPort myserialPort;
        //string[] ports_int; 

        static public string[] FindPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            return ports;
        }

        static public SerialPort OpenCom(string com, SerialPort myserialPort)
        {
            if (myserialPort == null)
            {
                myserialPort = new SerialPort(com, 115200);
                myserialPort.Open(); //open the serial port 
                return (myserialPort);
            }
            else
            {
                return myserialPort;
            }
        }

        static public SerialPort CloseCom(SerialPort myserialPort)
        {
            if (myserialPort != null)
            {
                //myserialPort = new SerialPort(com, 115200);
                myserialPort.Close(); //close the serial port 
                                      //myserialPort.
                myserialPort = null;
                return (myserialPort);
            }
            else
            {
                return (myserialPort);
            }
        }

    }

}
