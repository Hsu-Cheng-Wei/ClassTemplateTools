using ClassTemplateTools.TypeHelp.Enumerable;
using ClassTemplateToolsTests.Extensions;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit;

namespace ClassTemplateToolsTests.TypeHelp.Enumerable
{
    public class ArrayTypeHelpeTests
    {
        private string CurrentFolder => Path.Combine(
            Path.GetFullPath(@"..\..\..\"), "TypeHelp/Enumerable/ArrayTypeHelpTests_ToConstructString_Result.txt");

        [Fact]
        public void BaseName()
        {
            var su = new ArrayTypeHelpe();
            var result = su.BaseName(new[] { 1, 2, 3 });
            result.Should().Be("int");
        }

        [Fact]
        public void BaseComplicateName()
        {
            var su = new ArrayTypeHelpe();
            var result = su.BaseName(new[] { new[] { 1, 2, 3 } });
            result.Should().Be("int");
        }

        [Fact]
        public void Int32ToConstructString()
        {
            var parttern = File.ReadAllText(CurrentFolder)
                               .SplitLine("----------------------------")
                               .First();

            var su = new ArrayTypeHelpe();
            var result = su.ToConstructString(new[] { 1, 2, 3 });
            result.Should().Be(parttern);
        }

        [Fact]
        public void GuidToConstructString()
        {
            var parttern = File.ReadAllText(CurrentFolder)
                               .SplitLine("----------------------------")
                               .ToArray()[1];

            var su = new ArrayTypeHelpe();
            var result = su.ToConstructString(new[]
            {
                Guid.Parse("47627a86-846c-4f70-ab04-7d40eb6227ec"),
                Guid.Parse("8d94ecd1-4a62-4a87-a786-690e7fdb7034")
            });
            result.Should().Be(parttern);
        }

        [Fact]
        public void ComplicateToConstructString()
        {
            var parttern = File.ReadAllText(CurrentFolder)
                               .SplitLine("----------------------------")
                               .ToArray()[2];

            var su = new ArrayTypeHelpe();
            var result = su.ToConstructString(new[]
            {
                new List<Guid>()
                {
                    Guid.Parse("47627a86-846c-4f70-ab04-7d40eb6227ec"),
                    Guid.Parse("8d94ecd1-4a62-4a87-a786-690e7fdb7034"),
                }
            });
            result.Should().Be(parttern);
        }
    }
}
