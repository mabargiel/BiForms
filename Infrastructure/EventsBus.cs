using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure
{
    public class EventsBus : IEventsBus
    {
        private readonly Func<Type, IEnumerable<IHandleEvents>> _handlersFactory;
        public EventsBus(Func<Type, IEnumerable<IHandleEvents>> handlersFactory)
        {
            _handlersFactory = handlersFactory;
        }

        public void Send<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var handlers = _handlersFactory(typeof(TEvent)).Cast<IHandleEvents<TEvent>>();
            foreach (var handler in handlers)
            {
                handler.Handle(@event);
            }
        }
    }
}
