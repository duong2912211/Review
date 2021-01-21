using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    public interface IDepartmentService :IBaseService<Department>
    {
        /// <summary>
        /// Lấy dữ liệu phân trang
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        /// CreatedBy: NPDUONG (15/01/2021)
        IEnumerable<Department> GetDepartmentPaging(int limit, int offset);

        /// <summary>
        /// Lấy thông tin phòng ban theo nhóm
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        /// CreatedBy: NPDUONG (15/01/2021)
        IEnumerable<Department> GetDepartmentsByGroup(Guid groupId);
    }
}
