﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nepaltech.Models.Forms
{
    public class CountryModel
    {
        public string Id { get; set; }
        [Required]
        public string CountryName { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
