using ClassTemplateTools;
using ClassTemplateTools.TypeHelp.ObjectType;
using ClassTemplateToolsTests.Extensions;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace ClassTemplateToolsTests.TypeHelp.ObjectType
{
    public class DateTimeTypeTypeHelpTests
    {
        private string CurrentFolder => Path.Combine(
            Path.GetFullPath(@"..\..\..\"), "TypeHelp/ObjectType/DateTimeTypeHelpTests_ToConstructString_Result.txt");

        [Fact]
        public void BaseName()
        {
            var su = new DateTimeTypeHelp();
            var result = su.BaseName(new DateTime(2020, 05, 25));
            result.Should().Be("DateTime");
        }

        [Fact]
        public void ToConstructString()
        {
            var parttern = File.ReadAllText(CurrentFolder)
                               .SplitLine("----------------------------")
                               .First();

            var su = new DateTimeTypeHelp();
            var result = su.ToConstructString(new DateTime(2020, 05, 25));
            result.Should().Be(parttern);
        }

        [Fact]
        public void ReassemblyStringInBrackets()
        {
            var parttern = File.ReadAllText(CurrentFolder)
                               .SplitLine("----------------------------")
                               .ToArray()[1];

            var su = new DateTimeTypeHelp();
            var result = new[]
            {
                new DateTime(2020, 05, 25),
                new DateTime(2020, 05, 26, 01, 26, 17),
            }.DumpToString();
            result.Should().Be(parttern);
        }
    }
}
