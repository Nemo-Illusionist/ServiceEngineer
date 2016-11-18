using SQLite.Net.Attributes;

namespace DAL.Entites {
    public class TechnicalCardEntity {

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [NotNull]
        public string IDTask { get; set; }
        [NotNull]
        public string IndexText { get; set; }
        public int FlagTask { get; set; }

        public TechnicalCardEntity() { }

        public TechnicalCardEntity(string idTask, string indexText) : this(idTask, indexText, 0) {
        }

        public TechnicalCardEntity(string idTask, string indexText, int flagTask) {
            IDTask = idTask;
            IndexText = indexText;
            FlagTask = flagTask;
        }
    }
}
