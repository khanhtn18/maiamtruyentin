namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [DisplayName("Mã nhân viên")]
        public int ID { get; set; }

        [StringLength(50)]
        [DisplayName("Mã nhân viên")]
        public string Code { get; set; }

        [StringLength(11)]
        [DisplayName("Chứng minh nhân dân")]
        public string IdentityCard { get; set; }

        [StringLength(250)]
        [DisplayName("Họ và tên")]
        public string Name { get; set; }

        [DisplayName("Tuổi")]
        public int? Age { get; set; }

        [StringLength(250)]
        [DisplayName("Giới tính")]
        public string Gender { get; set; }

        [StringLength(250)]
        [DisplayName("Hình ảnh")]
        public string Image { get; set; }

        [DisplayName("Ngày sinh")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(50)]
        [DisplayName("Địa chỉ thường trú")]
        public string Domicile { get; set; }

        [StringLength(250)]
        [DisplayName("Nơi sinh")]
        public string PlaceOfBirth { get; set; }

        [DisplayName("Học vấn")]
        public int? Education { get; set; }

        [StringLength(250)]
        [DisplayName("Học tại")]
        public string StudiedAt { get; set; }

        [StringLength(250)]
        [DisplayName("Ngoại ngữ")]
        public string Language { get; set; }

        [StringLength(250)]
        [DisplayName("Tin học")]
        public string InformationTechnology { get; set; }

        [StringLength(250)]
        [DisplayName("Công việc")]
        public string Job { get; set; }

        [StringLength(250)]
        [DisplayName("Vị trí")]
        public string JobName { get; set; }

        [StringLength(250)]
        [DisplayName("Số điện thoại")]
        public string Phone { get; set; }

        [StringLength(250)]
        [DisplayName("Tôn giáo")]
        public string Religion { get; set; }

        [StringLength(250)]
        [DisplayName("Lương khởi đầu")]
        public string StartingSalagy { get; set; }

        [DisplayName("Lương thưởng")]
        public decimal? GiftSalary { get; set; }

        [DisplayName("Chi phí ăn uống")]
        public decimal? AllOtherFoodExpenses { get; set; }

        [StringLength(250)]
        [DisplayName("Loại hợp đồng")]
        public string ContractType { get; set; }

        [DisplayName("Tình trạng hợp đồng")]
        public bool? WorkingContract { get; set; }

        [DisplayName("Ngày bắt đầu làm việc")]
        public DateTime? WorkingDate { get; set; }

        [DisplayName("Ngày nghỉ việc")]
        public DateTime? StoppedWorkingDate { get; set; }

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
