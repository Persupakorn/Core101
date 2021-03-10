
using Castle.Core.Configuration;
using Core101.API.Controllers;
using Core101.Core.Config;
using Core101.Model.DataContaxt;
using Core101.Model.Entity;
using Core101.Model.RequestModel;
using Core101.Model.ResponseModel;
using Core101.Repository.Implement;
using Core101.Repository.Interface;
using Core101.Service.Implement;
using Core101.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnitTestCore101
{
    public class TaskControllerTest
    {
        private Mock<ITaskRepository> _task;
        private TaskService sut;

        public TaskControllerTest()
        {
            var mock = new MockRepository(MockBehavior.Default);
            _task = mock.Create<ITaskRepository>();
            sut = new TaskService(_task.Object);
        }
        [Theory(DisplayName = "insert task ไม่สำเร็จ")]
        [InlineData("test", null, null, null)]
        [InlineData("test", "", "", "")]
        [InlineData("test", "2313", "", "")]
        public void Test1(string projectCode, string brand, string task, string costcenter)
        {
            var response = new TaskRequestModel()
            {
                Brand = brand,
                Costcenter = costcenter,
                TaskCode = task,
                ProjectCode = projectCode
            };
            var result = sut.InsertDataTask(response);
            Assert.Null(result);
        }

        [Theory(DisplayName = "insert task สำเร็จ")]
        [InlineData("1231", "test", "2313", "asd")]
        public void Test2(string projectCode, string brand, string task, string costcenter)
        {
            var response = new TaskRequestModel()
            {
                Brand = brand,
                Costcenter = costcenter,
                TaskCode = task,
                ProjectCode = projectCode
            };
            var result = sut.InsertDataTask(response);
            var expexted = (result != null) ? true : false;
            Assert.True(expexted);
        }

        [Theory(DisplayName = "หาโปรเจค ไม่เจอในระบบ")]
        [InlineData("123", null, null, null)]
        [InlineData(null, null, null, null)]
        [InlineData("", null, null, null)]
        public void Test3(string projectCode, string brand, string task, string costcenter)
        {
            var tasks = new List<Task>()
            {
               new Task(){
                    TaskID = 1,
                    ProjectCode = "555",
                    TaskCode = task,
                    Revenue = 0,
                    Brand = brand,
                    Cost = 0,
                    Costcenter = costcenter,
                    GenerateMACost = 1,
                    GenerateMARevenue = 2
               }
            };
            _task.Setup(x => x.GetMany(x => x.ProjectCode != null)).Returns(tasks);

            var result = sut.GetTaskByProjectCode(projectCode);
            Assert.Null(result);
        }
    }
}



//insert task by mpm
//normal
//    insert task ไม่สำเร็จ ส่งค่าผิด format มา
//    insert task สำเร็จ 

//    หาโปรเจค ไม่เจอในระบบ
//alternative
//    คนที่ insert ไม่มีสิทธิ์

//exception