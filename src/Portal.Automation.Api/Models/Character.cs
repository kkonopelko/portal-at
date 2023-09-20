using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Portal.Automation.Api.Models
{
    public class Character
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        [JsonPropertyName("alternate_names")]
        public List<string> AlternateNames { get; set; }

        public string Species { get; set; }

        public string Gender { get; set; }

        public string House { get; set; }

        public string DateOfBirth { get; set; }

        public int? YearOfBirth { get; set; }

        public bool Wizard { get; set; }

        public string Ancestry { get; set; }

        public string EyeColour { get; set; }

        public string HairColour { get; set; }

        public Wand Wand { get; set; }

        public string Actor { get; set; }
    }

    public class Wand
    {
        public string Wood { get; set; }

        public string Core { get; set; }

        public decimal? Length { get; set; }
    }
}
