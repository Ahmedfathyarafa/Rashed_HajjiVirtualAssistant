﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CallRequestDetailsDTO
    {
        public string CalleeName { get; set; }
        public string CallerName { get; set; }
        public string Message { get; set; }
        public byte[] Image { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime RequestTime { get; set; }
    }
}
