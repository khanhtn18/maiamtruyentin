namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Children
    {
        public int ID { get; set; }

        [StringLength(50)]
        [DisplayName(" Mã trẻ ")]
        public string Code { get; set; }

        [StringLength(250)]
        [DisplayName(" Mã bảo hiểm xã hội ")]
        public string SocialInsurance { get; set; }

        [DisplayName("Ngày mua")]
        public DateTime? BoughtDate { get; set; }

        [DisplayName("Ngày hết hạn")]
        public DateTime? EndDate { get; set; }

        [StringLength(250)]
        [DisplayName("Họ và tên")]
        public string FullName { get; set; }

        [StringLength(250)]
        [DisplayName("Tuổi")]
        public string Age { get; set; }

        [DisplayName("Ngày sinh")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(250)]
        [DisplayName("Giới tính")]
        public string Gender { get; set; }

        [StringLength(250)]
        [DisplayName("Hình ảnh")]
        public string Image { get; set; }

        [StringLength(250)]
        [DisplayName("Giấy khai sinh")]
        public string BirthCertificate { get; set; }

        [DisplayName("HK01")]
        public bool? Hk01 { get; set; }

        [DisplayName("HK02")]
        public bool? Hk02 { get; set; }

        [DisplayName("Chi phí ăn uống")]
        public decimal? FoodExpenses { get; set; }

        [DisplayName("Học phí")]
        public decimal? EducationExpenses { get; set; }

        [DisplayName("Xác nhận giấy tờ")]
        public bool? Confirmation { get; set; }

        [StringLength(250)]
        [DisplayName("Lý do đến với mái ấm")]
        public string EnrollReason { get; set; }

        [DisplayName("Mã hoàn cảnh trẻ")]
        public int? CategoryID { get; set; }

        [StringLength(50)]
        [DisplayName("Mã tham vấn tâm lý")]
        public string CounselingID { get; set; }

        [StringLength(50)]
        [DisplayName("Mã học bạ")]
        public string SchoolReportID { get; set; }

        [StringLength(50)]
        [DisplayName("Mã sổ hộ gia đình công giáo")]
        public string XFamilyBookID { get; set; }

        [StringLength(250)]
        [DisplayName("Học vấn")]
        public string EducationID { get; set; }

        [StringLength(250)]
        [DisplayName("Vấn đề tham vấn")]
        public string Problem { get; set; }

        [DisplayName("Số lần tham vấn")]
        public int? Time { get; set; }

        [StringLength(250)]
        [DisplayName("Mã phiếu tham vấn tâm lý")]
        public string Ticket { get; set; }

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
