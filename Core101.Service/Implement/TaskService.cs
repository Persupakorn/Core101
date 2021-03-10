using Core101.Model.DataContaxt;
using Core101.Model.RequestModel;
using Core101.Model.ResponseModel;
using Core101.Repository.Implement;
using Core101.Repository.Interface;
using Core101.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core101.Service.Implement
{
    public class TaskService : ITaskService
    {
        private readonly Core101DataContext _core101DataContext = new Core101DataContext();
        ITaskRepository _task;
        public TaskService(ITaskRepository task)
        {
            _task = task;
        }

        public TaskResponseModel InsertDataTask(TaskRequestModel requestModel)
        {
            var isCreate = validate(requestModel);
            if (!isCreate) return null;

            var result = new TaskResponseModel()
            {
                Brand = requestModel.Brand,
                Costcenter = requestModel.Costcenter,
                TaskCode = requestModel.TaskCode
            };

            _task.Add(result);

            return result;
        }

        public bool validate(TaskRequestModel requestModel)
        {
            if (string.IsNullOrEmpty(requestModel.ProjectCode) ||
                string.IsNullOrEmpty(requestModel.TaskCode) ||
                string.IsNullOrEmpty(requestModel.Brand) ||
                string.IsNullOrEmpty(requestModel.Costcenter) ||
                string.IsNullOrEmpty(requestModel.Brand)
                )
            {
                return false;
            }
            return true;
        }

        public TaskResponseModel GetTaskByProjectCode(string projectCode)
        {
            var taskByProject = _task.GetMany(x => x.ProjectCode != null).ToList();
            if (string.IsNullOrEmpty(projectCode))
            {
                return null;
            }
            else
            {
               var task = taskByProject.FirstOrDefault(p=>p.ProjectCode == projectCode);
                if (task == null) return null;
                var result = new TaskResponseModel()
                {
                    Brand = task.Brand,
                    Cost = task.Cost,
                    Costcenter = task.Costcenter,
                    GenerateMACost = task.GenerateMACost,
                    GenerateMARevenue = task.GenerateMARevenue,
                    ProjectCode = task.ProjectCode,
                    Revenue = task.Revenue,
                    TaskCode = task.TaskCode,
                    TaskID = task.TaskID
                };
                return result;
            }
        }


    }
}
