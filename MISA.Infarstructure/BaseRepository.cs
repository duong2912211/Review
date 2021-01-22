using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Enums;
using MISA.ApplicationCore.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MISA.Infarstructure
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>, IDisposable where TEntity : BaseEntity
    {
        #region Declare
        IConfiguration _configuration;
        string _connectionString = string.Empty;
        IDbConnection _dbConnection = null;
        string _tableName = typeof(TEntity).Name;
        #endregion

        #region Constructor
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MISACukCukConnectionString");
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region Method

        /// <summary>
        /// Lấy ra toàn bộ thông tin
        /// </summary>
        /// <returns></returns>
        /// CreatedBy : NPDUONG (12/01/2021)
        public virtual IEnumerable<TEntity> GetEntities()
        {
            //Kết nối tới CSDL
            //Khởi tạo các CommandText
            var entities = _dbConnection.Query<TEntity>($"Proc_Get{_tableName}s", commandType: CommandType.StoredProcedure);
            //Trả về dữ liệu
            return entities;
        }

        public virtual IEnumerable<TEntity> GetEntities(string storeName)
        {
            //Kết nối tới CSDL
            //Khởi tạo các CommandText
            var entities = _dbConnection.Query<TEntity>($"storeName", commandType: CommandType.StoredProcedure);
            //Trả về dữ liệu
            return entities;
        }

        /// <summary>
        /// Lấy ra thông tin dữ liệu qua ID
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// CreatedBy :NPDUONG (12/01/2021)
        public TEntity GetEntityById(Guid entityId)
        {
            var param = new DynamicParameters();
            param.Add("@EmployeeId", dbType: DbType.String, value: entityId.ToString(), direction: ParameterDirection.Input);
            var entities = _dbConnection.Query<TEntity>($"Proc_Get{_tableName}ById", param, commandType: CommandType.StoredProcedure).FirstOrDefault();            
            //Trả về dữ liệu
            return entities;
        }

        /// <summary>
        /// Láy thông tin dữ liệu qua mã 
        /// </summary>
        /// <param name="entityCode"></param>
        /// <returns></returns>
        /// CreatedBy : NPDUONG (12/01/2021)
        public TEntity GetEntityByCode(string entityCode)
        {
            //Khởi tạo các CommandText
            var entities = _dbConnection.Query<TEntity>($"Proc_Get{_tableName}ByCode", new { EntityCode = entityCode }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            //Trả về dữ liệu
            return entities;
        }

        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// CreatedBy : NPDUONG (12/01/2021)
        public int Add(TEntity entity)
        {
            var rowAffects = 0;
            _dbConnection.Open();
            using (var transaction = _dbConnection.BeginTransaction())
            {
                try
                {
                    var param = MappingDbType(entity);
                    //Thực thi commandText
                    rowAffects = _dbConnection.Execute($"Proc_Insert{_tableName}", param, commandType: CommandType.StoredProcedure);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
            return rowAffects;
        }

        /// <summary>
        /// Sửa thông tin
        /// </summary>
        /// <param name="entity></param>
        /// <returns></returns>
        /// CreatedBy : NPDUONG (12/01/2021)
        public int Update(TEntity entity)
        {
            //Khởi tạo kết nối tới CSDL
            var param = MappingDbType(entity);
            //Thực thi commandText
            var rowAffects = _dbConnection.Execute($"Proc_Update{_tableName}", param, commandType: CommandType.StoredProcedure);
            //Trả về kết quả ()
            return rowAffects;
        }

        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        /// CreatedBy : NPDUONG (12/01/2021)
        public int Delete(Guid entityId)
        {
            //Khởi tạo các CommandText
            var res = _dbConnection.Execute($"Proc_Delete{_tableName}", new { EntityId = entityId }, commandType: CommandType.StoredProcedure);
            //Trả về dữ liệu
            return res;
        }

        /// <summary>
        /// Đinh dạng dữ liệu 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        private DynamicParameters MappingDbType(TEntity entity)
        {
            var properties = entity.GetType().GetProperties();
            var param = new DynamicParameters();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    param.Add($"@{propertyName}", propertyValue, DbType.String);
                }
                else if (propertyType == typeof(bool) || propertyType == typeof(bool?))
                {
                    param.Add($"@{propertyName}", propertyValue, DbType.Int32);
                }
                else
                {
                    param.Add($"@{propertyName}", propertyValue);
                }
            }
            return param;
        }

        public TEntity GetEntityByProperty(TEntity entity, PropertyInfo property)
        {
            var propertyName = property.Name;
            var propertyValue = property.GetValue(entity);
            var keyValue = entity.GetType().GetProperty($"{_tableName}Id").GetValue(entity);
            var query = string.Empty;
            if (entity.EntityState == EntityState.AddNew)
            {
                query = $"SELECT * FROM {_tableName} WHERE {propertyName} = '{propertyValue}'";
            }
            else if (entity.EntityState == EntityState.Update)
            {
                query = $"SELECT * FROM {_tableName} WHERE {propertyName} = '{propertyValue}' AND {_tableName}Id <> '{keyValue}'";
            }
            else
            {
                return null;
            }
            var entityReturn = _dbConnection.Query<TEntity>(query, commandType: CommandType.Text).FirstOrDefault();
            return entity;
        }

        public void Dispose()
        {
            if (_dbConnection.State == ConnectionState.Open)
            {
                _dbConnection.Close();
            }
        }
        #endregion
    }
}
