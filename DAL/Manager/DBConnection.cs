using DAL.Entites;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.WinRT;

namespace DAL.Manager {
    public class DBConnection : SQLiteConnection {

        public DBConnection(bool storeDateTimeAsTicks = true) : base(new SQLitePlatformWinRT(), ConstantDB.DBName) {
        }
    }

    public static class DBAsync {
        public static SQLiteAsyncConnection Connection() {

            return new SQLiteAsyncConnection(() => new SQLiteConnectionWithLock(
                    new SQLitePlatformWinRT(), new SQLiteConnectionString(ConstantDB.DBName, false)));

        }
    }
}
