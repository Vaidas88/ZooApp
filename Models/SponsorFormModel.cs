using System.Collections.Generic;

namespace ZooApp.Models
{
    public class SponsorFormModel : SponsorModel
    {
        public List<AnimalModel> Animals { get; set; }
        public SponsorFormModel(List<AnimalModel> animals)
        {
            Animals = animals;
        }
        public SponsorFormModel()
        {
            Animals = new List<AnimalModel>();
        }
    }
}
