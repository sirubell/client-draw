using System.Net.Sockets;

namespace client_draw
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                case Keys.Left:
                    dir.code |= 0x01;
                    break;
                case Keys.D:
                case Keys.Right:
                    dir.code |= 0x10;
                    break;
                default:
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                case Keys.Left:
                    dir.code &= ~0x01;
                    break;
                case Keys.D:
                case Keys.Right:
                    dir.code &= ~0x10;
                    break;
                default:
                    break;
            }
        }

        private void Form1_Closing(object sender, EventArgs e)
        {
            if (client != null)
            {
                client.Close();
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (textBoxServerIP.Text != String.Empty)
            {
                if (Connect(textBoxServerIP.Text, 15070))
                {
                    textBoxServerIP.Enabled = false;
                    btnConnect.Enabled = false;

                    Thread t = new Thread(TalkToServer);
                    t.IsBackground = true;
                    t.Start();
                }
                
            }
            else
            {

            }
        }
        bool Connect(string serverIP, Int32 port)
        {
            try
            {
                client = new TcpClient(serverIP, port);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        void TalkToServer()
        {
            while (true)
            {
                if (game.doneDrawing)
                {
                    game.doneDrawing = false;
                    SendDirection();
                    ReceiveEnvironment();
                }
                Thread.Sleep(10);
            }
        }

        void SendDirection()
        {
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(dir.ToString());
            NetworkStream stream = client.GetStream();

            stream.Write(data, 0, data.Length);
        }
        void ReceiveEnvironment()
        {
            Byte[] buffer = new Byte[1024];
            String responseData = String.Empty;
            NetworkStream stream = client.GetStream();
            Int32 bytes = stream.Read(buffer, 0, buffer.Length);
            responseData = System.Text.Encoding.ASCII.GetString(buffer, 0, bytes);

            string[] chunks = responseData.Split('\n');
            string myName = chunks[0];
            string[] players = chunks[1].Split('|');
            string[] platforms = chunks[2].Split('|');
            int time_elpsed = Convert.ToInt32(chunks[3]);

            game.players.Clear();
            foreach (string player in players)
            {
                if (player == String.Empty) continue;

                string[] playerData = player.Split(',');
                int x = Convert.ToInt32(playerData[0]);
                int y = Convert.ToInt32(playerData[1]);
                int w = Convert.ToInt32(playerData[2]);
                int h = Convert.ToInt32(playerData[3]);
                string name = playerData[4];
                int heart = Convert.ToInt32(playerData[5]);

                game.players.Add(new Player(new Rect(x, y, w, h), name, heart, name == myName));
            }

            game.platforms.Clear();
            foreach (string platform in platforms)
            {
                if (platform == String.Empty) continue;

                string[] platformData = platform.Split(',');
                int x = Convert.ToInt32(platformData[0]);
                int y = Convert.ToInt32(platformData[1]);
                int w = Convert.ToInt32(platformData[2]);
                int h = Convert.ToInt32(platformData[3]);
                string name = platformData[4];
                int type = Convert.ToInt32(platformData[5]);

                game.platforms.Add(new Platform(new Rect(x, y, w, h), type, name));
            }

            pictureBoxCanvas.Invalidate();
        }

        private void pictureBoxCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (game == null) return;

            Graphics g = e.Graphics;

            g.DrawImage(ResourceImages.background, 0, 0, pictureBoxCanvas.Width, pictureBoxCanvas.Height);

            foreach (Player player in game.players)
            {
                g.FillRectangle(player.isMe ? Brushes.MediumTurquoise : Brushes.OrangeRed, player.rect.x, player.rect.y, player.rect.w, player.rect.h);
            }

            foreach (Platform platform in game.platforms)
            {
                Bitmap image;
                if (platform.type == PlatformType.Normal) image = ResourceImages.platform;
                else image = ResourceImages.thorn;

                g.DrawImage(image, platform.rect.x, platform.rect.y, platform.rect.w, platform.rect.h);
            }

            game.doneDrawing = true;
        }
    }
}