﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Abstract
{
   public interface IManagerDal:IEntityRepository<Manager>
   {
       List<ManagerDto> GetAllManagerDetails(); 
       ManagerDto GetManagerDetails(Expression<Func<Manager, bool>> filter = null);
    }
}
