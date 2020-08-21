﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMSFactory.Models
{
    public class ChartModel
    {
        public string DataString { get; set; }
        public string MainString { get; set; }
        public int Year { get; set; }
        
        // 도넛 차트
        public string DoughnutDataString { get; set; }
        public string Product_Count { get; set; }
    }
}