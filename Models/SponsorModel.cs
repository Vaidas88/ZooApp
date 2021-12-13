using System.Collections.Generic;
using System.ComponentModel;
using ZooApp.Services;

namespace ZooApp.Models
{
    public class SponsorModel
    {
        public int Id { get; set; }

        [DisplayName("First Name:")]
        public string FirstName { get; set; }

        [DisplayName("Last Name:")]
        public string LastName { get; set; }

        [DisplayName("Amount to sponsor:")]
        public int Amount { get; set; }

        public int SponsoredAnimalId { get; set; }

        [DisplayName("Sponsored Animal:")]
        public AnimalModel SponsoredAnimal { get; set; }
    }
}
