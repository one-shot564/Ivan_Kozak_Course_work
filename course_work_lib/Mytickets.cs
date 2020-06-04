using System;
using System.Collections.Generic;
using System.Text;

namespace course_work_lib
{
    public class Mytickets
    {
        public List<TicketForCustomer> mytickets ;
        public Mytickets()
        {
            mytickets = new List<TicketForCustomer>();
        }




        public List<TicketForCustomer> AllTickets()
        {

            return mytickets;
        }

        public void OutAll()
        {
            for(int i = 0; i < mytickets.Count;i++)
            {
                Console.WriteLine($"{i + 1}. {mytickets[i].performance.name}  {mytickets[i].performance.date} {mytickets[i].Status}");
            }
        }

        public void OutBuyed()
        {
            int j = 0;
            for (int i = 0; i < mytickets.Count; i++)
            {
                if (mytickets[i].Status == "куплено")
                { 
                    Console.WriteLine($"{j + 1}. {mytickets[i].performance.name}  {mytickets[i].performance.date} {mytickets[i].Status}");
                    j++;
                }

            }
        }

        public void OutBooked()
        {
            int j = 0;
            for (int i = 0; i < mytickets.Count; i++)
            {
                if (mytickets[i].Status == "забронировано")
                {
                    Console.WriteLine($"{j + 1}. {mytickets[i].performance.name}  {mytickets[i].performance.date} {mytickets[i].Status}");
                    j++;
                }

            }
        }

       public List <TicketForCustomer> MyTicketsReserved()
        {
            List<TicketForCustomer> A = new List<TicketForCustomer>();
            for (int i = 0; i < mytickets.Count; i++)
            {
                if (mytickets[i].Status == "забронировано")
                {
                    A.Add(mytickets[i]);
                }
            }
            return A;
        }

    }
}
