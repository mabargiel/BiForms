using System;
using System.Collections.Generic;
using Autofac;
using BTopService.BiForms.BuildingBlocks.EventBus.Abstractions;

namespace BTopService.BiForms.BuildingBlocks.EventBus.AutofacModules
{
    public class EventsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
    
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(x => x.IsAssignableTo<IHandleEvents>())
                .AsImplementedInterfaces();
    
            builder.Register<Func<Type, IEnumerable<IHandleEvents>>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();
                return t =>
                {
                    var handlerType = typeof(IHandleEvents<>).MakeGenericType(t);
                    var handlersCollectionType = typeof(IEnumerable<>).MakeGenericType(handlerType);
                    return (IEnumerable<IHandleEvents>)ctx.Resolve(handlersCollectionType);
                };
            });
    
            builder.RegisterType<EventsBus>()
                .AsImplementedInterfaces();
        }
    }
}