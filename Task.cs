using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public class TaskItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; } // Low, Medium, High
        public string Status { get; set; } // Pending, In Progress, Completed
        public string Category { get; set; } // like: Work, Personal, Study

    }
}