using System;

namespace API.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}