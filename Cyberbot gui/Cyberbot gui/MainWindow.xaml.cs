using System.Windows;
using CyberSecurityAwarenessBot.Classes;

namespace CyberSecurityAwarenessBot
{
    public partial class MainWindow : Window
    {
        private CyberBot bot;

        private QuizManager quizManager;

        private ActivityLog activityLog;

        private TaskManager taskManager;

        public MainWindow()
        {
            InitializeComponent();

            bot = new CyberBot();

            quizManager = new QuizManager();

            activityLog = new ActivityLog();

            taskManager = new TaskManager();

            SoundManager.PlayWelcomeSound();

            txtChat.AppendText(
                "Bot: " +
                bot.StartConversation() +
                "\n\n");

            LoadQuestion();
        }

        private void btnSend_Click(
            object sender,
            RoutedEventArgs e)
        {
            string input =
                txtUserInput.Text;

            if (string.IsNullOrWhiteSpace(input))
            {
                return;
            }

            SoundManager.PlaySendSound();

            txtChat.AppendText(
                "You: " +
                input +
                "\n");

            ResponseHandler handler =
                bot.GetResponse;

            string response =
                handler(input);

            txtChat.AppendText(
                "Bot: " +
                response +
                "\n\n");

            txtUserInput.Clear();

            activityLog.AddAction(
                "Chat message sent");
        }

        // =====================
        // TASK ASSISTANT
        // =====================

        private void btnAddTask_Click(
            object sender,
            RoutedEventArgs e)
        {
            TaskItem task =
                new TaskItem();

            task.Title =
                txtTaskTitle.Text;

            task.Description =
                txtTaskDescription.Text;

            task.ReminderDate =
                dpReminder.SelectedDate ??
                System.DateTime.Now;

            task.Completed = false;

            taskManager.AddTask(task);

            activityLog.AddAction(
                "Task Added: " +
                task.Title);

            MessageBox.Show(
                "Task added successfully.");

            txtTaskTitle.Clear();

            txtTaskDescription.Clear();
        }

        private void btnLoadTasks_Click(
            object sender,
            RoutedEventArgs e)
        {
            lstTasks.Items.Clear();

            var tasks =
                taskManager.GetTasks();

            foreach (TaskItem task in tasks)
            {
                lstTasks.Items.Add(
                    task.Id +
                    " | " +
                    task.Title +
                    " | " +
                    task.Description +
                    " | Reminder: " +
                    task.ReminderDate.ToShortDateString() +
                    " | Completed: " +
                    task.Completed);
            }

            activityLog.AddAction(
                "Tasks Loaded");
        }

        // =====================
        // QUIZ
        // =====================

        private void LoadQuestion()
        {
            QuizQuestion q =
                quizManager.GetCurrentQuestion();

            lblQuestion.Content =
                q.Question;

            rbA.Content =
                "A) " + q.OptionA;

            rbB.Content =
                "B) " + q.OptionB;

            rbC.Content =
                "C) " + q.OptionC;

            rbD.Content =
                "D) " + q.OptionD;

            lblScore.Content =
                "Score: " +
                quizManager.Score;
        }

        private void btnSubmitQuiz_Click(
            object sender,
            RoutedEventArgs e)
        {
            string answer = "";

            if (rbA.IsChecked == true)
                answer = "A";

            if (rbB.IsChecked == true)
                answer = "B";

            if (rbC.IsChecked == true)
                answer = "C";

            if (rbD.IsChecked == true)
                answer = "D";

            bool correct =
                quizManager.CheckAnswer(answer);

            if (correct)
            {
                MessageBox.Show(
                    "Correct!");
            }
            else
            {
                MessageBox.Show(
                    quizManager
                    .GetCurrentQuestion()
                    .Explanation);
            }

            lblScore.Content =
                "Score: " +
                quizManager.Score;

            activityLog.AddAction(
                "Quiz question answered");
        }

        private void btnNextQuestion_Click(
            object sender,
            RoutedEventArgs e)
        {
            if (quizManager.CurrentQuestionIndex <
                quizManager.Questions.Count - 1)
            {
                quizManager.NextQuestion();

                LoadQuestion();
            }
            else
            {
                MessageBox.Show(
                    "Quiz Complete!\nScore: " +
                    quizManager.Score +
                    "/" +
                    quizManager.Questions.Count);

                activityLog.AddAction(
                    "Quiz completed");
            }
        }

        // =====================
        // ACTIVITY LOG
        // =====================

        private void btnRefreshLog_Click(
            object sender,
            RoutedEventArgs e)
        {
            lstActivityLog.Items.Clear();

            foreach (string action
                     in activityLog.GetRecentActions())
            {
                lstActivityLog.Items.Add(action);
            }
        }
    }
}