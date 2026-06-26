using System.Collections.Generic;

namespace CyberSecurityAwarenessBot.Classes
{
    public class QuizManager
    {
        public List<QuizQuestion> Questions { get; set; }

        public int CurrentQuestionIndex { get; set; }

        public int Score { get; set; }

        public QuizManager()
        {
            Questions = new List<QuizQuestion>();

            CurrentQuestionIndex = 0;

            Score = 0;

            Questions.Add(new QuizQuestion
            {
                Question = "What should you do if an email asks for your password?",
                OptionA = "Send your password",
                OptionB = "Ignore it",
                OptionC = "Report it as phishing",
                OptionD = "Reply later",
                CorrectAnswer = "C",
                Explanation = "Reporting phishing emails helps prevent scams."
            });

            Questions.Add(new QuizQuestion
            {
                Question = "Should you use the same password for every account?",
                OptionA = "Yes",
                OptionB = "No",
                OptionC = "Sometimes",
                OptionD = "Only for social media",
                CorrectAnswer = "B",
                Explanation = "Every account should have a unique password."
            });

            Questions.Add(new QuizQuestion
            {
                Question = "Two-factor authentication improves security.",
                OptionA = "True",
                OptionB = "False",
                OptionC = "Maybe",
                OptionD = "Not Sure",
                CorrectAnswer = "A",
                Explanation = "2FA adds an extra layer of protection."
            });

            Questions.Add(new QuizQuestion
            {
                Question = "Which is a common sign of phishing?",
                OptionA = "Urgent messages",
                OptionB = "Suspicious links",
                OptionC = "Spelling mistakes",
                OptionD = "All of the above",
                CorrectAnswer = "D",
                Explanation = "All these signs can indicate phishing."
            });

            Questions.Add(new QuizQuestion
            {
                Question = "Is public Wi-Fi always safe?",
                OptionA = "Yes",
                OptionB = "No",
                OptionC = "Only at schools",
                OptionD = "Only at airports",
                CorrectAnswer = "B",
                Explanation = "Public Wi-Fi networks can expose your data."
            });

            Questions.Add(new QuizQuestion
            {
                Question = "What does VPN stand for?",
                OptionA = "Virtual Private Network",
                OptionB = "Verified Public Network",
                OptionC = "Virtual Public Node",
                OptionD = "Private Virtual Node",
                CorrectAnswer = "A",
                Explanation = "A VPN helps secure your internet connection."
            });

            Questions.Add(new QuizQuestion
            {
                Question = "Should you share your passwords with friends?",
                OptionA = "Yes",
                OptionB = "No",
                OptionC = "Sometimes",
                OptionD = "Only if trusted",
                CorrectAnswer = "B",
                Explanation = "Passwords should always remain private."
            });

            Questions.Add(new QuizQuestion
            {
                Question = "What is malware?",
                OptionA = "A game",
                OptionB = "A browser",
                OptionC = "Malicious software",
                OptionD = "A password",
                CorrectAnswer = "C",
                Explanation = "Malware is software designed to harm devices."
            });

            Questions.Add(new QuizQuestion
            {
                Question = "Which password is strongest?",
                OptionA = "123456",
                OptionB = "password",
                OptionC = "Lucky123",
                OptionD = "X9@vT#2mP!7",
                CorrectAnswer = "D",
                Explanation = "Strong passwords contain letters, numbers and symbols."
            });

            Questions.Add(new QuizQuestion
            {
                Question = "Should you install software updates?",
                OptionA = "Yes",
                OptionB = "No",
                OptionC = "Only once a year",
                OptionD = "Only on phones",
                CorrectAnswer = "A",
                Explanation = "Updates fix security vulnerabilities."
            });
        }

        public QuizQuestion GetCurrentQuestion()
        {
            return Questions[CurrentQuestionIndex];
        }

        public bool CheckAnswer(string answer)
        {
            if (answer == Questions[CurrentQuestionIndex].CorrectAnswer)
            {
                Score++;
                return true;
            }

            return false;
        }

        public void NextQuestion()
        {
            if (CurrentQuestionIndex < Questions.Count - 1)
            {
                CurrentQuestionIndex++;
            }
        }
    }
}