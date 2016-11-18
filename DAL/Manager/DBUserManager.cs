using DAL.Entites;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.WinRT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Manager {
    public class DBUserManager : IDBUserManager {

        SQLiteAsyncConnection Connection(){

            return new SQLiteAsyncConnection(() => new SQLiteConnectionWithLock(
                    new SQLitePlatformWinRT(), new SQLiteConnectionString(ConstantDB.DBName, false)));

        }

        public async Task<UserEntity> get(string login) {
            try {
                var db = DBAsync.Connection();
                var user = await db.Table<UserEntity>().Where(x => x.Login == login).ToListAsync();
                if (user.Capacity > 0)
                    return user.First();
                else
                    return null;
            } catch {
                throw new Exception("Ошибка Базы данных");
            }
        }

        //public async Task<int> set(UserEntity user) {
        //    var db = Connection();
        //    return await db.InsertAsync(user);
        //}

        //public async Task<int> setAll(List<UserEntity> user) {
        //    var db = Connection();
        //    return await db.InsertAllAsync(user);
        //}

        //public async Task<int> update(UserEntity user) {
        //    var db = Connection();
        //    return await db.UpdateAsync(user);
        //}

        //public async Task<int> updateAll(List<UserEntity> user) {
        //    var db = Connection();
        //    return await db.UpdateAllAsync(user);
        //}

        //public async Task<int> delete(UserEntity user) {
        //    var db =  Connection();
        //    return await db.DeleteAsync(user);
        //}

        //public async Task<int> deleteAll() {
        //    var db = Connection();
        //    return await db.DeleteAllAsync<UserEntity>();
        //}

    }
}
