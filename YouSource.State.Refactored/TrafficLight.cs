using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace YouSource.State.Refactored
{
    

    public class TrafficLight
    {
        private TrafficLightStateBase state;
        private Timer timer = null; 

        public TrafficLight()
        {
            this.SetState(new YellowState(this));
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

            this.timer = new Timer(this.GetDuration() * 50);
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
            return this.state.GetColor();
        }

        public uint GetDuration()
        {
            return this.state.GetDuration();
        }

        public void SwitchState()
        {
            this.state.SwitchState();

            Console.ForegroundColor = this.GetColor(); 
            Console.WriteLine("Switched to state " + this.state);
        }

        internal void SetState(TrafficLightStateBase state)
        {
            if (state != null)
            {
                this.state = state;
            }
        }
    }
}
