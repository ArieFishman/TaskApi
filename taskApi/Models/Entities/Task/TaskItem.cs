namespace taskApi.Models.Entities.Task
{
    public class TaskItem
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string Priority { get; set; } = "בינונית"; // נמוכה / בינונית / גבוהה

        public DateTime DueDate { get; set; }

        public string Status { get; set; } = "ממתינה"; // ממתינה / בתהליך / הושלמה
    }
}
