﻿using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepository
{
    public interface IDashboardREspositiry
    {
        List<Dashboard1> GetDashboardDetails();
        
    }
}