namespace Intelliponics.Utils
{
    //This is a very crude way of limiting the number of API calls in this application.
    //You only get 5 requests. Make it count... literally. Haha! I kill me.
    public class APIQueryLimiter
    {
        public int LoadSheddingAPI { get; set; }
        public int ChatGPTAPI { get; set; }
        public int WeatherAPI { get; set; }

    }

    //I wrote the above comments on a sleep deprived mind.
}
