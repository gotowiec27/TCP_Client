using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
namespace TCP_Client
{
    public partial class Form1 : Form
    {
        TcpClient klient;
        bool is_clicked = false;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void send_button_Click(object sender, EventArgs e)
        {

            if (!is_clicked)
            {
                
                string host = ip_box.Text;
                int port = System.Convert.ToInt16(port_box.Value);
                try
                {
                    klient = new TcpClient(host, port);
                    listBox1.Items.Add("Nawiązano połączenie z " + host + " na porcie:" + port);
                    is_clicked = true;
                    send_button.Text = "Disconnect";
                }

                catch (Exception ex)
                {
                    listBox1.Items.Add("Błąd: Nie udało się nawiązać połączenia!");
                }

            }
            else
            {

                klient.Close();
                listBox1.Items.Add("Zakończono połączenie.");
                is_clicked = false;
                send_button.Text = "Connect";
            }
            
        }
    }
}
