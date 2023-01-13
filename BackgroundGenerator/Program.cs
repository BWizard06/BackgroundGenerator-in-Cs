
using System.Runtime.InteropServices;
using System.Transactions;

namespace ChangeBackground
{
    class backgroundChanger
    {
        // Use to set a wallpaper
        public const int SPI_SETDESKWALLPAPER = 20;
        public const int SPIF_UPDATEINFILE = 1;
        public const int SPIF_SENDCHANGE = 2;

        [DllImport("user32.dll", CharSet=CharSet.Auto, SetLastError = true)]
        public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        static void Main(string[] args)
        {

            while (true)
            {
                Random random = new Random();
                int index = random.Next(0, 6);
                String[] imageNames = { "1.jpg", "2.jpg", "3.jpg", "4.jpg", "5.jpg", "6.jpg" };
                String imagePath = @"C:\users\benbr\Desktop\Bikes\" + imageNames[index];

                // Set wallpaper
           
                SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, imagePath, SPIF_UPDATEINFILE | SPIF_SENDCHANGE);
                Thread.Sleep(3000);
            }
            

        }
    }
}
