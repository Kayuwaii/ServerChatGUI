using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ServerChatGUI
{
    public partial class Form1 : Form
    {
        public Timer timer1;
        public TcpListener myList = null;

        public string EncryptionKey = GetHashedKey("Alexandros");

        public Form1()
        {
            InitializeComponent();
            try
            {
                IPAddress ipAd = IPAddress.Parse("172.17.1.241");
                // use local m/c IP address, and 
                // use the same in the client

                /* Initializes the Listener */
                myList = new TcpListener(ipAd, 8001);

                /* Start Listeneting at the specified port */
                myList.Start();


                Socket s = myList.AcceptSocket();
                this.Show();

                chatDisplay_txtbox.AppendText("Connection accepted from " + s.RemoteEndPoint + "\n");
                connection_lbl.Text = "Connected";
                connection_lbl.ForeColor = Color.Green;


                //InitTimer();
            }

            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.ToString());
            }


        }

        public static string GetHashedKey(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            int cntr = 0;
            foreach (byte x in hash)
            {
                if (cntr == 1)
                {
                    cntr = 0;
                }
                else
                {
                    hashString += String.Format("{0:x2}", x);
                    cntr++;
                }
            }
            return hashString;
        }

        //Encrypting a string
        public static string TxtEncrypt(string inText, string key)
        {
            byte[] bytesBuff = Encoding.UTF8.GetBytes(inText);
            using (Aes aes = Aes.Create())
            {
                Rfc2898DeriveBytes crypto = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aes.Key = crypto.GetBytes(32);
                aes.IV = crypto.GetBytes(16);
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cStream.Write(bytesBuff, 0, bytesBuff.Length);
                        cStream.Close();
                    }
                    inText = Convert.ToBase64String(mStream.ToArray());
                }
            }
            return inText;
        }

        //Decrypting a string
        public static string TxtDecrypt(string cryptTxt, string key)
        {
            cryptTxt = cryptTxt.Replace(" ", "+");
            cryptTxt = cryptTxt.Replace("\0", "");
            byte[] bytesBuff = Convert.FromBase64String(cryptTxt);
            using (Aes aes = Aes.Create())
            {
                Rfc2898DeriveBytes crypto = new Rfc2898DeriveBytes(key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aes.Key = crypto.GetBytes(32);
                aes.IV = crypto.GetBytes(16);
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cStream.Write(bytesBuff, 0, bytesBuff.Length);
                        cStream.Close();
                    }
                    cryptTxt = Encoding.UTF8.GetString(mStream.ToArray());
                }
            }
            return cryptTxt;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Socket s = myList.AcceptSocket();
            chatDisplay_txtbox.AppendText("Me:\t ");
            chatDisplay_txtbox.AppendText(inMessage_txtbox.Text + "\n");


            String str = TxtEncrypt(inMessage_txtbox.Text, EncryptionKey);
            s.Send(Encoding.UTF8.GetBytes(str));

        }

        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 200; // in miliseconds
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Socket s = myList.AcceptSocket();
            if (s.Available > 0)
            {
                byte[] b = new byte[s.ReceiveBufferSize];
                int k = s.Receive(b);
                string msg = "";
                chatDisplay_txtbox.AppendText("Other:\t");
                for (int i = 0; i < k; i++)
                {
                    msg += Convert.ToChar(b[i]);
                }
                chatDisplay_txtbox.AppendText(TxtDecrypt(msg, EncryptionKey) + "\n");
            }
        }
    }
}