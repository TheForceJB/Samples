using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WL.Sample.NSub.DAL;
using WL.Sample.NSub.Model;

namespace WL.Sample.NSub.Service
{ 
    public class AgeStcService
    {
        private readonly int supervisorMinLevel = 10;
        public IDalRepository DalRepository;

        public int CompanyAverageAge
        {
            get
            {
                var users = this.DalRepository.GetAll();
                return this.calAvgAge(users);
            }
        }



        public int CompanyMaxAge
        {
            get
            {
                var users = this.DalRepository.GetAll();
                return this.calMaxAge(users);
            }
        }


        public int CompanyMinAge
        {
            get
            {
                var users = this.DalRepository.GetAll();
                return this.calMinAge(users);
            }
        }
        public int SupervisorAverageAge
        {
            get
            {
                var users = this.DalRepository.GetSupervisors(supervisorMinLevel);
                return this.calAvgAge(users);
            }
        }

        public int SupervisorMaxAge
        {
            get
            {
                var users = this.DalRepository.GetSupervisors(supervisorMinLevel);
                return this.calMaxAge(users);
            }
        }

        public int SupervisorMinAge
        {
            get
            {
                var users = this.DalRepository.GetSupervisors(supervisorMinLevel);
                return this.calMinAge(users);
            }
        }


        public int GetAverageAgeOfLevel(int level)
        {
            var users = this.DalRepository.GetUsersOfLevel(level);
            return this.calAvgAge(users);
        }

        public int GetMaxAgeOfLevel(int level)
        {
            var users = this.DalRepository.GetUsersOfLevel(level);
            return this.calMaxAge(users);
        }

        public int GetMinAgeOfLevel(int level)
        {
            var users = this.DalRepository.GetUsersOfLevel(level);
            return this.calMinAge(users);
        }

        private int calAvgAge(List<User> users)
        {
            int sum = users.Sum(x => x.Age);
            return sum / users.Count;
        }

        private int calMaxAge(List<User> users)
        {
            return users.Max(x => x.Age);
        }

        private int calMinAge(List<User> users)
        {
            return users.Min(x => x.Age);
        }


    }
}
