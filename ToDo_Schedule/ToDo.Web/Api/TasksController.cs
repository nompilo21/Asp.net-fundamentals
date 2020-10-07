using Antlr.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using ToDo.Data.Models;
using ToDo.Data.Services;

namespace ToDo.Web.Api
{
    public class TasksController : ApiController
    {
        private readonly ITask db;
        public TasksController(ITask db)
        {
            this.db = db;
        }

      
       //returns an iEnumerable of restaurants
        public IEnumerable<TaskDetails> Get()
        {
            var model = db.GetTask();
            return model;
        }
    }
}
