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
            var nameServiceMock = Mock.Create<INameService>();
            Mock.Arrange(() => nameServiceMock.GetNamesAsync())
                .Returns(new TaskCompletionSource<Name[]>().Task);
            Services.AddSingleton<INameService>(nameServiceMock);

            // Act
            var cut = RenderComponent<NameList>();

            // Assert
            var htmlContains = "<p><em> Loading...</em></p>";
            cut.Markup.Contains(htmlContains);
        }
    }
}
