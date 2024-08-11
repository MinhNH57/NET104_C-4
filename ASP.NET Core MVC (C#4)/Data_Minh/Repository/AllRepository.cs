using Data_Minh.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Minh.Repository
{
    public class AllRepository<H> : IAllRepository<H> where H : class
    {
        private readonly MyDbContext _dbContext;

        DbSet<H> _dbSet;
        
        public AllRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<H>();
        }


        public bool CreateObj(H obj)
        {
            try
            {
                _dbSet.Add(obj);
                _dbContext.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                throw new Exception();
            }
        }

        public bool DeleteObj(dynamic id)
        {
            try
            {
                var d = _dbSet.Find(id);
                _dbSet.Remove(d);
                _dbContext.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ICollection<H> GetAll()
        {
           return _dbSet.ToList();
        }

        public H GetByID(dynamic id)
        {
            return _dbSet.Find(id).FirstOrDefault();
        }

        public bool UpdateObj(H obj)
        {
            try
            {
                _dbSet.Update(obj);
                _dbContext.SaveChanges ();
                return true;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
