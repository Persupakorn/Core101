using Core101.Model.RequestModel;
using Core101.Model.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core101.Service.Interface
{
    public interface ITaskService
    {
        TaskResponseModel InsertDataTask(TaskRequestModel requestModel);
        TaskResponseModel GetTaskByProjectCode(string projectCode);
    }
}
