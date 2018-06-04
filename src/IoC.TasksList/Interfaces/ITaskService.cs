using System.Collections.Generic;

namespace IoC.TasksList.Interfaces
{
    public interface ITaskService
    {
        int Plus(int i, int p);
        IEnumerable<Models.TaskModel> GetAll();
    }
}
