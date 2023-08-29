using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List
{
    public class TaskToDo
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }

        public TaskToDo()
        {
            Name = string.Empty; 
            Description = string.Empty;
            Priority = Priority.Low;
            Status = Status.NotCompleted;
        }
        public TaskToDo(string name , string description , Priority priority,Status status)
        {
            Name = name;
            Description = description;
            Priority = priority;
            Status = status;
        }


        public override string ToString()
        {
            return $"Task Name : {Name}  , Description : {Description}   , Priority : {Priority} , Status : {Status}";
        }
    }
}
