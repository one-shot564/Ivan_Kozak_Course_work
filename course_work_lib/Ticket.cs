using System;
using System.Collections.Generic;
using System.Text;

namespace course_work_lib
{
    public abstract class Ticket
    {
        public Performance performance;
        public int cost;
        public Ticket(int cost, Performance performance)
        {
            this.cost = cost;
            this.performance = performance;
        }

    }
}
