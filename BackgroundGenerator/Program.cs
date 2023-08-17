using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Linq;

namespace ChangeBackground
{
    class BackgroundChanger
    {
        // Use to set a wallpaper
        public const int SPI_SETDESKWALLPAPER = 20;
        public const int SPIF_UPDATEINFILE = 1;
        public const int SPIF_SENDCHANGE = 2;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        static void Main(string[] args)
        {
            String desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            String folderPath = $@"{desktopPath}\Backgrounds";
            Console.WriteLine(folderPath);

            while (true)
            {
                String[] jpgImages = Directory.GetFiles(folderPath, "*.jpg");
                String[] pngImages = Directory.GetFiles(folderPath, "*.png");
                String[] imagePaths = jpgImages.Concat(pngImages).ToArray();

                if (imagePaths.Length == 0)
                {
                    Console.WriteLine("Keine .jpg oder .png Bilder im Backgrounds Ordner gefunden!");
                    Thread.Sleep(3000);
                    continue;
                }

                Random random = new Random();
                int index = random.Next(0, imagePaths.Length);

                // Set wallpaper
                SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, imagePaths[index], SPIF_UPDATEINFILE | SPIF_SENDCHANGE);
                Thread.Sleep(3000);


            }
        }
    }
}
