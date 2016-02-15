using System.Collections.Generic;

namespace DDDCinema.Presentation
{
    public class MovieDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<SeanseDTO> ShowTimes { get; set; }
    }
}
