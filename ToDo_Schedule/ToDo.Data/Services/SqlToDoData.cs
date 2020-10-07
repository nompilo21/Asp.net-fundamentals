using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using ToDo.Data.Models;

namespace ToDo.Data.Services
{
    public class SqlToDoData : ITask
    {
        //create database instance
        private readonly ToDoDbContext db;

        //db constructor
        public SqlToDoData(ToDoDbContext db)
        {
            this.db = db;
        }

        //Add Task
        public void Add(TaskDetails task)
        {
            db.Tasks.Add(task);
            db.SaveChanges();
        }

        //get enum properties task
        public TaskDetails Get(int id)
        {
            return db.Tasks.FirstOrDefault(r => r.TaskId == id);
        }

        //Get Task by id
        public IEnumerable<TaskDetails> GetTask()
        {
            return from r in db.Tasks
                   orderby r.TaskId
                   select r;
        }

        //update Task
        public void Update(TaskDetails task)
        {
            var entry = db.Entry(task);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        //Delete Task
        public void Delete(int id)
        {
            var task = db.Tasks.Find(id);
            db.Tasks.Remove(task);
            db.SaveChanges();
        }
        //search method
        public IEnumerable<TaskDetails> GetTaskSearch(string title)
        {
            return from r in db.Tasks
                   orderby r.TaskId
                   select r;
        }
    }
}
