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

        [JsonProperty("streetNumber")]
        public int StreetNumber { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("suburb")]
        public string Suburb { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("postCode")]
        public string PostCode { get; set; }
    }
}
