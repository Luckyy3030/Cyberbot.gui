using System;

namespace CyberSecurityAwarenessBot.Classes
{
    public class CyberBot
    {
        private ResponseManager responseManager;

        private UserMemory memory;

        private SentimentAnalyzer sentimentAnalyzer;

        private ConversationManager conversation;

        private bool askedName = false;

        private bool gotName = false;

        public CyberBot()
        {
            responseManager = new ResponseManager();

            memory = new UserMemory();

            sentimentAnalyzer = new SentimentAnalyzer();

            conversation = new ConversationManager();
        }

        public string StartConversation()
        {
            askedName = true;

            return "Hello! Welcome to the CyberSecurity Awareness Bot. What is your name?";
        }

        public string GetResponse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return "Please type something.";
            }

            input = input.ToLower();

            // GET USER NAME
            if (askedName && !gotName)
            {
                memory.UserName = input;

                gotName = true;

                return "Nice to meet you, " +
                       memory.UserName +
                       "! What cybersecurity topic interests you? Passwords, scams, phishing, or privacy?";
            }

            // MEMORY
            if (input.Contains("privacy"))
            {
                memory.FavouriteTopic = "privacy";
            }

            if (input.Contains("password"))
            {
                memory.FavouriteTopic = "password";
            }

            if (input.Contains("scam"))
            {
                memory.FavouriteTopic = "scam";
            }

            // SENTIMENT DETECTION
            string sentiment =
                sentimentAnalyzer.DetectSentiment(input);

            if (sentiment == "worried")
            {
                return "It is understandable to feel worried about online scams. Here is a tip: Never click suspicious links from unknown emails.";
            }

            if (sentiment == "frustrated")
            {
                return "Cybersecurity can feel overwhelming at first, but you are doing well learning these important skills.";
            }

            if (sentiment == "curious")
            {
                return "Curiosity is great! Learning cybersecurity helps protect your personal information online.";
            }

            // FOLLOW-UP RESPONSES
            if (input.Contains("another tip") ||
                input.Contains("tell me more") ||
                input.Contains("explain more"))
            {
                if (!string.IsNullOrEmpty(conversation.CurrentTopic))
                {
                    return responseManager
                        .GetRandomResponse(conversation.CurrentTopic);
                }
            }

            // KEYWORD RECOGNITION
            foreach (var keyword in responseManager.responses)
            {
                if (input.Contains(keyword.Key))
                {
                    conversation.CurrentTopic = keyword.Key;

                    string response =
                        responseManager.GetRandomResponse(keyword.Key);

                    return memory.UserName +
                           ", " +
                           response;
                }
            }

            // GREETING
            if (input.Contains("hello") ||
                input.Contains("hi"))
            {
                return "Hello " +
                       memory.UserName +
                       "! How can I help you today?";
            }

            // GOODBYE
            if (input.Contains("bye"))
            {
                return "Goodbye " +
                       memory.UserName +
                       "! Stay safe online.";
            }

            // MEMORY RECALL
            if (!string.IsNullOrEmpty(memory.FavouriteTopic))
            {
                return "Since you are interested in " +
                       memory.FavouriteTopic +
                       ", remember to keep your accounts secure.";
            }

            // DEFAULT RESPONSE
            return "I am not sure I understand. Can you try rephrasing?";
        }
    }
}