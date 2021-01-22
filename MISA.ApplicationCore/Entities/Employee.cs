using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entities
{
    /// <summary>
    /// Nhân viên
    /// </summary>
    /// CreatedBy: DUONG (11/01/2021)
    public class Employee  : BaseEntity
    {
        #region Declare

        #endregion

        #region Constructor
        public Employee()
        {

        }
        #endregion

        #region Property
        /// <summary>
        /// Id nhân viên
        /// </summary>
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Tên nhân viên
        /// </summary>
        public string EmployeeName { get; set; }
        /// <summary>
        /// Ngày tháng năm sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Giới tính (0 - Nam , 1 - Nữ, 2 - Khác)
        /// </summary>
        public int Gender { get; set; }
        /// <summary>
        /// Chứng minh nhân dân
        /// </summary>
        public string IdCard { get; set; }
        /// <summary>
        /// Ngày cấp thẻ
        /// </summary>
        public DateTime?  CardDateRange { get; set; }
        /// <summary>
        /// Nơi cấp
        /// </summary>
        public string IdCardIssue { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Id phòng ban
        /// </summary>
        public Guid DepartmentId { get; set; }

        ///<summary>
        /// Id phòng ban
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Mã chức vụ
        /// </summary>
        public string PositionId { get; set; }
        /// <summary>
        /// Chức vụ
        /// </summary>
        public string PositionName { get; set; }
        /// <summary>
        /// Tên công ty
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Mã số thuế cá nhân
        /// </summary>
        public string PersonalTaxCode { get; set; }
        /// <summary>
        /// Lương
        /// </summary>
        public double Salary { get; set; }
        /// <summary>
        /// Ngày gia nhập
        /// </summary>
        public DateTime? JoinDate { get; set; }
        /// <summary>
        /// Tình trạng công việc
        /// </summary>
        public string WorkStatusName { get; set; }
        /// <summary>
        /// Mô tả 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Ngày lập
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Người lập
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Ngày chỉnh sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Người chỉnh sửa
        /// </summary>
        public string ModifiedBy { get; set; }
        #endregion

        #region Method

        #endregion
    }
}
