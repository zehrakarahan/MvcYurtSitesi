﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YurtYesilKaya.Entity.Entity;


namespace YurtYesilKaya.Bll.Abstract
{
    public interface IillerService
    {
        List<il> GetAll();
        List<il> GetProductsByilName(string ilName);
    }
}