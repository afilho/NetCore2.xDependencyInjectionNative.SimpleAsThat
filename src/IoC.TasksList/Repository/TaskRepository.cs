using Dapper;
using System.Collections.Generic;
using System.Data;
using IoC.TasksList.Models;

namespace IoC.TasksList.Repository
{
    public class TaskRepository : IRepository<TaskModel>
    {
        public IDbConnection Connection { get; private set; }

        public TaskRepository(IDbConnection connection)
        {
            this.Connection = connection;
        }

        public IEnumerable<TaskModel> GetAll()
        {
            string query = "SELECT * FROM TASKS";

            if (this.Connection.State != ConnectionState.Open)
                this.Connection.Open();

            return this.Connection.Query<TaskModel>(query);
        }
    }
}
