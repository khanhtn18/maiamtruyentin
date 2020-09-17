namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã người dùng")]
        public int ID { get; set; }

        [StringLength(50)]
        [DisplayName("Tài khoản")]
        public string UserName { get; set; }

        [StringLength(32)]
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }

        [StringLength(50)]
        [DisplayName("Họ và tên")]
        public string Name { get; set; }

        [StringLength(50)]
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }

        [DisplayName("Email")]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        [DisplayName("Số điện thoại")]
        public string Phone { get; set; }

        [StringLength(250)]
        [DisplayName("Hình ảnh")]
        public string Image { get; set; }
        [DisplayName("Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        [DisplayName("Người tạo")]
        public string CreatedBy { get; set; }

        [DisplayName("Ngày cập nhật")]
        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        [DisplayName("Người cập nhật")]
        public string ModifiedBy { get; set; }

        [DisplayName("Trạng thái")]
        public bool Status { get; set; }
    }
}
