using ClassTemplateTools;
using ClassTemplateToolsTests.Extensions;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace ClassTemplateToolsTests
{
    public class Department
    {
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }

    public class Employee
    {
        public Guid EmployeeId { get; set; }

        public string Name { get; set; }
    }

    public class ClassTemplateToolsTests
    {
        private string CurrentFolder => Path.Combine(
            Path.GetFullPath(@"..\..\..\"), "ClassTemplateToolsTests_Result.txt");

        [Fact]
        public void DumpToString()
        {
            var parttern = File.ReadAllText(CurrentFolder)
                               .SplitLine("----------------------------")
                               .First();

            HashSet<Department> sut = new HashSet<Department>()
            {
                new Department()
                {
                    DepartmentId = 1,
                    DepartmentName = "左A",
                    Employees = new []
                    {
                        new Employee
                        {
                            EmployeeId = Guid.Parse("becc484a-d8f7-4569-ad35-720fe7a454fb"),
                            Name = "Jason",
                        }
                    }
                }
            };

            var result = sut.DumpToString();

            result.Should().Be(parttern);
        }
    }
}
