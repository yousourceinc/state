using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouSource.State.Refactored
{
    internal abstract class TrafficLightStateBase
    {
        protected TrafficLight light;
        public TrafficLightStateBase(TrafficLight light)
        {
            this.light = light;
        }

        public abstract ConsoleColor GetColor();
        public abstract uint GetDuration();
        public abstract void SwitchState();

    }
}
