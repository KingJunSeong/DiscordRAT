using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRat.commands
{
    public class onoff : ModuleBase<SocketCommandContext>
    {
        [Command("상태")]
        public async Task fkabnklfjbKASNDKJASNCKJUI163878()
        {
            await Context.Channel.SendMessageAsync("켜져있음");
        }
    }
}
