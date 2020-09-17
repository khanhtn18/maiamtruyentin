namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Volunteer")]
    public partial class Volunteer
    {
        [DisplayName("Mã")]
        public int ID { get; set; }

        [StringLength(50)]
        [DisplayName("Mã tình nguyện viên")]
        public string Code { get; set; }

        [StringLength(11)]
        [DisplayName("Chứng minh nhân dân")]
        public string IdentityCard { get; set; }

        [StringLength(250)]
        [DisplayName("Họ và tên")]
        public string Name { get; set; }

        [StringLength(500)]
        [DisplayName("Tuổi")]
        public string Age { get; set; }

        [StringLength(250)]
        [DisplayName("Giới tính")]
        public string Gender { get; set; }

        [StringLength(250)]
        [DisplayName("Hình ảnh")]
        public string Image { get; set; }

        [StringLength(11)]
        [DisplayName("Số điện thoại")]
        public string Phone { get; set; }

        [StringLength(50)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [StringLength(50)]
        [DisplayName("Quốc tịch")]
        public string Nationality { get; set; }

        [StringLength(250)]
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }

        [StringLength(50)]
        [DisplayName("Chi phí ăn uống")]
        public string OtherFoodExpenses { get; set; }

        [DisplayName("Thời gian bắt đầu")]
        public DateTime? WorkingHour { get; set; }

        [DisplayName("Thời gian kết thúc")]
        public DateTime? OffHour { get; set; }

        [DisplayName("Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(500)]
        [DisplayName("Người tạo")]
        public string CreatedBy { get; set; }

        [DisplayName("Ngày cập nhật")]
        public DateTime? ModifiedDate { get; set; }

        [StringLength(500)]
        [DisplayName("Người cập nhật")]
        public string ModifiedBy { get; set; }

        [DisplayName("Trạng thái")]
        public bool Status { get; set; }
    }
}
