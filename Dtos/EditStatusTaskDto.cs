namespace DotnetAPI.Dtos
{
    public partial class EditStatusTaskDto
    {
        public int TaskId {get; set;}
        public string Status {get; set;}

        public EditStatusTaskDto ()
        {         
            if (Status == null)
            {
                Status = "";
            }
        }
    }
}
