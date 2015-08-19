using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouSource.State.Refactored
{
    internal class YellowState : TrafficLightStateBase
    {
        public YellowState(TrafficLight light) : base (light)
        {
        }

        public override ConsoleColor GetColor()
        {
            return ConsoleColor.Yellow;
        }

        public override uint GetDuration()
        {
            return 5;
        }

        public override void SwitchState()
        {
            this.light.SetState(new RedState(this.light));
        }
    }
}
