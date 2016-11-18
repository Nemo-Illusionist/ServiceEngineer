using Windows.Devices.Lights;
using System;
using System.Threading.Tasks;

namespace ServInger.UILogic.Attributes {
    public class Flashlight : IFlashlight {

        public async Task OnOf() {
            Lamp lamp = await Lamp.GetDefaultAsync();
            if (lamp == null)
                throw new Exception("Не удалось получить доступ к фонарику");
            lamp.IsEnabled = !lamp.IsEnabled;
            //if (lamp.IsEnabled == false) {
            //    lamp.Dispose();
            //    lamp = null;
            //}
        }
    }
}
