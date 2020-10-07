using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Data.Models;

namespace ToDo.Data.Services
{
    public interface ITask
    {
        IEnumerable<TaskDetails> GetTask();
        TaskDetails Get(int id);
        void Add(TaskDetails task);
        void Update(TaskDetails task);
        void Delete(int id);
        IEnumerable<TaskDetails> GetTaskSearch(string title);


    }
}
