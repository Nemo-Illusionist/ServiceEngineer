
using DAL.Manager;
using DAL.Entites;
using System.Threading.Tasks;
using System;

namespace ServInger.UILogic.Services
{
    public class AccountService : IAccountService {

        private UserEntity _user { get; set; }
        private readonly IDBUserManager _dbUserManager;

        public AccountService(IDBUserManager dbUserManager) {
            _dbUserManager = dbUserManager;
        }

        public async Task authorization(string Login, string CurrentPassword) {
            CurrentPassword = CurrentPassword == null ? "" : CurrentPassword;
            UserEntity _user = await _dbUserManager.get(Login);
            if (_user != null && _user.Password == CurrentPassword) { 
                this._user = _user;
            }else
                throw new Exception("Неверный логин или пароль.\nВведите данные учетной записи еще раз.");
        }

        public UserEntity get() {
            return _user;
        }
    }
}
