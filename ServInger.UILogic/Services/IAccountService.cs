using DAL.Entites;
using System.Threading.Tasks;

namespace ServInger.UILogic.Services {
    public interface IAccountService {

        Task authorization(string Login, string Pass);
        UserEntity get();
    }
}