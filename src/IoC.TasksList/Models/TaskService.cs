using IoC.TasksList.Interfaces;

namespace IoC.TasksList.Models
{
    public class TaskService : ITaskService
    {
        public int Plus(int i, int p)
        {
            i += p;
            return i;
        }
    }
}
