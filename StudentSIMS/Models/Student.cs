using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace StudentSIMS.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("studentId")]
        public int StudentId { get; set; }

        [Required, MaxLength(100)]
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [Required]
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [Required]
        [JsonPropertyName("emailAddress")]
        public string EmailAddress { get; set; }

        [Required]
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("timeCreated")]
        public DateTime TimeCreated { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [System.Text.Json.Serialization.JsonIgnore]
        public Address Address { get; set; }
    }
}
