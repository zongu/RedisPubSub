
namespace RedisPubSub.Applibs
{
    using System.Linq;
    using System.Reflection;
    using Autofac;
    using RedisPubSub.Doamin.Model;

    internal static class AutofacConfig
    {
        private static IContainer container;

        public static IContainer Container
        {
            get
            {
                if (container == null)
                {
                    Register();
                }

                return container;
            }
        }

        public static void Register()
        {
            var builder = new ContainerBuilder();
            var asm = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(asm)
                .Where(t => t.IsAssignableTo<IRedisPubSubHandler>())
                .Named<IPubSubHandler<RedisEventStream>>(t => t.Name.Replace("Handler", string.Empty))
                .SingleInstance();

            container = builder.Build();
        }
    }
}
