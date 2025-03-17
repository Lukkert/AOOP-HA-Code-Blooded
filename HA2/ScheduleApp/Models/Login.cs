namespace ScheduleApp.Models
{
    public class LoginDetails
    {
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        
        public override string ToString()
        {
            return $"{Name} ({Password})";
        }
    }
}