using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClassTemplateTools;
using ClassTemplateToolsTests.Extensions;
using FluentAssertions;
using Xunit;

namespace ClassTemplateToolsTests
{
    public class RecursiveTests
    {
        public class Department
        {
            public Department()
            {
                Employees = new List<Employee>();
                InverseParentDepartment = new List<Department>();
            }

            public int DepartmentId { get; set; }
            public int CompanyId { get; set; }
            public string DepartmentName { get; set; }
            public string OracleDepartmentId { get; set; }

            public virtual Department ParentDepartment { get; set; }

            public virtual ICollection<Employee> Employees { get; set; }
            public virtual ICollection<Department> InverseParentDepartment { get; set; }
        }

        public partial class Employee
        {
            public string EmployeeId { get; set; }

            public Guid? UserId { get; set; }

            public int? DepartmentId { get; set; }

            public int? PositionId { get; set; }

            public string EmailAddr { get; set; }

            public string TelExt { get; set; }

            public string EmployeeCardId { get; set; }

            public int? SalaryTypeId { get; set; }

            public virtual Department Department { get; set; }
        }

        private string CurrentFolder => Path.Combine(
            Path.GetFullPath(@"..\..\..\"), "RecursiveTests_Result.txt");

        [Fact]
        public void DumpToString()
        {
            var parttern = File.ReadAllText(CurrentFolder)
                               .SplitLine("----------------------------")
                               .First();

            var employee = new Employee
            {
                EmployeeId = "77011",
                UserId = Guid.Parse("190b8133-77d7-4c47-b5cd-6ece1a4d5fb8"),
                DepartmentId = 1,
                PositionId = 3,
                EmailAddr = "wulj@boltun.com.tw",
                TelExt = "15223",
                EmployeeCardId = "0000000899",
                SalaryTypeId = 1,
            };
            var department = new Department
            {
                DepartmentId = 1,
                CompanyId = 1,
                DepartmentName = "總經理室",
                OracleDepartmentId = "1",
            };

            employee.Department = department;
            department.Employees.Add(employee);

            var result = employee.DumpEnityToString();

            result.Should().Be(parttern);
        }

    }
}
