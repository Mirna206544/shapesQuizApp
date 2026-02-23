using System;
namespace airlineticket
{
    class Program
    {
        static void Main(string[] args)
        {
            FlightTicket p1 = new FlightTicket("mirna", 19, "Business");
            FlightTicket p2 = new FlightTicket("sara", 65, "Business");
            FlightTicket p3 = new FlightTicket("hamza", 10, "Business");
            FlightTicket p4 = new FlightTicket("mirna", 19, " economy");
            FlightTicket p5 = new FlightTicket("sara", 65, " economy");
            FlightTicket p6 = new FlightTicket("nawras", 10, " economy");
            Console.WriteLine("the final price of passenger "+ p1.NamePasenger + " is : " + p1.ClclateFinalPrice());
            Console.WriteLine("the final price of passenger " + p2.NamePasenger + " is : " + p2.ClclateFinalPrice());
            Console.WriteLine("the final price of passenger " + p3.NamePasenger + " is : " + p3.ClclateFinalPrice());
            Console.WriteLine("the final price of passenger " + p4.NamePasenger + " is : " + p4.ClclateFinalPrice());
            Console.WriteLine("the final price of passenger " + p5.NamePasenger + " is : " + p5.ClclateFinalPrice());
            Console.WriteLine("the final price of passenger " + p6.NamePasenger + " is : " + p6.ClclateFinalPrice());




        }
    }
}