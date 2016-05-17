namespace _03.AsynchronousTimer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    class AsyncTimer
    { 
        public AsyncTimer(Action<string> action, ushort ticks, int t)
        {
            this.Action = action;
            this.Ticks = ticks;
            this.T = t;
        }

        public Action<string> Action { get; set; }
        public ushort Ticks { get; set; }
        public int T { get; set; }

        public override string ToString()
        {
            for (int i = 0; i < this.Ticks; i++)
            {
                int started = Environment.TickCount;
                int continuing = Environment.TickCount;
                while ((continuing - started) < this.T)
                {
                    continuing = Environment.TickCount;
                }

                this.Action("Tick-tack");
            }
            return "Done!";
        }

    }
}
