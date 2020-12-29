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
            // Arrange
            var nameServiceMock = Mock.Create<INameService>();        //INameService tarjoaa HtmlClientin
            Mock.Arrange(() => nameServiceMock.GetNamesAsync())       //jota sivun renderöinti edellyttää
                .Returns(new TaskCompletionSource<Name[]>().Task);
            Services.AddSingleton<INameService>(nameServiceMock);

            // Act
            var cut = RenderComponent<NameList>();

            // Assert
            var htmlContains = "<p><em> Loading...</em></p>";
            cut.Markup.Contains(htmlContains);
        }

        [Fact]
        public void CounterTest()
        {
            var cut = RenderComponent<Counter>();
            cut.Find("p").MarkupMatches("<p>Current count: 0</p>");

            // Act
            var element = cut.Find("button");
            element.Click();

            // Assert
            cut.Find("p").MarkupMatches("<p>Current count: 1</p>");
        }
    }
}
