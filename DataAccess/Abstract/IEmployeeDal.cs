﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Abstract
{
  public  interface IEmployeeDal:IEntityRepository<Employee>
  {
      List<EmployeeDto> GetallEmployeeDtos();
  }
}
