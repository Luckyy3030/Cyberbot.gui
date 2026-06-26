using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace CyberSecurityAwarenessBot.Classes
{
    public class TaskManager
    {
        private readonly DatabaseManager database =
            new DatabaseManager();

        public void AddTask(TaskItem task)
        {
            using (MySqlConnection conn =
                   database.GetConnection())
            {
                conn.Open();

                string query =
                @"INSERT INTO Tasks
                (Title, Description, ReminderDate, Completed)
                VALUES
                (@Title, @Description, @ReminderDate, @Completed)";

                MySqlCommand cmd =
                    new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Title", task.Title);
                cmd.Parameters.AddWithValue("@Description", task.Description);
                cmd.Parameters.AddWithValue("@ReminderDate", task.ReminderDate);
                cmd.Parameters.AddWithValue("@Completed", task.Completed);

                cmd.ExecuteNonQuery();
            }
        }

        public List<TaskItem> GetTasks()
        {
            List<TaskItem> tasks =
                new List<TaskItem>();

            using (MySqlConnection conn =
                   database.GetConnection())
            {
                conn.Open();

                string query =
                    "SELECT * FROM Tasks";

                MySqlCommand cmd =
                    new MySqlCommand(query, conn);

                using (MySqlDataReader reader =
                       cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TaskItem task =
                            new TaskItem
                            {
                                Id = Convert.ToInt32(reader["Id"]),

                                Title =
                                    reader["Title"]?.ToString()
                                    ?? "",

                                Description =
                                    reader["Description"]?.ToString()
                                    ?? "",

                                ReminderDate =
                                    reader["ReminderDate"] == DBNull.Value
                                    ? DateTime.Now
                                    : Convert.ToDateTime(
                                        reader["ReminderDate"]),

                                Completed =
                                    Convert.ToBoolean(
                                        reader["Completed"])
                            };

                        tasks.Add(task);
                    }
                }
            }

            return tasks;
        }

        public void DeleteTask(int id)
        {
            using (MySqlConnection conn =
                   database.GetConnection())
            {
                conn.Open();

                string query =
                    "DELETE FROM Tasks WHERE Id = @Id";

                MySqlCommand cmd =
                    new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();
            }
        }

        public void CompleteTask(int id)
        {
            using (MySqlConnection conn =
                   database.GetConnection())
            {
                conn.Open();

                string query =
                @"UPDATE Tasks
                  SET Completed = 1
                  WHERE Id = @Id";

                MySqlCommand cmd =
                    new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}