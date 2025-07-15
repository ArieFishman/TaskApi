using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using taskApi.Validators;

namespace taskApi.Models.DTOs.Task.Request
{
    public class CreateTaskRequestDto
    {
        [Required(ErrorMessage = "כותרת המשימה היא שדה חובה.")]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "יש לבחור עדיפות.")]
        [RegularExpression("נמוכה|בינונית|גבוהה", ErrorMessage = "העדיפות חייבת להיות: נמוכה, בינונית או גבוהה.")]
        public string Priority { get; set; } = "בינונית";

        [DefaultValue("2025-08-01T00:00:00")]
        [Required(ErrorMessage = "יש לבחור תאריך יעד.")]
        [ValidDate(ErrorMessage = "תאריך היעד אינו תקין.")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "יש לבחור סטטוס.")]
        [RegularExpression("ממתינה|בתהליך|הושלמה", ErrorMessage = "הסטטוס חייב להיות: ממתינה, בתהליך או הושלמה.")]
        public string Status { get; set; } = "ממתינה";
    }
}
