using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Capture;
using Windows.Storage;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Xamarinforms.UWP
{
    public class PhotoService : IPhotoService
   {
        public async Task<byte[]> TakePhotoAsync()
        {
            CameraCaptureUI captureUI = new CameraCaptureUI();
            captureUI.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;

            StorageFile photo = await captureUI.CaptureFileAsync(CameraCaptureUIMode.Photo);

            if (photo == null) return null;

            using (var stream = await photo.OpenReadAsync())
            {
                var buffer = new Windows.Storage.Streams.Buffer((uint)stream.Size);
                var data = await stream.ReadAsync(buffer, (uint)stream.Size, Windows.Storage.Streams.InputStreamOptions.None);
                return data.ToArray();
            }

        }

    }
}
