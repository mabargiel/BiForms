using System;
using Infrastructure;
using NSubstitute;
using Xunit;

namespace UnitTests
{
    public class CommandsBusTests
    {
        [Fact]
        public void Given_command_and_bus_when_send_command_the_command_is_handled()
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
