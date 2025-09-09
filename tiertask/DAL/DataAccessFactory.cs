﻿using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static INewsRepo NewsData()
        {
            return new NewsRepo();
        }
        public static ICategoryRepo CategoryData() {
        return new CategoryRepo();
        }

    }
}

