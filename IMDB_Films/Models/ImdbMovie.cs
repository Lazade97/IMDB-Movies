﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB_Films.Models
{
    public class ImdbMovie
    {
        public string Id { get; set; }

        public string Image { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
