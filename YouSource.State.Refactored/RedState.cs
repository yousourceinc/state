using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouSource.State.Refactored
{
    internal class RedState : TrafficLightStateBase
    {

        public RedState(TrafficLight light) : base (light)
        {
        }

        public override ConsoleColor GetColor()
        {
            return ConsoleColor.Red;
        }

        public override uint GetDuration()
        {
            return 120;
        }

        public override void SwitchState()
        {
            this.light.SetState(new GreenState(this.light));
        }
    }
}
