using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService.Services
{
    public class StudentService : Student.StudentBase
    {
        private readonly ILogger<StudentService> _logger;
        private readonly List<StudentInfo> students = new List<StudentInfo>
        {
            new StudentInfo{User =new UserInfo{Id=1,Name="Marat",Surname="Mukiyat",Gender=true},Gpa=4.0},
            new StudentInfo{User =new UserInfo{Id=2,Name="Edil",Surname="Kuat",Gender=true},Gpa=3.5},
            new StudentInfo{User =new UserInfo{Id=3,Name="Wlar",Surname="Maden",Gender=true},Gpa=3.6},
            new StudentInfo{User =new UserInfo{Id=4,Name="Magzhan",Surname="Zhaks",Gender=true},Gpa=3.0},
            new StudentInfo{User =new UserInfo{Id=5,Name="Make",Surname="Eren",Gender=true},Gpa=3.22},
            new StudentInfo{User =new UserInfo{Id=6,Name="Beka",Surname="Zangar",Gender=true},Gpa=3.98},

        };

        public StudentService(ILogger <StudentService> logger)
        {
            _logger = logger;
        }
        public override Task<StudentInfo> GetStudent(StudentLookUp request, ServerCallContext context)
        {
            var student = students.Where(x => x.User.Id == request.Id).FirstOrDefault();
            return Task.FromResult(student);
        }
        public override async Task GetAllStudents(StudentAllLoopUp request, 
            IServerStreamWriter<StudentInfo> responseStream, ServerCallContext context)
        {
            foreach (var student in students)
            {
                await Task.Delay(1000);
                await responseStream.WriteAsync(student);



            }
        }
    }
}
