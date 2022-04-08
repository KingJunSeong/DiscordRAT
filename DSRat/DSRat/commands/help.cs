using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRat
{
    public class help : ModuleBase<SocketCommandContext>
    {
        [Command("명령어")]
        public async Task heasdlasjjlSHKJDHAJ7981789lpp()
        {
            await Context.Channel.SendMessageAsync(" !키입력 입력할키 \n !컴퓨터종료  \n !마우스이동 x y \n !텍스트입력 \n !화면캡처 \n !웹열기 웹주소 \n !프로세스킬 프로세스이름 \n !상태 \n !아이피\n !프로세스목록\n !메세지박스 할말");
        }
    }
}
