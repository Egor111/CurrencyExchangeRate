namespace Base.IOC.Extensions
{
    using Castle.Windsor;
    using Castle.MicroKernel.Registration;
    using System;

    public static class WindsorExtensions
    {
        /// <summary>Зарегистрировать имплементацию как Transient</summary>
        /// <typeparam name="TService">Интерфейс</typeparam>
        /// <typeparam name="TImpl">Имплементация</typeparam>
        /// <param name="container">Контайнер</param>
        /// <param name="name">Имя для регистрации</param>
        public static void RegisterTransient<TService, TImpl>(this IWindsorContainer container, string name = null)
            where TService : class
            where TImpl : TService
        {
            Component
                .For<TService>()
                .ImplementedBy<TImpl>()
                .Named(name)
                .LifestyleTransient()
                .RegisterIn(container);
        }

        /// <summary>Зарегистрировать имплементацию как Singleton</summary>
        /// <typeparam name="TService">Интерфейс</typeparam>
        /// <typeparam name="TImpl">Имплементация</typeparam>
        /// <param name="container">Контайнер</param>
        /// <param name="name">Имя для регистрации</param>
        public static void RegisterSingleton<TService, TImpl>(this IWindsorContainer container, string name = null)
            where TService : class
            where TImpl : TService
        {
            Component
                .For<TService>()
                .ImplementedBy<TImpl>()
                .Named(name)
                .LifestyleSingleton()
                .RegisterIn(container);
        }

        /// <summary>
        /// Регистрация компонента в контейнере
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="registration"></param>
        /// <param name="container"></param>
        public static void RegisterIn<T>(this ComponentRegistration<T> registration, IWindsorContainer container)
            where T : class
        {
            if (registration == null)
            {
                throw new ArgumentNullException("registration");
            }

            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            container.Register(registration);
        }
    }
}
