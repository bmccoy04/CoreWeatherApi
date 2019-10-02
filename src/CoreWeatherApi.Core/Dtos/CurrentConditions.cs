namespace CoreWeatherApi.Core.Dtos
{
    public class CurrentConditionsDto
    {
        public int Id { get; set; }
        public string Type { get; internal set; }
        public string Time { get; internal set; }
        public string Visibility { get; internal set; }
        public string RelativeHumidity { get; internal set; }
        public string Temperature { get; internal set; }
        public string Description { get; internal set; }
        public string Name { get; internal set; }
    }
    
}