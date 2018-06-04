using System;

namespace IoC.TasksList.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public DateTime DataInclusao {get;set; }
        public string Task { get; set; }
    }
}
