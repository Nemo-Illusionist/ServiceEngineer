using System;
using System.Threading.Tasks;
using Windows.Media.Capture;
using Windows.Storage;

namespace ServInger.UILogic.Attributes {
    public class Camera : ICamera {

        public async Task<string> Screen() {
            try {
                CameraCaptureUI camera = new CameraCaptureUI();
                camera.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
                camera.PhotoSettings.AllowCropping = false;
                StorageFile photo = await camera.CaptureFileAsync(CameraCaptureUIMode.Photo);
                return photo.Path;
                
            } catch {
                throw new Exception("Ошибка камеры");
            }
        }
    }
}
