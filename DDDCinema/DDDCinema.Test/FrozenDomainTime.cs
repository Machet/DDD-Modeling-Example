﻿using DDDCinema.Common;
using System;

namespace DDDCinema.Test
{
    internal class FrozenDomainTime : DomainTime
    {
        private DateTime _time;

        public FrozenDomainTime(DateTime time)
        {
            _time = time;
        }

        public override DateTime Now
        {
            get { return _time; }
        }

        public static DomainTimeScope At(DateTime time)
        {
            return new DomainTimeScope(new FrozenDomainTime(time));
        }
    }
}
