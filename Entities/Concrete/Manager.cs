﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;


namespace Entities.Concrete
{
  public  class Manager:IEntity
    {
        public int ManagerId { get; set; }
        public int UserId { get; set; }
     
    }
}
