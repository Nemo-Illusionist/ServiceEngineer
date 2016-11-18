using DAL.Manager;
using DAL.Entites;

namespace ServInger.UILogic.Services {
    public class TaskService : ITaskService {
        private TaskEntity _task;

        private readonly IDBTaskManager _dbTaskManager;

        public TaskService(IDBTaskManager DBTaskManager) {
            _dbTaskManager = DBTaskManager;
        }

        public void set(TaskEntity task) {
            _task = task;
        }

        public TaskEntity get() {
            return _task;
        }
    }
}
