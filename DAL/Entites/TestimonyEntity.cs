using SQLite.Net.Attributes;

namespace DAL.Entites {

    public class TestimonyEntity {

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [NotNull]
        public string IDTask { get; set; }
        [NotNull]
        public string Text { get; set; }
        [NotNull]
        public int Type { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public int PresentValue { get; set; }
    }
}
