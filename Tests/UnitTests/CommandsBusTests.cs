using System;
using Infrastructure;
using NSubstitute;
using Xunit;

namespace UnitTests
{
    public class CommandsBusTests
    {
        [Fact]
        public void CommandsBusTest()
        {
            //Arrange
            var command = Substitute.For<ICommand>();
            var handler = Substitute.For<IHandleCommand<ICommand>>();
            var bus = new CommandsBus(t => handler);

            //Run
            bus.Send(command);

            //Assert
            handler.Received().Handle(command);
        }
    }
}
