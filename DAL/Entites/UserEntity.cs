using SQLite.Net.Attributes;

namespace DAL.Entites {
    public class UserEntity {

        [PrimaryKey]
        public int IDUser { get; set; }
        [NotNull, Unique]
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
