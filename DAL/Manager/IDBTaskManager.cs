using System.Collections.Generic;
using DAL.Entites;

namespace DAL.Manager {
    public interface IDBTaskManager {
        List<TaskEntity> getTaskList(UserEntity User);
        List<TechnicalCardEntity> getTechCard(TaskEntity Task);
        List<TestimonyEntity> getTestimony(TaskEntity Task);
        List<PhotoEntity> getPhoto(TaskEntity Task);
        //int setTask(List<TaskEntity> tasc);
        //int setTechCard(List<TechnicalCardEntity> TechCard);
        //int setTestimony(List<TestimonyEntity> Testimony);
        int setPhoto(TaskEntity Task, string Path);
        int updateTask(TaskEntity tasc);
        int updateTechCard(List<TechnicalCardEntity> TechCard);
        int updateTestimony(List<TestimonyEntity> Testimony);
    }
}