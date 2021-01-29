using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.EF;

namespace BaiNopCuoiKi7.Areas.Users.Models
{
    [Serializable]
    public class ThongTinGioHang
    {
        public SanPham SanPham { get; set; }
        public int Soluong { get; set; }
    }
}