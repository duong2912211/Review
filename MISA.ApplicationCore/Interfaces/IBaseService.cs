using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interfaces
{
    public interface IBaseService<TEntity>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu 
        /// </summary>
        /// <returns></returns>
        /// CreatedBy : NPDUONG(15/01/2021)
        IEnumerable<TEntity> GetEntities();
        /// <summary>
        /// Lấy dữ liệu theo id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// CreatedBy : NPDUONG(15/01/2021)
        TEntity GetEntityById(Guid entityId);
        /// <summary>
        /// Lấy dữ liệu qua mã 
        /// </summary>
        /// <param name="entityCode"></param>
        /// <returns></returns>
        /// CreatedBy : NPDUONG(15/01/2021)
        TEntity GetEntityByCode(string entityCode);
        /// <summary>
        /// Thêm dữ liệu 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// CreatedBy : NPDUONG(15/01/2021)
        ServiceResult Add(TEntity entity);
        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// CreatedBy : NPDUONG(15/01/2021)
        ServiceResult Update(TEntity entity);
        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// CreatedBy : NPDUONG(15/01/2021)
        ServiceResult Delete(Guid entityId);
    }
}
