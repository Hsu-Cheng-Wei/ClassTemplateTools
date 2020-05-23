using ClassTemplateTools.TypeHelp.ObjectType;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace ClassTemplateToolsTests.TypeHelp
{
    public class Production
    {
        public Guid Id { get; set; }

        public string Name { get; set; }


        public int Count { get; set; }

        public float Price { get; set; }
    }

    public class ObjectTypeHelpTests
    {
        private string CurrentFolder => Path.Combine(
            Path.GetFullPath(@"..\..\..\"), "TypeHelp/ObjectTypeHelpTests_ToConstructString_Result.txt");

        [Fact]
        public void BaseName()
        {
            var su = new ObjectTypeHelp();
            var result = su.BaseName(new Production());
            result.Should().Be(nameof(Production));
        }

        [Fact]
        public void ToConstructString()
        {
            var parttern = File.ReadAllText(CurrentFolder);

            var su = new ObjectTypeHelp();
            var result = su.ToConstructString(new Production
            {
                Id = Guid.Parse("47627a86-846c-4f70-ab04-7d40eb6227ec"),
                Name = "Apple",
                Count = 4,
                Price = 2.5F,
            });
            result.Should().Be(parttern);
        }
    }
}
