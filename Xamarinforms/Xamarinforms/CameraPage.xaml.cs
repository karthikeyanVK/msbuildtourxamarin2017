using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;


namespace Xamarinforms
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CameraPage : ContentPage
	{
        Nose _nose;
        public CameraPage (Nose nose)
		{
            _nose = nose;

            InitializeComponent();
		}
        private async void captureButton_Clicked(object sender, EventArgs e)
        {
            var photoService = DependencyService.Get<IPhotoService>();
            if (photoService != null)
            {
                var imageBytes = await photoService.TakePhotoAsync();
                noseImage.Source = ImageSource.FromUri(new Uri(_nose.Image)); // set source of nose image
                noseImage.Source = ImageSource.FromStream(() => new MemoryStream(imageBytes));
                imageGrid.IsVisible = true; // set visibility to true
            }

        }

    }
}
