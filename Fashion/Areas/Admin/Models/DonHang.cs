//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fashion.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DonHang
    {
        public DonHang()
        {
            this.ChiTietDonHang = new HashSet<ChiTietDonHang>();
        }
    
        public int MaDonHang { get; set; }
        public Nullable<System.DateTime> NgayDat { get; set; }
        public Nullable<System.DateTime> NgayGiaoHang { get; set; }
        public Nullable<int> MaKhachHang { get; set; }
        public Nullable<bool> TinhTrangGiaoHang { get; set; }
        public string GhiChu { get; set; }
    
        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }
        public virtual KhachHang KhachHang { get; set; }
    }
}