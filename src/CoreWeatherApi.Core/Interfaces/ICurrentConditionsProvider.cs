using System.Collections.Generic;
using CoreWeatherApi.Core.Dtos;

namespace CoreWeatherApi.Core.Interfaces
{
    public interface ICurrentConditionsProvider
    {
        IEnumerable<CurrentConditionsDto> Get();
    }
}