using System;
using System.Collections.Generic;
using WL.Sample.EF.DAL.Model;

namespace WL.Sample.EF.DAL.Service
{
    public interface IDalService
    {
        IEnumerable<User> GetAll();
    }
}