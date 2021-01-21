using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Enums;
using MISA.ApplicationCore.Entities;

namespace MISA.CukCuk.Api.Controllers
{
    /// <summary>
    /// Api danh sách phòng ban
    /// </summary>
    public class DepartmentsController : BaseEntitiesController<Department>
    {
        IBaseService<Department> _baseService;
        public DepartmentsController(IBaseService<Department> baseService) : base(baseService)
        {
            _baseService = baseService;
        }
    }
}
