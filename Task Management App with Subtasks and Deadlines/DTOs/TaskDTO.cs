using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task_Management_App_with_Subtasks_and_Deadlines.EF;

namespace Task_Management_App_with_Subtasks_and_Deadlines.DTOs
{
    public class TaskDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int CreatorsId { get; set; }
        public System.DateTime DeadLine { get; set; }
        public string Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubTask> SubTasks { get; set; }
        public virtual User User { get; set; }
    }
}