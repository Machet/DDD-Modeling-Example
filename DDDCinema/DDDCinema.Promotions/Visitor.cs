using System;

namespace DDDCinema.Promotions
{
    public class Visitor
    {
        public Guid Id { get; private set; }

        public Visitor(Guid id)
        {
            Id = id;
        }
    }
}
