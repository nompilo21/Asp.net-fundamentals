using Microsoft.Isam.Esent.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Data.Models;

namespace ToDo.Data.Services
{
    public class InMemoryTaskData : ITask
    {
        List<TaskDetails> tasks;
        public InMemoryTaskData()
        {
            tasks = new List<TaskDetails>()
                {
                    new TaskDetails {TaskId=1, Title="Coffee meeting", Description="Discuss steercom meeting", Status=StatusType.InProgress, Priority=PriorityType.High},
                    new TaskDetails {TaskId=2, Title="Cook", Description="make mac n cheese", Status=StatusType.NotDone, Priority=PriorityType.Low}
                };
        }

        //adds to task to list of tasks
        public void Add(TaskDetails task)
        {
            tasks.Add(task);
            task.TaskId = tasks.Max(r => r.TaskId) + 1;
        }

        //edit tasks
        public TaskDetails Update(TaskDetails task)
        {
            var existing = Get(task);// (task.TaskId);
            
            if(existing != null)
            {
                existing.Title = task.Title;
                existing.Description = task.Description;
                existing.Status = task.Status;
                existing.Priority = task.Priority;
            }
            return existing;
        }

        //gets an existing task
        public IEnumerable<TaskDetails> GetTask()
        {
            return tasks.OrderBy(r => r.TaskId);
        }

        //gets task by taskdetails
        public TaskDetails Get(TaskDetails task)
        {
            return tasks.FirstOrDefault(r => r.Title == task.Title && r.Description == task.Description && r.Status == task.Status);
            //return tasks.FirstOrDefault(r => r.TaskId == id);
        }

        //gets task by id
        public TaskDetails Get(int id)
        {
            return tasks.FirstOrDefault(r => r.TaskId == id);
        }

        void ITask.Update(TaskDetails task)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        //public void Update(TaskDetails task) => throw new NotImplementedException();
    }
}
