using Core101.Model.Entity;
using Core101.Reporitory.Base;
using Core101.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core101.Repository.Implement
{
    public class TaskRepository : Repository<Task>, ITaskRepository
    {
        public TaskRepository(DbContext context) : base(context) { }

    }
}
