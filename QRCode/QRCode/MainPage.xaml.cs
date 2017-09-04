using QRCode.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace QRCode
{
    public partial class MainPage : ContentPage
    {
        private string codeCapture;

        bool initCapture = false;
        bool showMesseger = false;

        ZXingScannerPage scanPage = null;

        public MainPage()
        {
            InitializeComponent();
        }

        public string CodeCapture
        {
            get { return codeCapture; }
            set {

                codeCapture = value;
                lblCode.Text = codeCapture;
            }
        }

        public async Task Capture()
        {
            //Attribute of ScanPage on new instance.
            scanPage = await Utils.CaptureQRCodeAsync(scanPage, "Scan code", ZXing.BarcodeFormat.QR_CODE);

            if (!initCapture) //Adicionar apenas uma vez esse evento do onResult
            {
                scanPage.OnScanResult += (result) =>
                {
                    Device.BeginInvokeOnMainThread(async () => //Falar com a tela do usuário,quer seja gerar um código ou obter um
                    {
                        try
                        {
                            if (showMesseger)
                            {
                                return;
                            }

                            scanPage.IsScanning = false;

                            if (!string.IsNullOrEmpty(CodeCapture))
                            {
                                return;
                            }

                            Utils.Vibrate();

                            codeCapture = result.Text;
                            await Navigation.PopAsync();
                        }
                        catch (Exception ex)
                        {
                            showMesseger = true;
                            await this.DisplayAlert("Attention", "Invalid code", "Try Again");
                            showMesseger = false;
                        }
                    });
                };
                initCapture = true;
            }
            codeCapture = "";
            await Navigation.PushAsync(scanPage);
        }

        private async void Button_Touch_Capture(object sender, EventArgs e)
        {
            await Capture();
        }

        private void Button_Touch_Code(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CodePage());
        }
    }
}
