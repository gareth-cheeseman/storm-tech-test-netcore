using Moq;
using Todo.Services;

namespace Todo.Tests.ServicesTests
{
    public class MockGravatar : Mock<IGravatar> {


        public MockGravatar GetHash(string output)
        {
            Setup(g => g.GetHash(It.IsAny<string>())).Returns(output);
            return this;
        }

        public MockGravatar GetGravatarName(string hash, string output)
        {
            Setup(g => g.GetGravatarName(It.Is<string>(h => h == hash))).ReturnsAsync(output);
            return this;
        }

        public MockGravatar GetGravatarImage(string hash, string output)
        {
            Setup(g => g.GetGravatarImage(It.Is<string>(h => h == hash))).ReturnsAsync(output);
            return this;
        }

   
    }

}
