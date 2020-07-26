using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSIMS.Models
{
    public class Address
    {
        [Key]
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("studentId")]
        public int StudentId { get; set; }

        [JsonIgnore]
        internal Student Student { get; set; }

        [Required]
        [JsonProperty("streetNumber")]
        public int StreetNumber { get; set; }

        [Required, MaxLength(100)]
        [JsonProperty("street")]
        public string Street { get; set; }

        [Required, MaxLength(100)]
        [JsonProperty("suburb")]
        public string Suburb { get; set; }

        [Required, MaxLength(100)]
        [JsonProperty("city")]
        public string City { get; set; }

        [Required, MaxLength(100)]
        [JsonProperty("country")]
        public string Country { get; set; }

        [Required, MaxLength(100)]
        [JsonProperty("postCode")]
        public string PostCode { get; set; }
    }
}
