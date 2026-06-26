using System;
using System.Collections.Generic;

namespace CyberSecurityAwarenessBot.Classes
{
    public class ResponseManager
    {
        private Random random = new Random();

        public Dictionary<string, List<string>> responses =
            new Dictionary<string, List<string>>()
        {
            {
                "password",
                new List<string>()
                {
                    "Use strong and unique passwords.",
                    "Enable two-factor authentication.",
                    "Avoid using personal details in passwords."
                }
            },

            {
                "phishing",
                new List<string>()
                {
                    "Never click suspicious email links.",
                    "Check sender email addresses carefully.",
                    "Avoid downloading unknown attachments."
                }
            },

            {
                "privacy",
                new List<string>()
                {
                    "Review privacy settings regularly.",
                    "Do not overshare personal information online.",
                    "Use secure websites for sensitive information."
                }
            },

            {
                "scam",
                new List<string>()
                {
                    "Scammers often pretend to be trusted organisations.",
                    "Never send money to strangers online.",
                    "Be careful of urgent messages asking for information."
                }
            }
        };

        public string GetRandomResponse(string topic)
        {
            if (responses.ContainsKey(topic))
            {
                List<string> topicResponses = responses[topic];

                int index = random.Next(topicResponses.Count);

                return topicResponses[index];
            }

            return "I do not have information on that topic.";
        }
    }
}