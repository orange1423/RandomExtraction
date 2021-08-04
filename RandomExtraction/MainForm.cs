using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RandomExtraction
{
    public partial class MainForm : Form
    {
        bool ignoreweight = false;
        bool nohitokoto = false;
        bool nofrom = false;
        bool isStart = false;
        string extractionType = "all";
        string listFile = "list.csv";
        string ignoreListFile = "";
        string mustListFile = "";
        string hitokotoFiles = "";
        string hitokotoUrl = "https://v1.hitokoto.cn/";
        string hitokotoParameters = "?c=i&c=d";
        List<string> list = new List<string>();
        List<string> ignoreList = new List<string>();
        List<string> mustList = new List<string>();
        List<string> excludeList = new List<string>();
        Thread thread;
        public MainForm(string[] args)
        {
            foreach(string arg in args)
            {
                if (arg == "--ignoreweight")
                {
                    ignoreweight = true;
                }
                else if (arg.StartsWith("--list"))
                {
                    listFile = arg.Split('=')[1];
                }
                else if (arg.StartsWith("--ignorelist"))
                {
                    ignoreListFile = arg.Split('=')[1];
                }
                else if (arg.StartsWith("--mustList"))
                {
                    mustListFile = arg.Split('=')[1];
                }
                else if (arg.StartsWith("--type"))
                {
                    extractionType = arg.Split('=')[1];
                }
                else if (arg == "--nohitokoto")
                {
                    nohitokoto = true;
                }
                else if (arg == "--nofrom")
                {
                    nofrom = true;
                }
                else if (arg.StartsWith("--hitokotourl"))
                {
                    hitokotoUrl = arg.Split('=')[1];
                }
                else if (arg.StartsWith("--hitokotoparameters"))
                {
                    hitokotoParameters = arg.Split('=')[1];
                }
                else if(arg.StartsWith("--hitokotofiles"))
                {
                    hitokotoFiles = arg.Split('=')[1];
                }
                else if(arg.StartsWith("--exclude"))
                {
                    excludeList.AddRange(arg.Split('=')[1].Split(','));
                }
                else if (arg.StartsWith("--ignore"))
                {
                    ignoreList.AddRange(arg.Split('=')[1].Split(','));
                }
                else if (arg.StartsWith("--must"))
                {
                    mustList.AddRange(arg.Split('=')[1].Split(','));
                }
                else
                {
                    listFile = arg;
                }
            }
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            prepareLists();
            if(!nohitokoto)
            {
                refreshHitokoto();
            }
            changeColor();
        }

        private void prepareLists()
        {
            list.Clear();
            StreamReader reader = new StreamReader(listFile, Encoding.UTF8);
            bool flag = true;
            while (flag)
            {
                var listText = reader.ReadLine();
                if (listText == null)
                {
                    flag = false;
                    break;
                }
                string[] texts = listText.Split(',');
                if(excludeList.Exists(t => t == texts[0]))
                {
                    continue;
                }
                if(extractionType != "all" && extractionType != texts[1].Trim())
                {
                    continue;
                }
                if (ignoreweight)
                {
                    list.Add(texts[0].Trim());
                }
                else
                {
                    for (int i = int.Parse(texts[2]); i > 0; i--)
                    {
                        list.Add(texts[0].Trim());
                    }
                }
            }
            reader.Close();
            if (ignoreListFile != "")
            {
                reader = new StreamReader(ignoreListFile, Encoding.UTF8);
                flag = true;
                while (flag)
                {
                    string listText = reader.ReadLine();
                    if (listText == null)
                    {
                        flag = false;
                        break;
                    }
                    if(!ignoreList.Exists(t => t == listText.Trim()))
                    ignoreList.Add(listText.Trim());
                }
                reader.Close();
            }
            if(mustListFile != "")
            {
                reader = new StreamReader(mustListFile, Encoding.UTF8);
                flag = true;
                while (flag)
                {
                    string listText = reader.ReadLine();
                    if (listText == null)
                    {
                        flag = false;
                        break;
                    }
                    if(!mustList.Exists(t => t == listText.Trim()))
                    {
                        mustList.Add(listText.Trim());
                    }
                }
                reader.Close();
            }
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            if(isStart)
            {
                isStart = false;
                button_Start.Text = "Start";
            }
            else
            {
                isStart = true;
                thread = new Thread(new ThreadStart(Extract));
                thread.Start();
                button_Start.Text = "Stop";
            }
        }

        private void Extract()
        {
            Random random = new Random();
            while (isStart)
            {
                int index = random.Next(0, list.Count - 1);
                textBox_Extraction.Text = list[index];
                Thread.Sleep(25);
             }
             if(mustList.Count > 0)
            {
                if(list.Exists(t => t == mustList[0]))
                {
                    textBox_Extraction.Text = mustList[0];
                }
                mustList.RemoveAt(0);
            }
            else
            {
                while (ignoreList.Exists(t => t == textBox_Extraction.Text))
                {
                    int index = random.Next(0, list.Count - 1);
                    textBox_Extraction.Text = list[index];
                }
            }
            if (!nohitokoto)
            {
                refreshHitokoto();
            }
        }

        private void refreshHitokoto()
        {
            JArray hitokotoArray = new JArray();
            foreach (string hitokotoFile in hitokotoFiles.Split('&'))
            {
                if (File.Exists(hitokotoFile))
                {
                    StreamReader reader = new StreamReader(hitokotoFile);
                 
                    hitokotoArray.Merge(JArray.Parse(reader.ReadToEnd()));
                }
            }
            JObject hitokotoJson;
            if (hitokotoArray.Count > 0)
            {
                Random random = new Random();
                hitokotoJson = JObject.Parse(hitokotoArray[random.Next(0, hitokotoArray.Count)].ToString());
            }
            else
            {
                hitokotoJson = JObject.Parse(HttpGet(hitokotoUrl + hitokotoParameters, null));
            }
            string hitokotoText = "";
            hitokotoText += hitokotoJson["hitokoto"].ToString().Trim();
            if(!nofrom)
            {
                hitokotoText += "    ——";
                hitokotoText += hitokotoJson["from_who"];
                hitokotoText += "「" + hitokotoJson["from"] + "」";
            }
            textBox_hitokoto.Text = hitokotoText;
        }

        public string HttpGet(string Url, string contentType)
        {
            try
            {
                string retString = string.Empty;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "GET";
                request.ContentType = contentType;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(myResponseStream);
                retString = streamReader.ReadToEnd();
                streamReader.Close();
                myResponseStream.Close();
                return retString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void MainForm_DoubleClick(object sender, EventArgs e)
        {
            if (extractionType == "all")
            {
                extractionType = "girl";
            }
            else if (extractionType == "girl")
            {
                extractionType = "boy";
            }
            else if (extractionType == "boy")
            {
                extractionType = "all";
            }
            changeColor();
            prepareLists();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void changeColor()
        {
            Color color;
            bool visible = false;

            if (extractionType == "girl")
            {
                color = Color.FromArgb(152, 153, 255);
            }
            else if(extractionType == "boy")
            {
                color = Color.FromArgb(102, 204, 255);
            }
            else
            {
                color = SystemColors.Control;
                visible = true;
            }
            this.BackColor = color;
            textBox_Extraction.BackColor = color;
            textBox_hitokoto.BackColor = color;
            pictureBox_MessageForm.Visible = visible;
            pictureBox_.Visible = visible;
        }
    }
}