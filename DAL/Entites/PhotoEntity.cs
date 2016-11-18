using SQLite.Net.Attributes;
using System;

namespace DAL.Entites {
    public class PhotoEntity {

        [PrimaryKey, AutoIncrement]
        public int IDPhoto { get; set; }
        [NotNull]
        public string IDTask { get; set; }
        [NotNull]
        public string Path { get; set; }
    }
}
