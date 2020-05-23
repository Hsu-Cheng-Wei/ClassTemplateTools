using ClassTemplateTools.TypeHelp.Enumerable;
using ClassTemplateToolsTests.Extensions;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace ClassTemplateToolsTests.TypeHelp.Enumerable
{
    public class Demo { }

    public class ListTypeHelpTests
    {
        private string CurrentFolder => Path.Combine(
            Path.GetFullPath(@"..\..\..\"), "TypeHelp/Enumerable/ListTypeHelpTests_ToConstructString_Result.txt");

        [Fact]
        public void BaseName()
        {
            var su = new ListTypeHelp();
            var result = su.BaseName(new List<int> { 1, 2, 3 });
            result.Should().Be("List<int>");
        }

        [Fact]
        public void BaseComplicateName()
        {
            var su = new ListTypeHelp();
            var result = su.BaseName(new List<List<int>> { new List<int> { 1, 2, 3 } });
            result.Should().Be("List<List<int>>");
        }

        [Fact]
        public void Int32ToConstructString()
        {
            var parttern = File.ReadAllText(CurrentFolder)
                               .SplitLine("----------------------------")
                               .First();

            var su = new ListTypeHelp();
            var result = su.ToConstructString(new List<int> { 1, 2, 3 });
            result.Should().Be(parttern);
        }

        [Fact]
        public void ObjectToConstructString()
        {
            var parttern = File.ReadAllText(CurrentFolder)
                               .SplitLine("----------------------------")
                               .ToArray()[1];

            var su = new ListTypeHelp();
            var result = su.ToConstructString(new List<Demo> { new Demo() });
            result.Should().Be(parttern);
        }
    }
}
