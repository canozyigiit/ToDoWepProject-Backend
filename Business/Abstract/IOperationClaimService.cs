﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IOperationClaimService
    {
        IDataResult<OperationClaim> GetById(int id);

        IDataResult<OperationClaim> GetByName(string name);

        IDataResult<List<OperationClaim>> GetAll();

        IResult Add(OperationClaim operationClaim);

        IResult Update(OperationClaim operationClaim);

        IResult Delete(OperationClaim operationClaim);
    }
}
