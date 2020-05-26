using Scandit.BarcodePicker.Unified;
using System;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamFormsMDet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanditPage : ContentPage
    {
        public ScanditPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Scandit.BarcodePicker.Unified.Abstractions.DidScanDelegate del = ProcessScanResults;
            Services.ScanService.Instance.Engage(del);
        }

        void ProcessScanResults(Scandit.BarcodePicker.Unified.ScanSession session)
        {
            if (session == null) return;

            if (session.NewlyRecognizedCodes != null && session.NewlyRecognizedCodes.Any())
            {
                var firstCode = session.NewlyRecognizedCodes.First();

                session.StopScanning();

                // Because this event handler is called from an scanner-internal thread, 
                // you must make sure to dispatch to the main thread for any UI work.
                Device.BeginInvokeOnMainThread(async () =>
                {
                    ScanditService.BarcodePicker.DidScan -= ProcessScanResults;
                    if (firstCode != null)
                    {
                        // This delay is needed because the app will crash if we too quickly transition to another page when the scanner is closing
                        // This gives time for this page to load before going to item details page
                        await Task.Delay(200);

                        await ScanSearch(firstCode);
                    }
                });
            }
            else session.StopScanning();
        }

        async Task ScanSearch(Barcode scan)
        {
            await DisplayAlert("Scandit Result", $"{scan.SymbologyString}, {scan.Data}", "Ok");
        }
    }
}