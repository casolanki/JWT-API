
using System;

namespace API
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summarysss { get; set; } = string.Empty;
    }

     public class Person
    {
        public string? Name { get; set; }

        public int Age { get; set; }

        public string? Gender { get; set; }

    }
}