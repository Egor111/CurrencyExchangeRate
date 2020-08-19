namespace WebHost
{
    using Base.EF.Interfaces;
    using Base.IOC.Extensions;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using CurrencyExchangeRate.Entities;
    using CurrencyExchangeRate.Interfaces;
    using CurrencyExchangeRate.Repository;
    using CurrencyExchangeRate.Services;
    using System.Net.Http;

    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            BaseRegister(container, store);
            CustomRegister(container, store);
        }

        /// <summary>
        /// Регистрация базового функционала.
        /// </summary>
        private void BaseRegister(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<HttpClient>().LifeStyle.Singleton);
        }

        /// <summary>
        /// Регистрация пользовательских функционала
        /// </summary>
        private void CustomRegister(IWindsorContainer container, IConfigurationStore store)
        {
            container.RegisterTransient<IGetDataForUrl, GetDataForUrl>();
            //container.RegisterTransient<ICurrencyExchangeRateCreateService, CurrencyExchangeRateCreateService>();
            container.RegisterTransient<IExchangeRateCreateService, ExchangeRateCreateService>();

            container.RegisterTransient<IRepository<ExchangeRate>, ExchangeRateRepository>();
            container.RegisterTransient<IRepository<CurrencyCodesReference>, CurrencyCodesReferenceRepository>();
            
        }
    }
}
