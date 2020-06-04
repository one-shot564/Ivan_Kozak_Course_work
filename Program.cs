using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using course_work_lib;


namespace coursework
{
    class Program
    {
        static void Main(string[] args)
        {
            Cashbox cashbox = new Cashbox();
            NewCashbox (cashbox);
            Mytickets mytickets = new Mytickets();

    

            bool alive = true;
            while (alive)
            {
                Console.WriteLine("1. найти спектакль \t 2. Показать мои билеты  \t 3. Закрыть программу ");
                
                Console.WriteLine("введите число:");
                try
                {
                    switch (Input(3))
                    {
                        case 1:
                            Find(cashbox, mytickets, 3);
                            break;
                        case 2:
                            Show(mytickets, cashbox);
                            break;
                        case 3:
                            alive = false;
                            Console.WriteLine("Вы вышли из программы");
                            break;

                    }
                } 
                
                catch (Exception ex)
                {
                    
                    Console.WriteLine(ex.Message);
                  
                }
            }

        }
        private static void NewCashbox(Cashbox cashbox)
        {
            Console.WriteLine("Добро пожаловать в наш театр");
            //adding performances to the theater poster
            cashbox.Add(new Performance("Енеида", "Котляревський Иван", new string[] { "драма", "приключения", "триллер" }, new DateTime(2020, 05, 30)));
            cashbox.Add(new Performance("Наталка Полтавка", "Котляревський Иван", new string[] { "драма" }, new DateTime(2020, 06, 01)));
            cashbox.Add(new Performance("Лис Микита", "Франко Иван", new string[] { "мюзикл", "комедия" }, new DateTime(2020, 06, 01)));
            cashbox.Add(new Performance("Чорна Рада", "Кулиш Пантелеймон", new string[] { "исторический", "драма" }, new DateTime(2020, 06, 01)));
            cashbox.Add(new Performance("Лис Микита", "Франко Иван", new string[] { "мюзикл", "комедия" }, new DateTime(2020, 06, 10)));
            cashbox.Add(new Performance("Наталка Полтавка", "Котляревський Иван", new string[] { "драма" }, new DateTime(2020, 06, 15)));
            cashbox.Add(new Performance("Енеида", "Котляревський Иван", new string[] { "драма", "приключения", "триллер" }, new DateTime(2020, 06, 15)));
            //adding tickets to the performance
            foreach (Performance performance in cashbox.poster)
            {
                performance.AddTicket(500, 5);
                performance.AddTicket(300, 3);
                performance.AddTicket(200, 8);
            }
        }
        //find a performance
        private static void Find(Cashbox cashbox, Mytickets mytickets, int n)
        {
            List<Performance> find = new List<Performance>();
            Console.WriteLine("Выберите тип поиска");
            Console.WriteLine("1. по имени \t 2. по автору  \t 3. по жанру \t 4. по дате  \t 5. показать все");
            switch (Input(5))
            {
                case 1:
                    Console.WriteLine("1. Енеида\n2. Лис Микита\n3. Наталка Полтавка\n4. Чорна рада\nВыберите название:");
                    find = cashbox.Search(SearchKey(Input(4), "name"), "name");
                    break;
                case 2:
                    Console.WriteLine("1. Котляревський Иван\n2. Франко Иван\n3. Кулиш Пантелеймон\n Выберите автора: ");
                    find = cashbox.Search(SearchKey(Input(3), "author"), "author");
                    break;
                case 3:
                    Console.WriteLine("1. Драма \n2. Комедия\n3. Приключения\n4. триллер\n5.мюзикл\nВыберите жанр:");
                    find = cashbox.Search(SearchKey(Input(5), "genre"), "genre");
                    break;
                case 4:
                    Console.WriteLine("1. 30.05.2020\n2. 01.06.2020\n3. 01.06.2020");
                    Console.WriteLine("4. 01.06.2020\n5. 10.06.2020\n6. 15.06.2020\nchoose date:");
                    find = cashbox.Search(SearchKey(Input(6)));
                    break;
                case 5:
                    find = cashbox.poster;
                    break;
            }
            Console.WriteLine($"найдено {find.Count} спектаклей");
            PrintInfo(find);
            if (find.Count > 0 && find != null)
            {
                switch (n)
                {
                    case 1:
                        Buy(cashbox, find, mytickets);
                        break;
                    case 2:
                        Book(cashbox, find, mytickets);
                        break;
                    case 3:

                        Console.WriteLine("1. купить билет  \t 2. забронировать билет \t 3. назад в меню");
                        switch (Input(3))
                        {
                            case 1:
                                Buy(cashbox, find, mytickets);
                                break;
                            case 2:
                                Book(cashbox, find, mytickets);
                                break;
                            case 3:
                                break;
                        }
                        break;
                }
            }
            else
                Console.WriteLine("Спектакли не найдены, проверьте значения и попробуйте снова!");
        }
       
        private static void Buy(Cashbox cashbox, List<Performance> find, Mytickets mytickets)
        {
            Console.WriteLine("выберите номер Спектакля:");//choose a specific performance
            int command = Input(find.Count);
            PrintInfo(find[command]);
            Console.WriteLine("выберите номер билета:");//choose a specific tickets
            int command1 = Input(find[command].tickets.Count);
            Console.WriteLine("сколько билетов вы хотите купить?");//number of tickets
            int command2 = Input();
            if (find[command-1].tickets[command1-1].Count >= command2)
            {
                mytickets.mytickets.Add(new TicketForCustomer(find[command-1].tickets[command1-1], "куплено", command2));
                find[command-1].tickets[command1-1].Count -= command2;
            }
            else Console.WriteLine("не хватает Билетов");


        }
        private static void Buy(List<TicketForCustomer> tickets, Mytickets mytickets, Cashbox cashbox)
        {
            PrintInfo(tickets);
            Console.WriteLine("выберите номер спектакля:");//choose a specific performance
            int command = Input(tickets.Count);
            command--;
            Tickets ticket = cashbox.Find(tickets[command]);
            if (ticket != null)
            {
                Console.WriteLine("сколько билетов вы хотите купить?");//number of tickets

                int command1 = Input();
               
                    Console.WriteLine("you have not booked so many tickets");
              
            }

        }
        //choose how to find a ticket to book
        //private static void Book(BoxOffice boxOffice, Buyer buyer)
        //{
        //    Console.WriteLine("1. show all performances\t2. use search\t3. return to menu");

        //    switch (Input(3))
        //    {
        //        case 1:
        //            PrintInfo(boxOffice.AllPerformance());
        //            Book(boxOffice, boxOffice.AllPerformance(), buyer);
        //            break;
        //        case 2:
        //            Find(boxOffice, buyer, 2);
        //            break;
        //        case 3:
        //            break;
        //    }
        //}
        private static void Book(Cashbox cashbox, List<Performance> find, Mytickets mytickets)
        {
            Console.WriteLine("выберите номер Спектакля:");
            int command = Input(find.Count);
            PrintInfo(find[command]);
            Console.WriteLine("выберите номер билета:");
            int command1 = Input(find[command].tickets.Count);
            Console.WriteLine("сколько билетов вы хотите забронировать?");
            int command2 = Input();
            if (find[command--].tickets[command1--].Count >= command2)
            {
                mytickets.mytickets.Add(new TicketForCustomer(find[command--].tickets[command1--], "забронировано", command2));
                find[command--].tickets[command1--].Count -= command2;
            }
            else Console.WriteLine("не хватает Билетов");


        }


        private static void Show(Mytickets mytickets, Cashbox cashbox)
        {
            bool flag = false;
            while (!flag)
            {
                try
                {
                    Console.WriteLine("1.показать все билеты\t2. показать купленные билеты \t3. показать забронированные билеты ");
                    Console.WriteLine("4. назад в меню");
                    switch (Input(5))
                    {
                        case 1:
                            {
                                mytickets.OutAll();
                                break;
                            }
                        case 2:
                            {
                                mytickets.OutBuyed();
                                break;
                            }
                        case 3:
                            {
                                mytickets.OutBooked();
                                break;
                            }
                        case 4:
                            return;
                    }

                }
                catch (NullReferenceException ex) { Console.WriteLine(ex.Message); }

                
            }

            Console.WriteLine("1. купить забронированный билет\t2. назад в меню ");
            switch (Input(2))
            {
                case 1:
                    Buy(mytickets.MyTicketsReserved(), mytickets, cashbox);
                    break;
               
                case 2:
                    break;
            }
        }
        //search for representation by properties and key
        private static string SearchKey(int n, string type)
        {
            switch (type)
            {
                case "name":
                    switch (n)
                    {
                        case 1:
                            return "Енеида";
                        case 2:
                            return "Лис Микита";
                        case 3:
                            return "Наталка Полтавка";
                        case 4:
                            return "Чорна Рада";

                    }
                    break;
                case "author":
                    switch (n)
                    {
                        case 1:
                            return "Котляревський Иван";
                        case 2:
                            return "Франко Иван";
                        case 3:
                            return "Кулиш Пантелеймон";
                    }
                    break;
                case "genre":
                    switch (n)
                    {
                        case 1:
                            return "драма";
                        case 2:
                            return "комедия";
                        case 3:
                            return "приключения";
                        case 4:
                            return "триллер";
                        case 5:
                            return "мюзикл";
                    }
                    break;
            }
            return null;
        }
        private static DateTime SearchKey(int n)
        {
            switch (n)
            {
                case 1:
                    return new DateTime(2020, 05, 30);
                case 2:
                    return new DateTime(2020, 06, 01);
                case 3:
                    return new DateTime(2020, 05, 30);
                case 4:
                    return new DateTime(2020, 05, 30);
                case 5:
                    return new DateTime(2020, 05, 30);
                case 6:
                    return new DateTime(2020, 06, 15);
                default:
                    throw new NullReferenceException("incorrect input, date not found");
            }
        }
        //value entered
        private static int Input(int n)
        {
            while (true)
            {
                try
                {
                    int command = Convert.ToInt32(Console.ReadLine());

                    
                    if (command > 0 && command < n + 1)     //if the value is correct                   
                    {
                        
                        return command; //return this value
                    }
                    else
                        Console.WriteLine("Неверное значение, попробуйте снова!");//if an invalid value was entered, then display an error message

                   
                }
                catch (Exception )
                {
                    
                    Console.WriteLine("Вы ввели строку. Попробуйте снова!");
           
                }
            }
        }
        private static int Input()
        {
            while (true)
            {
                try
                {
                    int command = Convert.ToInt32(Console.ReadLine());

                    ConsoleColor color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (command > 0)//if the value is correct
                    {
                        Console.ForegroundColor = color;
                        return command;//return this value
                    }
                    else
                        Console.WriteLine("You entered an invalid quantity. Try again!");//if an invalid value was entered, then display an error message

                    Console.ForegroundColor = color;
                }
                catch
                {
                    //if a string was entered, then display an error message
                    ConsoleColor color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You entered a string. Try again!");
                    Console.ForegroundColor = color;
                }
            }
        }
        //display information about performances
        private static void PrintInfo(List<Performance> find)
        {
            int count = 0;
            foreach (Performance performance in find)
            {
                string _ = "";
                for (int i = 0; i < performance.genre.Length; i++)
                    _ += performance.genre[i] + " ";
                Console.WriteLine($"{++count}\n{performance.name}\nавтор: {performance.autor}\nжанр: {_}\nдата: {performance.date:d}");
                Console.WriteLine($"билетов: {performance.AvailableTickets()}");
            }

        }
        
        private static void PrintInfo(Tickets[] ticket)
        {
            for (int i = 0; i < ticket.Length; i++)
                Console.WriteLine($"{i + 1}. цена: {ticket[i].cost}\t свободно билетов: {ticket[i].Count}");
        }
        private static void PrintInfo(List<TicketForCustomer> ticket)
        {
            for (int i = 0; i < ticket.Count; i++)
                Console.WriteLine($"{i + 1}. {ticket[i].performance.name}\t {ticket[i].performance.date}\t цена: {ticket[i].cost}\t ");
        }

        private static void PrintInfo(Performance performance)
        {
            for (int i = 0; i < performance.tickets.Count; i++)
                Console.WriteLine($"{i+1}. цена: {performance.tickets[i].cost}\t свободно билетов: {performance.tickets[i].Count}");
        }

       
    }
}