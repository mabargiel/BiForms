using System.Collections.Generic;
using Infrastructure;
using NSubstitute;
using Xunit;

namespace UnitTests
{
    public class EventsBusTests
    {
        [Fact]
        public void EventsBusTest()
        {
            //Arrange
            var @event = Substitute.For<IEvent>();
            var handler1 = Substitute.For<IHandleEvents<IEvent>>();
            var handler2 = Substitute.For<IHandleEvents<IEvent>>();
            var bus = new EventsBus(x => new List<IHandleEvents>{handler1, handler2});

            //Run
            bus.Send(@event);

            //Assert
            handler1.Received().Handle(@event);
            handler2.Received().Handle(@event);
        }
    }
}
