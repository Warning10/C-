using System;

namespace Assignment_4
{
    public class WeatherEventArgs : EventArgs
    {
        public int Temperature { get; }

        public WeatherEventArgs(int temperature)
        {
            Temperature = temperature;
        }
    }
}
