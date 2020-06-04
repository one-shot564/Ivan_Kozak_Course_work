using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace course_work_lib
{
    public class Performance
    {
        public string[] genre;
        public string autor;
        public string name;
        public DateTime date;

        public List<Tickets> tickets = new List<Tickets>();
        public Performance(string name, string autor, string[] genre, DateTime date)
        {
            this.name = name;
            this.genre = genre;
            this.autor = autor;
            this.date = date;
        }

        public void AddTicket(int cost, int count)
        {
            tickets.Add(new Tickets(cost, count, this));
        }

        public int AvailableTickets()
        {
            int count = 0;
            for (int i = 0; i < tickets.Count; i++)
            {
                count++;
            }
            return count;
        }
    }
}
