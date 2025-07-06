namespace JuanBosch.App.Models.Blood
{
    public class Blood
    {
        public int BloodId { get; set; }
        public string BloodType { get; set; } = string.Empty;
        public Boolean ConsentBlood {get; set;} = false;
    }
}