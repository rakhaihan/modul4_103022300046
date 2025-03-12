using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul4_103022300046
{
    class FanLaptop
    {
        public enum State {Quiet, Balanced, Performance, Turbo };
        public enum Trigger {Mode_down, Mode_up, Turbo_shortcut };

        struct transition
        {
            public State prevState;
            public State nextState;
            public Trigger trigger;

            public transition(State prevState, State nextState, Trigger trigger)
            {
                this.prevState = prevState;
                this.nextState = nextState;
                this.trigger = trigger;
            }
        }


            transition[] transitions =
            {
                new transition(State.Quiet, State.Balanced, Trigger.Mode_up),
                new transition(State.Quiet, State.Turbo, Trigger.Turbo_shortcut),
                new transition(State.Balanced, State.Performance, Trigger.Mode_up),
                new transition(State.Balanced, State.Quiet, Trigger.Mode_down),
                new transition(State.Performance, State.Balanced, Trigger.Mode_down),
                new transition(State.Performance, State.Turbo, Trigger.Mode_up),
                new transition(State.Turbo, State.Quiet, Trigger.Turbo_shortcut),
                new transition(State.Turbo, State.Performance, Trigger.Mode_down)
            };

            public State currentState = State.Quiet;

            public State getNextState(State prevState, Trigger trigger)
            {
                State nextState = prevState;

                for (int i = 0; i < transitions.Length; i++)
                {
                    if (transitions[i].prevState == prevState && transitions[i].trigger == trigger)
                        nextState = transitions[i].nextState;
                }

                return nextState;
            }

            public void activate(Trigger trigger)
            {
                State nextState = getNextState(currentState, trigger);
                currentState = nextState;
            }
        

    }
}
