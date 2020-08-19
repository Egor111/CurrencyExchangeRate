namespace Base.IOC.Interfaces
{
    using Castle.Windsor;

    /// <summary>
    /// Интерфейс кастомной регистрации сервисов в компоненте.
    /// </summary>
    public interface IWindsorServiceRegistration
    {
        /// <summary>
        /// Регистрация сервисов в контейнере.
        /// </summary>
        /// <param name="container">IWindsorContainer</param>
        void RegisterService(IWindsorContainer container);
    }
}
