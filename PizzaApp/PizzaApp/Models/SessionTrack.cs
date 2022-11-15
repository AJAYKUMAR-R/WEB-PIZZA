using PizzaApp.DataBaseModels;

namespace PizzaApp.Models
{
    public static class SessionTrack
    {
        public static string ?UserNameSession { get; set; }
        public static string ?SessionIdSession { get; set; }

        public static List<PizzaInformation> Orders =new List<PizzaInformation>();

    }
}
