using System;
using System.Collections.Generic;
using System.Linq;
using CoreWeatherApi.Core.Dtos;
using CoreWeatherApi.Core.Interfaces;

namespace CoreWeatherApi.Core.Providers
{
    public class CurrentConditionsProvider : ICurrentConditionsProvider
    {
        public IEnumerable<CurrentConditionsDto> Get()
        {
            var retValue = new List<CurrentConditionsDto>
            { 
                AlderaanConditions, 
                HothConditions, 
                NabooConditions, 
                DagobahConditions,
                JakkuConditions, 
                BatuConditions
            };

            return retValue.OrderBy(x => x.Name).AsEnumerable();
        }
        public CurrentConditionsDto AlderaanConditions => new CurrentConditionsDto()
        {
            Name = "Alderaan",
            Description = "NaN",
            Temperature = "NaN",
            RelativeHumidity = "NaN",
            Visibility = "None",
            Time = "NaN",
            Type = "NaN"
        };
        public CurrentConditionsDto HothConditions => new CurrentConditionsDto()
        {
            Name = "Hoth",
            Description = "It's very cold here",
            Temperature = "-76",
            RelativeHumidity = "0",
            Visibility = "Very little",
            Time = GetTime(31, 21, 81, 6),
            Type = "Frigid"
        };

        public CurrentConditionsDto NabooConditions => new CurrentConditionsDto()
        {
            Name = "Naboo",
            Description = "It's all good here",
            Temperature = "76",
            RelativeHumidity = "10%",
            Visibility = "Good",
            Time = GetTime(2, 0, 41, 25),
            Type = "Sunny"
        };

        public CurrentConditionsDto DagobahConditions => new CurrentConditionsDto()
        {
            Name = "Degobah",
            Description = "Very rainy with violent lightning",
            Temperature = "91",
            RelativeHumidity = "100%",
            Visibility = "Ok",
            Time =  GetTime(-71, 6, 33, 0),
            Type = "Violently Storming"
        };
        public CurrentConditionsDto JakkuConditions => new CurrentConditionsDto()
        {
            Name = "Jakku",
            Description = "Bright, barren, and cold",
            Temperature = "55",
            RelativeHumidity = "5%",
            Visibility = "Very good",
            Time = GetTime(100, 10, 5, 30),
            Type = "Sunny"
        };
        public CurrentConditionsDto BatuConditions => new CurrentConditionsDto()
        {
            Name = "Batu",
            Description = "Hot and steamy",
            Temperature = "95",
            RelativeHumidity = "70%",
            Visibility = "Pretty Good",
            Time = GetTime(0, -1, 0, 0), 
            Type = "Sunny"
        };

        private string GetTime(int daysOffset, int hourOffest, int minOffset, int secondsOffset)
        {
            var now = DateTime.Now.AddDays(daysOffset).AddHours(hourOffest).AddMinutes(minOffset).AddSeconds(secondsOffset);
            return now.ToLongDateString();
        }

    }
}