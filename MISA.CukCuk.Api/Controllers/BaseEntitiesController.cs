using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Enums;
using MISA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseEntitiesController<TEntity> : ControllerBase
    {
        IBaseService<TEntity> _baseService;
        public BaseEntitiesController(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }

        #region Method
        /// <summary>
        /// Lấy tất cả phòng ban
        /// </summary>
        /// <param name="department"></param>
        /// <returns>List danh sách phòng ban</returns>
        /// CreatedBy : NPDUONG (11/01/2021)
        [HttpGet]
        public IActionResult Get()
        {
            var entities = _baseService.GetEntities();
            return Ok(entities);
        }
        /// <summary>
        /// Lấy thông tin phòng ban theo Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// CreatedBy: NPDUONG(12/01/2021)
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var entities = _baseService.GetEntityById(id);
            return Ok(entities);
        }

        /// <summary>
        /// Lấy thông tin phòng ban theo mã phòng ban
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns> 
        /// CreatedBy: NPDUONG(12/01/2021)
        [HttpGet("a/{code}")]
        public IActionResult Get(string code)
        {
            var entities = _baseService.GetEntityByCode(code);
            return Ok(entities);
        }

        /// <summary>
        /// Thêm thông tin phòng ban mới
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        /// CreatedBy : NPDUONG(12/01/2021)
        [HttpPost]
        public IActionResult Post(TEntity entity)
        {
            var serviceResult = _baseService.Add(entity);
            if( serviceResult.MISACode == ApplicationCore.Enums.MISACode.NotValid)
            {
                return BadRequest(serviceResult.Data);
            }
            else
            {
                return Ok(serviceResult);
            }
            
        }
        /// <summary>
        /// Sửa thông tin phòng ban  theo ID
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        /// CreatedBy: NPDUONG(12/01/2021)
        [HttpPut]
        public IActionResult Put([FromRoute]string id, [FromBody] TEntity entity)
        {
            var keyProperty = entity.GetType().GetProperty($"{typeof(TEntity).Name}Id");
            if (keyProperty.PropertyType == typeof(Guid))
            {
                keyProperty.SetValue(entity, Guid.Parse(id));
            }
            else if(keyProperty.PropertyType == typeof(int))
            {
                keyProperty.SetValue(entity, int.Parse(id));
            }
            else
            {
                keyProperty.SetValue(entity, id);
            }                
            keyProperty.SetValue(entity, id);
            var rowAffects = _baseService.Update(entity);
            return Ok(rowAffects);
        }
        /// <summary>
        /// Xóa thông tin phòng ban theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// CreatedBy: NPDUONG (12/01/2021)
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var rowAffects = _baseService.Delete(id);
            return Ok(rowAffects);
        }

        #endregion

    }
}
