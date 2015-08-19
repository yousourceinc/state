using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouSource.State.Refactored
{
    internal class GreenState : TrafficLightStateBase
    {
        public GreenState(TrafficLight light) : base(light)
        {
        }

        public override ConsoleColor GetColor()
        {
            return ConsoleColor.DarkGreen;
        }

        public override uint GetDuration()
        {
            return 60;
        }

        public override void SwitchState()
        {
            this.light.SetState(new YellowState(this.light));
        }
    }
}
