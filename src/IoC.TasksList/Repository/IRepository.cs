using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoC.TasksList.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
    }
}
