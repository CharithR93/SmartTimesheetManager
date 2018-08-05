using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TimesheetManagerApp.Core.Repository;

namespace TimesheetManagerApp.Core.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly DbContext context;
        private bool _dispose;


        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        private Repository<PaymentPlan> _paymentPlan;
        private Repository<Company> _company;
        private Repository<User> _user;
        private Repository<Company_User> _companyUser;


        public Repository<PaymentPlan> PaymentPlan
        {
            get
            {
                if(this._paymentPlan == null)
                {
                    this._paymentPlan = new Repository<PaymentPlan>(context);
                    
                }
                return _paymentPlan;

            }
        }

        public Repository<Company> Company
        {
            get
            {
                if(this._company == null)
                {
                    this._company = new Repository<Company>(context);
                }
               
                return this._company;
            }
        }

        public Repository<User> User
        {
            get
            {
                if(this._user == null)
                {
                    this._user = new Repository<User>(context);
                }
              
                return _user;
            }
        }

        public Repository<Company_User> CompanyUser
        {
            get
            {
                if(this._companyUser == null)
                {
                    this._companyUser = new Repository<Company_User>(context);
                }
                
                return this._companyUser;
            }
        }

        public int Complete()
        {
            try
            {
              return  context.SaveChanges();
            }
            catch(Exception ex)
            {
                return 0;
            }
        }
    }
}
