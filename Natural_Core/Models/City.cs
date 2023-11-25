﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Natural_Core.Models
{
    public partial class City
    {
        public City()
        {
            Areas = new HashSet<Area>();
            Distributors = new HashSet<Distributor>();
        }

        public string Id { get; set; }
        public string CityName { get; set; }
        public string StateId { get; set; }

        public virtual State State { get; set; }
        public virtual ICollection<Area> Areas { get; set; }
        public virtual ICollection<Distributor> Distributors { get; set; }
    }
}
