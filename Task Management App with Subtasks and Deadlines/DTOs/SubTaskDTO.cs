using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_Management_App_with_Subtasks_and_Deadlines.DTOs
{
    public class SubTaskDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public string Status { get; set; }
        public int Position { get; set; }
    }
}