namespace JuanBosch.App.Dtos.Bloods
{
    public class BloodReadDto
    {
        public int BloodId { get; set; }
        public string BloodType { get; set; }
        public bool ConsentBlood { get; set; }
    }

    public class BloodUpdateDto
    {
        public int BloodId { get; set; }
        public string BloodType { get; set; }
        public bool ConsentBlood { get; set; }
    }

    public class BloodCreateDto
    {
        public required string BloodType { get; set; }
        public bool ConsentBlood { get; set; }
    }
}