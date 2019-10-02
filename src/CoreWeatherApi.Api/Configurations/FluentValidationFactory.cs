
using System;
using FluentValidation;
using SimpleInjector;

namespace CoreWeatherApi.Api.Configurations
{
    public class FluentValidationFactory : IValidatorFactory
    {
        private Container _contianer;

        public FluentValidationFactory(Container container)
        {
            _contianer = container;
        }
        public IValidator<T> GetValidator<T>()
        {
            return _contianer.GetInstance<IValidator<T>>();
        }

        public IValidator GetValidator(Type type)
        {
            var validator = typeof(IValidator<>).MakeGenericType(type);
            return (IValidator)_contianer.GetInstance(validator);
        }
    }
}