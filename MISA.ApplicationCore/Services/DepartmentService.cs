
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Enums;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.ApplicationCore
{
    public class DepartmentService : BaseService<Department>, IDepartmentService
    {
        IBaseRepository<Department> _baseRepository;
        IDepartmentRepository _departmentRepository;
        #region Constructor
        public DepartmentService( IDepartmentRepository departmentRepository): base(departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        #endregion
        protected override bool ValidateCustom(Department entity)
        {
            return true;
        }
        #region Method
        public IEnumerable<Department> GetDepartmentPaging(int limit, int offset)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetDepartmentsByGroup(Guid groupId)
        {
            throw new NotImplementedException();
        }
        //public override int Add(Department entity)
        //{
        //    //validate thông tin 
        //    var isValid = true;
        //    //1.Check trùng mã khách hàng 
        //    var departmentDuplicate = _departmentRepository.GetEntityByCode(entity.DepartmentCode);
        //    if (departmentDuplicate != null)
        //    {
        //        isValid = false;
        //    }    
        //    //Logic validate
        //    if (isValid == true)
        //    {
        //        var res = base.Add(entity);
        //        return res;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}
        #endregion
    }
}
