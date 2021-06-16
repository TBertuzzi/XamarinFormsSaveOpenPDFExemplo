using System;
using System.IO;
using System.Net.Http;
using Plugin.XamarinFormsSaveOpenPDFPackage;
using Xamarin.Forms;

namespace XamarinFormsSaveOpenPDFExemplo
{
    public partial class MainPage : ContentPage
    {
        private string url = "https://repositorio.unesp.br/bitstream/handle/11449/118389/000793203.pdf";
        public MainPage()
        {
            InitializeComponent();
        }

        async void btnExibirPdf_Clicked(Object sender, EventArgs e)
        {
         

            using (var httpClient = new HttpClient())
            {
                using (var memoryStream = new MemoryStream())
                {
                    var pdfStream = await httpClient.GetStreamAsync(url);
                    await pdfStream.CopyToAsync(memoryStream);
                    await CrossXamarinFormsSaveOpenPDFPackage.Current.SaveAndView("JogosSuperNitendo.pdf", "application/pdf", memoryStream, PDFOpenContext.InApp);
                }
            }
        }
    }
}
