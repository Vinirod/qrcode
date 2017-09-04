using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace QRCode
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CodePage : ContentPage
    {
        ZXingBarcodeImageView barcode1;
        ZXingBarcodeImageView barcode2;


        public CodePage()
        {
            InitializeComponent();
            ShowQR();
        }

        public void ShowQR()
        {
            barcode1 = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                AutomationId = "zxingBarcodeImageView",
                Margin = new Thickness(10)
            };

            barcode1.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            barcode1.BarcodeOptions.Width = 400;
            barcode1.BarcodeOptions.Height = 400;
            barcode1.BarcodeOptions.Margin = 0;
            barcode1.BarcodeValue = "https://www.youtube.com/ata275";
            stackPrinc.Children.Add(barcode1);

            barcode2 = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                AutomationId = "zxingBarcodeImageView",
                Margin = new Thickness(10)
            };

            barcode2.BarcodeFormat = ZXing.BarcodeFormat.EAN_13;
            barcode2.BarcodeOptions.Width = 400;
            barcode2.BarcodeOptions.Height = 400;
            barcode2.BarcodeOptions.Margin = 0;
            barcode2.BarcodeValue = "1232797466045";
            stackPrinc.Children.Add(barcode2);
        }
    }
}