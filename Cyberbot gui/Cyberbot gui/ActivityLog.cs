using System;
using System.Collections.Generic;
using System.Linq;

namespace CyberSecurityAwarenessBot.Classes
{
    public class ActivityLog
    {
        private List<string> actions =
            new List<string>();

        public void AddAction(string action)
        {
            actions.Add(
                $"{DateTime.Now:G} - {action}");
        }

        public List<string> GetRecentActions()
        {
            return actions
                .TakeLast(10)
                .ToList();
        }
    }
}