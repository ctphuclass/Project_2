﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DoanhThu_DTO
    {
        public string Ten_Ban { get; set; }
        public  DateTime Ngay_Lap { get; set; }
        public string Ten_SP { get; set; }
        public string Loai { get; set; }
        public int Thanh_Tien { get; set; }
        public DateTime Ngay_Dau { get; set; }
        public DateTime Ngay_cuoi { get; set; }
        public int TongThanhTien { get; set; }
        public DateTime Ngay_Hien_Tai { get; set; }
        public string Error { get; set; }
        public int TongThanhTien_First { get; set; }
        public string Error_First { get; set; }
    }
}
