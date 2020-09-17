using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class ChildrenViewModel
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string FullName { get; set; }
        public string CateName { get; set; }
        [StringLength(250)]
        [DisplayName("Ảnh đại diện")]
        public string Image { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Status { get; set; }
    }
}
