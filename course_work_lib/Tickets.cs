using System;
using System.Collections.Generic;
using System.Text;

namespace course_work_lib
{
    public class Tickets : Ticket
    {
        public int Count;
        public int CountBook;
        public Tickets(int cost, int count, Performance performance)
            : base(cost, performance)
        {
            Count = count;
        }
    }
}
