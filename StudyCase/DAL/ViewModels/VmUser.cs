using System.Text.Json.Serialization;

namespace StudyCaseWebApp.DAL.Models
{
    public class VmUser
    {
        [JsonIgnore]
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsPassive { get; set; }
        public string Password { get; set; }

        [JsonIgnore]
        public DateTime CreatedDateTime { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedDateTime { get; set; }
    }

    public class VmUpdateUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsPassive { get; set; }
    }

    public class VmGetUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsPassive { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
    }

}
