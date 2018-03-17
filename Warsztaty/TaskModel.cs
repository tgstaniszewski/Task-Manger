using System;
using System.Collections.Generic;
using System.Text;

namespace Warsztaty
{
    public class TaskModel
    {
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndTime { get; set; }
        public bool? IsImportant { get; set; }
        public bool? IsAllDayTask { get; set; }

        public TaskModel(string description, DateTime startDate)
        {
            Description = description;
            StartDate = startDate;
        }

        public TaskModel(string description, DateTime startDate, DateTime? endTime, bool? isImportant, bool? isAllDayTask)
        {
            Description = description;
            StartDate = startDate;
            EndTime = endTime;
            IsImportant = isImportant;
            IsAllDayTask = isAllDayTask;
        }
    }
}
