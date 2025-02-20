﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
  public interface IUserOperationClaimService
    {
        IDataResult<UserOperationClaim> GetById(int id);
        IDataResult<UserOperationClaim> GetByUserClaimEmail(string email);

        IDataResult<List<UserOperationClaim>> GetAll();

        IResult AddUserClaim(User user);

        IResult Add(UserOperationClaim userOperationClaim);

        IResult Update(UserOperationClaim userOperationClaim);

        IResult Delete(UserOperationClaim userOperationClaim);
    }
}
