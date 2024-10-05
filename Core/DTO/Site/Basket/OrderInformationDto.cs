﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Site.Basket
{
    public class OrderInformationDto
    {
        public int Id { get; set; }
        public List<string> Names { get; set; }=new List<string>();
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }
        public List<string> ImagePaths { get; set; }
    }
}