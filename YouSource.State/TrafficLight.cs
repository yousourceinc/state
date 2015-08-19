using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace YouSource.State
{
    
    public enum TrafficLightState
    {
        Red = 0, 
        Yellow = 1, 
        Green = 2
    }
    

    public class TrafficLight
    {
        
        private const uint TIMESPAN_RED = 120;
        private const uint TIMESPAN_YELLOW = 5;
        private const uint TIMESPAN_GREEN = 60;

        private TrafficLightState state = TrafficLightState.Yellow;
        private Timer timer = null; 

        public TrafficLight()
        {
        }

        public void Start()
        {
            this.Restart(); 
        }

        public void Stop()
        {
            if (this.timer != null)
            {
                this.timer.Stop();
                this.timer.Dispose();
            }
        }

        private void Restart()
        {
            this.Stop(); 

            this.timer = new Timer(this.GetDuration() * 30);
            this.timer.Elapsed += OnTimerElapsed;
            this.timer.Start(); 
            

        }
        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            this.SwitchState();
            this.Restart(); 
        }

        public ConsoleColor GetColor()
        {
            if (this.state == TrafficLightState.Green)
            {
                return ConsoleColor.Green;
            }
            else if (this.state == TrafficLightState.Yellow)
            {
                return ConsoleColor.Yellow;
            }
            else
            {
                return ConsoleColor.Red; 
            }
        }

        public uint GetDuration()
        {
            if (this.state == TrafficLightState.Green)
            {
                return TIMESPAN_GREEN;
            }
            else if (this.state == TrafficLightState.Yellow)
            {
                return TIMESPAN_YELLOW;
            }
            else
            {
                return TIMESPAN_RED;
            }
        }

        public void SwitchState()
        {
            if (this.state == TrafficLightState.Green)
            {
                this.state = TrafficLightState.Yellow;
            }
            else if (this.state == TrafficLightState.Yellow)
            {
                this.state = TrafficLightState.Red;
            }
            else
            {
                this.state = TrafficLightState.Green;
            }

            Console.ForegroundColor = this.GetColor(); 
            Console.WriteLine("Switched to state " + this.state);
        }
    }
}
