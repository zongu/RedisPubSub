
namespace RedisPubSub.Doamin.Applibs
{
    using System;
    using Autofac;
    using RedisPubSub.Doamin.Model;

    public class PubSubDispatcher<TEventStream> : IPubSubDispatcher<TEventStream>
            where TEventStream : EventStream
    {
        private IContainer container;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="container"></param>
        /// <param name="errorCallBack"></param>
        public PubSubDispatcher(IContainer container)
        {
            this.container = container;
        }

        public void DispatchMessage(TEventStream stream)
        {
            try
            {
                using (var scope = container.BeginLifetimeScope())
                {
                    var handler = scope.ResolveNamed<IPubSubHandler<TEventStream>>(stream.Type);
                    handler.Handle(stream);
                }
            }
            catch (Autofac.Core.Registration.ComponentNotRegisteredException)
            {
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DispatchMessage Exception:{ex.Message}");
            }
        }
    }
}
