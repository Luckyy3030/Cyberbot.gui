namespace CyberSecurityAwarenessBot.Classes
{
    public class SentimentAnalyzer
    {
        public string DetectSentiment(string input)
        {
            input = input.ToLower();

            if (input.Contains("worried"))
                return "worried";

            if (input.Contains("frustrated"))
                return "frustrated";

            if (input.Contains("curious"))
                return "curious";

            return "neutral";
        }
    }
} 