namespace DotnetAPI.Models
{
    public partial class HMCTSTask
    {
        public int TaskId {get; set;}
        public string Title {get; set;}
        public string Description {get; set;}
        public string Status {get; set;}
        public DateTime DueDateTime {get; set;}

        public HMCTSTask()
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
