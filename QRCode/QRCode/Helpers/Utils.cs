using Plugin.Vibrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Net.Mobile.Forms;

namespace QRCode.Helpers
{
    public class Utils
    {
        public static void Vibrate()
        {
            try
            {
                var v = CrossVibrate.Current;
                v.Vibration();
            }
            catch
            {

            }
        }

        public async static Task<ZXingScannerPage> CaptureQRCodeAsync(ZXingScannerPage scanPage, string title, ZXing.BarcodeFormat format)
        {
            //Create page do QRCode
            if(scanPage == null)
            {
                var options = new ZXing.Mobile.MobileBarcodeScanningOptions();
                options.PossibleFormats = new List<ZXing.BarcodeFormat>
                {
                    format
                };
//Start correctly the plugins of Scanner
#if __ANDROID__
                MobileBarcodeScanner.Initialize (Application);
#endif
                
                scanPage = new ZXingScannerPage(options); //Creata a new instance
                scanPage.IsScanning = true; //Start camera and qrCode
            }
            scanPage.Title = title; //Title
            return scanPage; //return page
        }
    }
}
