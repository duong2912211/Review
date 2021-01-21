using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class Department : BaseEntity
    {
        #region Declare

        #endregion

        #region Constructor
        public Department()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// ID phòng ban
        /// </summary>
        /// CreatedBy : NPDUONG (15/01/2021)
        [PrimaryKey]
        public Guid? DepartmentId { get; set; }
        /// <summary>
        /// Mã phòng ban
        /// </summary>
        /// CreatedBy : NPDUONG (15/01/2021)
        [Required]
        [CheckDuplicate]
        [DisplayName("Mã phòng ban")]
        [MaxLength(20,"Mã khách hàng không được vượt quá 20 kí tự")]
        public string DepartmentCode { get; set; }
        /// <summary>
        /// Tên phòng ban
        /// </summary>
        /// CreatedBy : NPDUONG (15/01/2021)
        public string DepartmentName { get; set; }
        /// <summary>
        /// Mô tả
        /// </summary>
        /// CreatedBy : NPDUONG (15/01/2021)
        public string  Description { get; set; }
        /// <summary>
        /// Ngày tạo    
        /// </summary>
        /// CreatedBy : NPDUONG (15/01/2021)
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Người tạo
        /// </summary>
        /// CreatedBy : NPDUONG (15/01/2021)
        public string CreatedBy { get; set; }
        /// <summary>
        /// Ngày chỉnh sửa 
        /// </summary>
        /// CreatedBy : NPDUONG (15/01/2021)
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Người chỉnh sửa
        /// </summary>
        /// CreatedBy : NPDUONG (15/01/2021)
        public string ModifiedBy { get; set; }
        #endregion

        #region Method

        #endregion
    }
}
