using System;
using System.Collections.Generic;

namespace Services
{
    public class ServiceLocator
    {
        private static ServiceLocator _serviceLocator;
        public static ServiceLocator Container => 
            _serviceLocator ??= new ServiceLocator();
        
        private readonly IDictionary<Type, object> _services;

        private ServiceLocator() => 
            _services = new Dictionary<Type, object>();

        public void RegisterService<TService>(TService implementation) =>
            _services.Add(typeof(TService), implementation);

        public TService GetService<TService>() where TService : IService => 
            (TService)_services[typeof(TService)];

        public void Restart() => 
            _services.Clear();
    }
}