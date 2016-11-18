using System.Threading.Tasks;
using DAL.Entites;
using System.Collections.Generic;

namespace ServInger.UILogic.Services {
    public interface ITaskService {
        TaskEntity get();
        void set(TaskEntity task);
    }
}