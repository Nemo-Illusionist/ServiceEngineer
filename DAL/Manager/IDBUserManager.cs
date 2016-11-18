using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Entites;

namespace DAL.Manager {
    public interface IDBUserManager {
        Task<UserEntity> get(string login);
        //Task<int> delete(UserEntity user);
        //Task<int> deleteAll();
        //Task<int> set(UserEntity user);
        //Task<int> setAll(List<UserEntity> user);
        //Task<int> update(UserEntity user);
        //Task<int> updateAll(List<UserEntity> user);
    }
}