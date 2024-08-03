using AppTask.DataBase;
using AppTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTask.Repositories
{
    public class TaskModelRepository : ITaskModelRepository
    {
        AppTaskContext _db;

        public TaskModelRepository()
        {
            _db = new AppTaskContext();
        }

        public IList<TaskModel> GetAll()
        {
            return _db.Tasks.OrderByDescending(a => a.PrevisionDate).ToList();
        }

        public TaskModel GetById(int id)
        {
            return _db.Tasks.Include(a => a.SubTasks).FirstOrDefault(a => a.Id == id);
        }

        public void Add(TaskModel task)
        {
            _db.Tasks.Add(task);
            _db.SaveChanges();
        }

        public void Update(TaskModel task)
        {
            _db.Tasks.Update(task);
            _db.SaveChanges();
        }

        public void Delete(TaskModel task)
        {
            task = GetById(task.Id);
            
            //remove as subtarefas
            foreach(var taskModel in task.SubTasks) 
            {
                _db.SubTasks.Remove(taskModel); 
            }

            //remove a tarefa
            _db.Tasks.Remove(task);
            _db.SaveChanges();
        }
    }
}
