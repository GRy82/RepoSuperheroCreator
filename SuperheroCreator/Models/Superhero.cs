using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperheroCreator.Models
{
    public class Superhero
    {
        [Key]
        public int SuperheroId { get; set; }
        public string HeroName { get; set; }

        public string CivilianName { get; set; }

        public string PrimaryAbility { get; set; }

        public string SecondaryAbility { get; set; }

        public string CatchPhrase { get; set; }
    }
}
