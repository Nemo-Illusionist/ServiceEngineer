using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Manager {
    public class DBTaskManager : IDBTaskManager {

        public List<TaskEntity> getTaskList(UserEntity User) {
            try {
                var db = new DBConnection();
                return db.Table<TaskEntity>().Where(x => x.IDUser == User.IDUser).ToList();
            } catch {
                throw new Exception("Ошибка Базы данных");
            }
        }

        public List<TestimonyEntity> getTestimony(TaskEntity Task) {
            try {
                var db = new DBConnection();
                return db.Table<TestimonyEntity>().Where(x => x.IDTask == Task.IDTask).OrderBy(x => x.Type).ToList();
            } catch {
                throw new Exception("Ошибка Базы данных");
            }
        }

        public List<TechnicalCardEntity> getTechCard(TaskEntity Task) {
            try {
                var db = new DBConnection();
                return db.Table<TechnicalCardEntity>().Where(x => x.IDTask == Task.IDTask).ToList();
            } catch {
                throw new Exception("Ошибка Базы данных");
            }
        }

        //public int setTask(List<TaskEntity> tasc) {
        //    var db = new DBConnection();
        //    return db.InsertAll(tasc);
        //}

        //public int setTestimony(List<TestimonyEntity> Testimony) {
        //    var db = new DBConnection();
        //    return db.InsertAll(Testimony);
        //}

        //public int setTechCard(List<TechnicalCardEntity> TechCard) {
        //    var db = new DBConnection();
        //    return db.InsertAll(TechCard);
        //}

        public int setPhoto(TaskEntity Task, string Path) {
            var db = new DBConnection();
            var photo = new PhotoEntity {
                IDTask = Task.IDTask,
                Path = Path,
            };
            return db.Insert(photo);
        }

        public List<PhotoEntity> getPhoto(TaskEntity Task) {
            try {
                var db = new DBConnection();
                return db.Table<PhotoEntity>().Where(x => x.IDTask == Task.IDTask).ToList();
            } catch {
                throw new Exception("Ошибка Базы данных");
            }
        }

        public int updateTask(TaskEntity tasc) {
            try {
                var db = new DBConnection();
                return db.Update(tasc);
            } catch {
                throw new Exception("Ошибка Базы данных. Изменения не были сохранены");
            }
        }

        public int updateTestimony(List<TestimonyEntity> Testimony) {
            try {
                var db = new DBConnection();
                return db.UpdateAll(Testimony);
            } catch {
                throw new Exception("Ошибка Базы данных. Изменения не были сохранены");
            }
        }

        public int updateTechCard(List<TechnicalCardEntity> TechCard) {
            try {
                var db = new DBConnection();
                return db.UpdateAll(TechCard);
            } catch {
                throw new Exception("Ошибка Базы данных. Изменения не были сохранены");
            }
        }
    }
}
