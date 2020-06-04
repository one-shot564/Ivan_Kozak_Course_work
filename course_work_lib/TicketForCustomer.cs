using System;
using System.Collections.Generic;
using System.Text;

namespace course_work_lib
{
    public class TicketForCustomer : Ticket
    {
        public String Status;
        public int Count;
        public TicketForCustomer(Tickets ticket, string status, int count)
        : base(ticket.cost, ticket.performance)
        {
            Count = count;
        }

    }

}
