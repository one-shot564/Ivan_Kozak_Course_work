using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace course_work_lib
{
    public class Cashbox
    {
        public List<Performance> poster = new List<Performance>();

        public void Add(Performance performance)
        {
            poster.Add(performance);
        }

        public Tickets Find(TicketForCustomer t)
        {
            
            for (int i = 0; i <t.performance.tickets.Count; i++ )
            { 
                if (t.performance.tickets[i].cost == t.cost)
                    return t.performance.tickets[i];
            }
            return null;
        }

       

        public List<Performance> Search(string key, string n)
        {
            List<Performance> A = new List<Performance>();

            switch (n)
            {
                case "name":

                    for (int i = 0; i < poster.Count; i++)
                    {
                        if (poster[i].name == key) A.Add(poster[i]);
                    }
                    return A;
                case "author":

                    for (int i = 0; i < poster.Count; i++)
                    {
                        if (poster[i].autor == key) A.Add(poster[i]);
                    }
                    return A;
                case "genre":

                    for (int i = 0; i < poster.Count; i++)
                    {
                        bool b = false;
                        for (int j = 0; j < poster[i].genre.Length; j++)
                        {
                            if (poster[i].genre[j] == key) b = true;

                        }
                        if (b) A.Add(poster[i]);
                    }
                    return A;
                default:
                    return null;
            }
        }

        public List<Performance> Search(DateTime key)
        {
            List<Performance> A = new List<Performance>();
            for (int i = 0; i < poster.Count; i++)
            {
                if (poster[i].date == key) A.Add(poster[i]);
            }
            return A;

        }
    }
}
