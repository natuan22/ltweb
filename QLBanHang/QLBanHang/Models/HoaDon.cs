//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            this.CTHDs = new HashSet<CTHD>();
        }
        [Display(Name = "M? ho? ??n")]
        public string MaHD { get; set; }
        [Display(Name = "M? kh?ch h?ng")]
        public string MaKH { get; set; }
        [Display(Name = "M? nh?n vi?n")]
        public Nullable<int> MaNV { get; set; }
        [Display(Name = "Ng?y l?p ho? ??n")]
        public System.DateTime NgayLapHD { get; set; }
        [Display(Name = "Ng?y giao h?ng")]
        public System.DateTime NgayGiaoHang { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD> CTHDs { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual Nhanvien Nhanvien { get; set; }
    }
}
