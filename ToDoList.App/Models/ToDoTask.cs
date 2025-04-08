namespace ToDoList.App.Models
{
    public class ToDoTask
    {
        public  int Id { get; set; }
        public int Priority { get; set; }
        public string? TaskDescription { get; set; }
        public bool IsCompleted { get; set; }

    }
}
