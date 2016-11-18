using DAL.Entites;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.WinRT;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Manager {
    public class DBTestManager {

        public static SQLiteAsyncConnection Connect() {
            return new SQLiteAsyncConnection(() => new SQLiteConnectionWithLock(
                    new SQLitePlatformWinRT(), new SQLiteConnectionString(ConstantDB.DBName, false)));
        }

        public void CreateDB() {
            var db = new DBConnection();
            db.CreateTable<UserEntity>();
            db.CreateTable<TaskEntity>();
            db.CreateTable<PhotoEntity>();
            db.CreateTable<TechnicalCardEntity>();
            db.CreateTable<TestimonyEntity>();
        }

        public void CreateTestDB() {
            var db = new DBConnection();
            List<TestimonyEntity> testi = new List<TestimonyEntity>() {
                new TestimonyEntity {
                    IDTask = "TKG-000002",
                    Text = "Температура масла, С",
                    PresentValue = 100,
                    MinValue = 0,
                    MaxValue = 500,
                    Type = 0
                },
                new TestimonyEntity {
                    IDTask = "TKG-000002",
                    Text = "Содержание примесей в масле, %",
                    PresentValue = 50,
                    MinValue = 0,
                    MaxValue = 100,
                    Type = 0
                },
                new TestimonyEntity {
                    IDTask = "TKG-000002",
                    Text = "Уровень рабочей среды",
                    PresentValue = 1,
                    Type = 1
                },
                                new TestimonyEntity {
                    IDTask = "TKG-000003",
                    Text = "Температура масла, С",
                    PresentValue = 100,
                    MinValue = 0,
                    MaxValue = 500,
                    Type = 0
                },
                new TestimonyEntity {
                    IDTask = "TKG-000003",
                    Text = "Содержание примесей в масле, %",
                    PresentValue = 50,
                    MinValue = 0,
                    MaxValue = 100,
                    Type = 0
                },
                new TestimonyEntity {
                    IDTask = "TKG-000003",
                    Text = "Уровень рабочей среды",
                    PresentValue = 1,
                    Type = 1
                },
                                new TestimonyEntity {
                    IDTask = "TKG-000004",
                    Text = "Температура масла, С",
                    PresentValue = 100,
                    MinValue = 0,
                    MaxValue = 500,
                    Type = 0
                },
                new TestimonyEntity {
                    IDTask = "TKG-000004",
                    Text = "Содержание примесей в масле, %",
                    PresentValue = 50,
                    MinValue = 0,
                    MaxValue = 100,
                    Type = 0
                },
                new TestimonyEntity {
                    IDTask = "TKG-000004",
                    Text = "Уровень рабочей среды",
                    PresentValue = 1,
                    Type = 1
                },
                new TestimonyEntity {
                    IDTask = "TKG-000001",
                    Text = "Температура масла, С",
                    PresentValue = 100,
                    MinValue = 0,
                    MaxValue = 500,
                    Type = 0
                },
                new TestimonyEntity {
                    IDTask = "TKG-000001",
                    Text = "Содержание примесей в масле, %",
                    PresentValue = 50,
                    MinValue = 0,
                    MaxValue = 100,
                    Type = 0
                },
                new TestimonyEntity {
                    IDTask = "TKG-000001",
                    Text = "Уровень рабочей среды",
                    PresentValue = 1,
                    Type = 1
                },
            };
            List<UserEntity> user = new List<UserEntity>() {
                new UserEntity{
                    IDUser = 1,
                    Login = "Гость",
                    Password = ""
                }
            };
            List<TechnicalCardEntity> technicalCard = new List<TechnicalCardEntity>() {
                new TechnicalCardEntity("TKG-000004", "Проведение замены"),
                new TechnicalCardEntity("TKG-000004", "Проведение измерений"),
                new TechnicalCardEntity("TKG-000004", "Осмотр устройства"),
                new TechnicalCardEntity("TKG-000003", "Проведение замены"),
                new TechnicalCardEntity("TKG-000003", "Проведение измерений"),
                new TechnicalCardEntity("TKG-000003", "Осмотр устройства"),
                new TechnicalCardEntity("TKG-000002", "Проведение замены"),
                new TechnicalCardEntity("TKG-000002", "Проведение измерений"),
                new TechnicalCardEntity("TKG-000002", "Осмотр устройства"),
                new TechnicalCardEntity("TKG-000001", "Проведение замены"),
                new TechnicalCardEntity("TKG-000001", "Проведение измерений"),
                new TechnicalCardEntity("TKG-000001", "Осмотр устройства")
            };
            List<TaskEntity> сurrentTasks = new List<TaskEntity>(){
                new TaskEntity
                {
                    IDUser = 1,
                    IDTask = "TKG-000001",
                    TextTask = "Тестовое задание",
                    DateEnd = new DateTime(2016, 12, 29),
                    Address = "г.Москва ул.Покрышкина дом 7",
                    DateStart = new DateTime(2015, 12, 29),
                    Status = 0,
                    Manufacturer = "FG",
                    Mark = "P350",
                    FactoryNomber = "FGWP",
                },
                new TaskEntity
                {
                    IDUser = 1,
                    IDTask = "TKG-000002",
                    TextTask = "Тестовое задание",
                    DateEnd = new DateTime(2016,12,29),
                    Address = "Москва Покрышкина 15",
                    DateStart = new DateTime(2015,12,29),
                    Status = 1,
                    Manufacturer = "FG",
                    Mark = "P350",
                    FactoryNomber = "FGWP",
                },
                new TaskEntity
                {
                    IDUser = 1,
                    IDTask = "TKG-000003",
                    TextTask = "Тестовое задание",
                    DateEnd = new DateTime(2016,12,29),
                    Address = "г.Москва, ул.Покрышкина, дом 2",
                    DateStart = new DateTime(2015,12,29),
                    Status = 2,
                    Manufacturer = "FG",
                    Mark = "P350",
                    FactoryNomber = "FGWP",
                },
                new TaskEntity
                {
                    IDUser = 1,
                    IDTask = "TKG-000004",
                    TextTask = "Тестовое задание",
                    DateEnd = new DateTime(2016,12,29),
                    Address = "г.Москва, ул.Покрышкина, дом 8",
                    DateStart = new DateTime(2015,12,29),
                    Status = 4,
                    Manufacturer = "FG",
                    Mark = "P350",
                    FactoryNomber = "FGWP",
                },
                                new TaskEntity
                {
                    IDUser = 1,
                    IDTask = "TKG-000005",
                    TextTask = "Тестовое задание",
                    DateEnd = new DateTime(2016,12,29),
                    Address = "г.Москва, ул.Покрышкина, дом 12",
                    DateStart = new DateTime(2015,12,29),
                    Status = 4,
                    Manufacturer = "FG",
                    Mark = "P350",
                    FactoryNomber = "FGWP",
                },
                                                new TaskEntity
                {
                    IDUser = 1,
                    IDTask = "TKG-000006",
                    TextTask = "Тестовое задание",
                    DateEnd = new DateTime(2016,12,29),
                    Address = "г.Москва, ул.Покрышкина, дом 6",
                    DateStart = new DateTime(2015,12,29),
                    Status = 4,
                    Manufacturer = "FG",
                    Mark = "P350",
                    FactoryNomber = "FGWP",
                },
                                                                new TaskEntity
                {
                    IDUser = 1,
                    IDTask = "TKG-000007",
                    TextTask = "Тестовое задание",
                    DateEnd = new DateTime(2016,12,29),
                    Address = "г.Москва, ул.Покрышкина, дом 1",
                    DateStart = new DateTime(2015,12,29),
                    Status = 4,
                    Manufacturer = "FG",
                    Mark = "P350",
                    FactoryNomber = "FGWP",
                },
                                                                                new TaskEntity
                {
                    IDUser = 1,
                    IDTask = "TKG-000008",
                    TextTask = "Тестовое задание",
                    DateEnd = new DateTime(2016,12,29),
                    Address = "г.Москва, ул.Покрышкина, дом 20",
                    DateStart = new DateTime(2015,12,29),
                    Status = 4,
                    Manufacturer = "FG",
                    Mark = "P350",
                    FactoryNomber = "FGWP",
                },
            };
            db.InsertAll(user);
            db.InsertAll(сurrentTasks);
            db.InsertAll(technicalCard);
            db.InsertAll(testi);
        }

    }
}
