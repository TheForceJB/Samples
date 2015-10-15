using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WL.Sample.NSub.Model;

namespace WL.Sample.NSub.DAL
{
    public interface IDalRepository
    {
        List<User> GetAll();
        List<User> GetSupervisors(int level);
        List<User> GetUsersOfLevel(int level);
    }
}
