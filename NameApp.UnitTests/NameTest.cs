using System;
using Xunit;
using Bunit;
using System.Threading.Tasks;
using Telerik.JustMock;
using Microsoft.Extensions.DependencyInjection;
using NameApp.Client.Pages;
using NameApp.Shared;

namespace NameApp.UnitTests
{
    public class NameTest : TestContext
    {
        [Fact]
        public void TestNameListRendering()
        {
            // Act
            var cut = RenderComponent<NameList>();

            // Assert
            cut.Find("h2").MarkupMatches("<h2>Name List</h2>");
        }
    }
}
