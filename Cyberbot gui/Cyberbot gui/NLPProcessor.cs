namespace CyberSecurityAwarenessBot
{
    public class NLPProcessor
    {
        public string DetectIntent(string input)
        {
            input = input.ToLower();

            if (input.Contains("task"))
                return "task";

            if (input.Contains("quiz"))
                return "quiz";

            if (input.Contains("activity"))
                return "activity";

            if (input.Contains("remind"))
                return "reminder";

            return "chat";
        }
    }
}