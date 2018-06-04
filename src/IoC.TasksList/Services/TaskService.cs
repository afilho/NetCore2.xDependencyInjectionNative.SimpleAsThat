using IoC.TasksList.Interfaces;
using IoC.TasksList.Models;
using IoC.TasksList.Repository;
using System.Collections.Generic;

namespace IoC.TasksList.Services
{
    public class TaskService : ITaskService
    {
        public IRepository<TaskModel> Repository { get; private set; }

        public TaskService(IRepository<TaskModel> repository)
        {
            this.Repository = repository;
        }

        public IEnumerable<Models.TaskModel> GetAll()
        {
            return this.Repository.GetAll();
        }

        public int Plus(int i, int p)
        {
            i += p;
            return i;
        }
    }
}
