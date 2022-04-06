using Discord.Commands;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSRat
{
    public class textsend : ModuleBase<SocketCommandContext>
    {
        [Command("텍스트입력")]
        public async Task tetxexnelsenDBHFSBHBSjjbvuietlnfddnsdj12312(string tenasdkANFLNL3y9429BSJKDjnsa3141UIJIxt)
        {
            SendKeys.SendWait("{ENTER}");
            SendKeys.SendWait(tenasdkANFLNL3y9429BSJKDjnsa3141UIJIxt);
            SendKeys.SendWait("{ENTER}");

            await Context.Channel.SendMessageAsync(tenasdkANFLNL3y9429BSJKDjnsa3141UIJIxt + " 입력!");
        }
    }
}