namespace DotnetAPI.Dtos
{
    public partial class TaskToAddDto
    {
        public string Title {get; set;}
        public string Description {get; set;}
        public string Status {get; set;}
        public DateTime DueDateTime {get; set;}

        public TaskToAddDto()
        {
            if (Title == null)
            {
                Title = "";
            }

            if (Description == null)
            {
                Description = "";
            }

            if (Status == null)
            {
                Status = "";
            }
        }
    }
}
