﻿using PlatDuJour.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatDuJour.DAL.IServices
{
    public interface ICategoryRepos :IGenericRepos<Category>
    {
        Task<Category> GetByName(string Name);
    }
}