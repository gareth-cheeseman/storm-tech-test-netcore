using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Todo.Services;
using Xunit;
using Moq;

namespace Todo.Tests.ServicesTests
{

    public class WhenGettingGravatarName
    {

        private Mock<IGravatar> _mock;

        
        public WhenGettingGravatarName()
        {
            var hash = "1234";
            var name = "potato"; 
            _mock = new Mock<IGravatar>();
            _mock.Setup(n => n.GetGravatarName(hash))
                .ReturnsAsync(name)
                .Verifiable();
        }

    }
}
