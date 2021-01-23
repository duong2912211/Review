using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity:BaseEntity
    {
        IBaseRepository<TEntity> _baseRepository;
        ServiceResult _serviceResult;
        #region Constructor
        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult() { MISACode = Enums.MISACode.Success };
        }
        #endregion
        #region Method
        //lấy danh sách phòng ban
        public IEnumerable<TEntity> GetEntities()
        {
            var entities = _baseRepository.GetEntities();
            return entities;
        }

        //Lấy thông tin phòng ban theo Id 
        public TEntity GetEntityById(Guid entityId)
        {
            
         var entities = _baseRepository.GetEntityById(entityId);
            return entities;
            
        }

        //Lấy thông tin phòng ban theo mã phòng ban
        public TEntity GetEntityByCode(string entityCode)
        {
            var entities = _baseRepository.GetEntityByCode(entityCode);
            return entities;
        }
        //Thêm mới phòng ban
        public virtual ServiceResult Add(TEntity entity)
        {
            entity.EntityState = Enums.EntityState.AddNew;  
            //Thực hiện validate:
            var isValidate = Validate(entity);
              
            if(isValidate == true)
            {
                _serviceResult.Data = _baseRepository.Add(entity);
                _serviceResult.MISACode = Enums.MISACode.IsValid;
                return _serviceResult;
            }
            else
            {
                return _serviceResult;
            }
        }

        //Sửa thông tin phòng ban
        public ServiceResult Update(TEntity entity)
        {
            entity.EntityState = Enums.EntityState.Update;
            ServiceResult serviceResult = new ServiceResult();
            //Thực hiện validate:
            var isValidate = Validate(entity);
            if (isValidate == true)
            {
                serviceResult.Data = _baseRepository.Update(entity);
                serviceResult.MISACode = Enums.MISACode.IsValid;
                return serviceResult;
            }
            else
            {
                serviceResult.Data = _baseRepository.Update(entity);
                serviceResult.MISACode = Enums.MISACode.NotValid;
                return serviceResult;
            }
        }

        //Xóa phòng ban
        public ServiceResult Delete(Guid entityId)
        {
            _serviceResult.Data = _baseRepository.Delete(entityId);
            return _serviceResult;
        }

        private bool Validate(TEntity entity)
        {
            var messError = new List<string>();
            var isValidate = true;
            var serviceResult = new ServiceResult();
            //đọc các properties
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(entity);
                var displayName = string.Empty;
                var displayNameAttributes = property.GetCustomAttributes(typeof(DisplayName), true);
                if(displayNameAttributes.Length >0 )
                {
                    displayName = (displayNameAttributes[0] as DisplayName).Name;   
                }    
                //Ktra xem có attribute cần validate ko 
                if (property.IsDefined(typeof(Required), false))
                {
                    //Check bắt buộc nhập
                    if (propertyValue == null)
                    { 
                        isValidate = false;
                        messError.Add(string.Format(Properties.Resources.Msg_isNotValid,displayName));
                        _serviceResult.MISACode = Enums.MISACode.NotValid;
                        _serviceResult.Messenger = Properties.Resources.Msg_isNotValid;
                    }
                }
                else if (property.IsDefined(typeof(CheckDuplicate), false))
                {
                    //Check trùng dữ liệu 
                    var propertyName = property.Name;
                    var entityDuplicate = _baseRepository.GetEntityByProperty(entity,property);
                        if(entityDuplicate != null)
                        {
                            isValidate = false;
                            messError.Add(string.Format(Properties.Resources.Msg_isNotValid,displayName));
                            _serviceResult.MISACode = Enums.MISACode.NotValid;
                            _serviceResult.Messenger = Properties.Resources.Msg_isNotValid;
                        }    
                 }
                else if (property.IsDefined(typeof(MaxLength), false))
                {
                    //Check độ dài tối đa
                    var attributeMaxLength = property.GetCustomAttributes(typeof(MaxLength), true)[0];
                    var length = (attributeMaxLength as MaxLength).Value;
                    var msg = (attributeMaxLength as MaxLength).ErrorMsg;
                    if(propertyValue.ToString().Trim().Length> length)
                    {
                        isValidate = false;
                        messError.Add(msg??$"Thông tin vượt quá {length} kí tự ");
                        _serviceResult.MISACode = Enums.MISACode.NotValid;
                        _serviceResult.Messenger = "Dữ liệu không hợp lệ";
                    }    
                }
            }
            _serviceResult.Data = messError;
            if (isValidate == true)
            {
                isValidate = ValidateCustom(entity);
            }   
            return isValidate;
        }
        /// <summary>
        /// Hàm thực hiện ktra dữ liệu / nghiệp cụ tùy chỉnh 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected virtual bool ValidateCustom(TEntity entity)
        {
            return true;
        }
        #endregion
    }
}
