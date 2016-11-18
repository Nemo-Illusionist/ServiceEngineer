using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;

namespace ServInger.UILogic.Attributes {
    public class Maps {

        public async Task Show(string Address) {
            await Launcher("collection=name.Текущее%20задание" + await getPoint(Address));
        }

        public async Task Show(List<string> Address) {
            string points = "";
            foreach (var addr in Address)
                points += await getPoint(addr);
            await Launcher("collection=name.Список%20задайний" + points);
        }

        private async Task Launcher(string UriMaps) {
            var uri = new Uri(@"bingmaps:?" + UriMaps);

            var launcherOptions = new Windows.System.LauncherOptions();
            launcherOptions.TargetApplicationPackageFamilyName = "Microsoft.WindowsMaps_8wekyb3d8bbwe";
            var success = await Windows.System.Launcher.LaunchUriAsync(uri, launcherOptions);
        }

        private async Task<string> getPoint(string addr) {
            string points = "";
            Geoposition geoposition = await new Geolocator().GetGeopositionAsync();
            MapLocationFinderResult result =
                await MapLocationFinder.FindLocationsAsync(
                    addr, geoposition.Coordinate.Point);
            foreach (var p in result.Locations)
                points += "~point"
                    + $".{p.Point.Position.Latitude.ToString().Replace(",", ".")}"
                    + $"_{p.Point.Position.Longitude.ToString().Replace(",", ".")}"
                    + $"_{addr.Replace(" ", "%20")}";
            return points;
        }
    }
}
