using SQLite.Net.Attributes;
using System;

namespace DAL.Entites {
    public class TaskEntity {

        [PrimaryKey]
        public string IDTask { get; set; }
        [NotNull]
        public int IDUser { get; set; }

        //[NotNull]
        //public int Priority { get; set; }           //Приоритет задания
        [NotNull]
        public string TextTask { get; set; }        //Текст задания
        [NotNull]
        public DateTime DateEnd { get; set; }         //Плановая дата завершения
        [NotNull]
        public string Address { get; set; }         //Адресс

        [NotNull]
        public DateTime DateStart { get; set; }       //Дата назначения
        [NotNull]
        public int Status { get; set; }          //Текущий статус
        public string Manufacturer { get; set; }    //производитель
        public string Mark { get; set; }            //марка
        public string FactoryNomber { get; set; }   //заводской номер
    }
}
