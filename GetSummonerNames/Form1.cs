using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using GetSummonerNames.Properties;
using Newtonsoft.Json;

namespace GetSummonerNames
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class PlayerRegion
        {
            public string region { get; set; }
        }

        public class Player
        {
            public string Name { get; set; }
            public string game_name { get; set; }
            public string game_tag { get; set; }
        }

        public class Players
        {
            public List<Player> Participants { get; set; }
        }

        public static Dictionary<int, string> PlayerList { get; set; } = new Dictionary<int, string>();
        public static Dictionary<int, string> Linklist { get; set; } = new Dictionary<int, string>();
        public static Dictionary<string, string> Riot { get; set; } = new Dictionary<string, string>();
        public static Dictionary<string, string> Client { get; set; } = new Dictionary<string, string>();

        private string _myregion;
        private string _riotnames;
        private string _playernames;
        private const string Mobalytics = "https://app.mobalytics.gg/lol/profile/";
        private bool waitforreset = false;
        private string _uggplayers; // might be useless but i couldnt find a declaration for a string _uggplayers so i just shoved one into this class :trollge:
        public const int WmNclbuttondown = 0xA1;
        public const int HtCaption = 0x2;


        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WmNclbuttondown, HtCaption, 0);
            }
        }

        private static string Cmd(string gamename)
        {
            var commandline = "";
            var mngmtClass = new ManagementClass("Win32_Process");
            foreach (var managementBaseObject in mngmtClass.GetInstances())
            {
                var o = (ManagementObject)managementBaseObject;
                if (o["Name"].Equals(gamename))
                {
                    commandline = "[" + o["CommandLine"] + "]";
                }
            }

            return commandline;
        }

        private static string Findstring(string text, string from, string to)
        {
            var pFrom = text.IndexOf(from, StringComparison.Ordinal) + from.Length;
            var pTo = text.LastIndexOf(to, StringComparison.Ordinal);

            return text.Substring(pFrom, pTo - pFrom);
        }

        private static string Getregion(string requeqst)
        {
            return JsonConvert.DeserializeObject<PlayerRegion>(requeqst).region;
        }

        private static void get_lcu()
        {
            Riot.Clear();
            Client.Clear();

            var commandline = Cmd("LeagueClientUx.exe");

            Riot.Add("port", Findstring(commandline, "--riotclient-app-port=", "\" \"--no-rads"));
            Riot.Add("token", Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("riot:" + Findstring(commandline, "--riotclient-auth-token=", "\" \"--riotclient"))));

            Client.Add("port", Findstring(commandline, "--app-port=", "\" \"--install"));
            Client.Add("token", Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("riot:" + Findstring(commandline, "--remoting-auth-token=", "\" \"--respawn-command=LeagueClient.exe"))));
        }

        private static string MakeRequest(string type, string url, bool client)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += delegate
                {
                    const bool validationResult = true;
                    return validationResult;
                };

                int port;
                string token;

                if (client)
                {
                    port = Convert.ToInt32(Client["port"]);
                    token = Client["token"];
                }
                else
                {
                    port = Convert.ToInt32(Riot["port"]);
                    token = Riot["token"];
                }

                var request = (HttpWebRequest)WebRequest.Create("https://127.0.0.1:" + port + url);
                request.PreAuthenticate = true;
                request.ContentType = "application/json";
                request.Method = type;
                request.Headers.Add("Authorization", "Basic " + token);

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    return streamReader.ReadToEnd();
                }
            }
            catch
            {
                return "";
            }
        }

        private void Resetlabel()
        {
            linkLabel1.Enabled = false;
            linkLabel2.Enabled = false;
            linkLabel3.Enabled = false;
            linkLabel4.Enabled = false;
            linkLabel5.Enabled = false;

            linkLabel1.Text = "PLAYER 1";
            linkLabel2.Text = "PLAYER 2";
            linkLabel3.Text = "PLAYER 3";
            linkLabel4.Text = "PLAYER 4";
            linkLabel5.Text = "PLAYER 5";
        }


        private void Getplayers(string req)
        {
            Linklist.Clear();
            PlayerList.Clear();
            _riotnames = "";
            _playernames = "";
            var deserialized = JsonConvert.DeserializeObject<Players>(req);
            var count = 0;

            int totalPlayers = deserialized.Participants.Count;
            foreach (var player in deserialized.Participants)
            {
                count++;
                PlayerList.Add(count, player.Name);
                Console.WriteLine(player.Name);
                Linklist.Add(count, Mobalytics + _myregion + "/" + player.Name + "/overview");


                _uggplayers += player.Name;
                if (count != totalPlayers) // Check if it's not the last iteration
                {
                    _uggplayers += ", ";

                    _riotnames += player.Name;
                    _playernames += player.game_name + "%23" + player.game_tag;
                    if (count != totalPlayers) // Check if it's not the last iteration
                    {
                        _riotnames += ", ";
                        _playernames += ", ";

                    }
                }

                if (PlayerList.Count >= 1)
                {
                    linkLabel1.Text = PlayerList[1];
                    linkLabel1.Enabled = true;

                    label1.Text = "Found Players in Lobby...";

                    BackgroundImage = Resources.onx;

                    //BackgroundImage = Resources.on3;

                    button2.Enabled = true;
                    button3.Enabled = true;
                }
                else
                {
                    label1.Text = "Waiting for Lobby...";

                    BackgroundImage = Resources.offx;

                    //BackgroundImage = Resources.off3;

                    button2.Enabled = false;
                    button3.Enabled = false;
                }

                if (PlayerList.Count >= 2)
                {
                    linkLabel2.Text = PlayerList[2];
                    linkLabel2.Enabled = true;
                }

                if (PlayerList.Count >= 3)
                {
                    linkLabel3.Text = PlayerList[3];
                    linkLabel3.Enabled = true;
                }

                if (PlayerList.Count >= 4)
                {
                    linkLabel4.Text = PlayerList[4];
                    linkLabel4.Enabled = true;
                }

                if (PlayerList.Count >= 5)
                {
                    linkLabel5.Text = PlayerList[5];
                    linkLabel5.Enabled = true;
                }
            }
        }

            private void button1_Click(object sender, EventArgs e)
            {
                label1.Text = "Connecting to LCU...";
                get_lcu();
                label1.Text = "Searching for Players...";
                _myregion = Getregion(MakeRequest("GET", "/riotclient/region-locale" /*Public Riot API request*/, true));
                Getplayers(MakeRequest("GET", "/chat/v5/participants/champ-select" /*Found Request in various Logs C:\Riot Games\League of Legends\Logs\LeagueClient*/, false));
            }

        private void button2_Click(object sender, EventArgs e)
        {
            if (statbox.SelectedItem.ToString() == "U.GG")
                Process.Start("https://u.gg/multisearch?summoners=" + _uggplayers + "&region=" + _myregion.ToLower() + "1");

            if (statbox.SelectedItem.ToString() == "TRACKER")
                Process.Start("https://tracker.gg/lol/multisearch/" + _myregion + "/" + _uggplayers);

            if (statbox.SelectedItem.ToString() == "DEEPLOL")
                Process.Start("https://www.deeplol.gg/multi/" + _myregion + "/" + _uggplayers);

            if (statbox.SelectedItem.ToString() == "OP.GG")
                Process.Start("https://www.op.gg/multisearch/" + _myregion.ToLower() + "?summoners=" + _uggplayers);

            if (statbox.SelectedItem.ToString() == "PORO.GG")
                Process.Start("https://poro.gg/multi?region=" + _myregion + "&q=" + _uggplayers);

                Process.Start("https://u.gg/multisearch?summoners=" + _playernames.Replace("%23","-") + "&region=" + _myregion.ToLower() + "1");

            if (statbox.SelectedItem.ToString() == "TRACKER")
                Process.Start("https://tracker.gg/lol/multisearch/" +_myregion + "/" +  _playernames);

            if (statbox.SelectedItem.ToString() == "DEEPLOL")
                Process.Start("https://www.deeplol.gg/multi/" + _myregion + "/" + _playernames);

            if (statbox.SelectedItem.ToString() == "OP.GG")
                Process.Start("https://www.op.gg/multisearch/" + _myregion.ToLower() + "?summoners=" + _playernames);

            if (statbox.SelectedItem.ToString() == "PORO.GG")
                Process.Start("https://poro.gg/multi?region=" + _myregion + "&q=" + _riotnames);
        }

        private void button3_Click(object sender, EventArgs e)
            {
                var dialogResult = MessageBox.Show("You might get a Dodge Penalty!\r\nYou also lose LP if you dodge in Ranked.\r\nDo you still want to dodge?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    button2.Enabled = false;
                    label1.Text = "Dodging Lobby...";
                    get_lcu();
                    MakeRequest("POST", "/lol-login/v1/session/invoke?destination=lcdsServiceProxy&method=call&args=[\"\",\"teambuilder-draft\",\"quitV2\",\"\"]", true); //Updated Dodge Request - Original Credits to "mfro - LeagueClient": https://github.com/mfro/LeagueClient/blob/95c403bd582713c420090dec4f63dae284ff6598/RiotClient/RiotServices.cs#L1092 - Updated with "KebsCS KBotExt": https://github.com/KebsCS/KBotExt/blob/94d13918558799e7704bd9fa50505362cdc7d47f/KBotExt/GameTab.h#L313
                    label1.Text = "Dodged Lobby...";

                    waitforreset = true;
                    Resetlabel();

                    BackgroundImage = Resources.offx;

                    //BackgroundImage = Resources.off3;

                }

            }


        private static readonly Random Random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            var dialogResult = MessageBox.Show("Hey, there might be an update for my program.\r\n\r\nIf there is, you can download it from Unknowncheats or my Discord. To check out for a possible update and get redirected to UnknownCheats, press Yes.\r\n\r\n(If you obtained this program from a source other than UnknownCheats or my Discord server, it was not uploaded by me.)", "Baseult-Rev Information!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                Process.Start("https://www.unknowncheats.me/forum/league-of-legends/523020-ranked-12-22-reveal-teammates-lobby.html");
            }

            Text = RandomString(16);



            statbox.Text = "DEEPLOL";
            statbox.Select(1, 1);


            backgroundWorker1.RunWorkerAsync();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Linklist[1]);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Linklist[2]);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Linklist[3]);
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Linklist[4]);
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Linklist[5]);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (true)
            {

                try
                {
                    get_lcu();
                    _myregion = Getregion(MakeRequest("GET", "/riotclient/region-locale" /*Public Riot API request*/, true));
                    Getplayers(MakeRequest("GET", "/chat/v5/participants/champ-select" /*Found Request in various Logs C:\Riot Games\League of Legends\Logs\LeagueClient*/, false));
                }
                catch
                {


                    if (!waitforreset)
                    {
                        try
                        {
                            get_lcu();
                            _myregion = Getregion(MakeRequest("GET", "/riotclient/region-locale" /*Public Riot API request*/, true));
                            Getplayers(MakeRequest("GET", "/chat/v5/participants/champ-select" /*Found Request in various Logs C:\Riot Games\League of Legends\Logs\LeagueClient*/, false));
                        }
                        catch
                        {

                        }
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(5000);
                        waitforreset = false;

                    }

                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
    }
}
