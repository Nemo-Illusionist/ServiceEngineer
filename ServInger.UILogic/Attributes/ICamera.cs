using System.Threading.Tasks;

namespace ServInger.UILogic.Attributes {
    public interface ICamera {
        Task<string> Screen();
    }
}