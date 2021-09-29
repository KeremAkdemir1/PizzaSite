using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VatanBilgisayar.Models.Data;

namespace VatanBilgisayar.Models.Repositories
{
    public class GenericRepository<T> where T:class,new()
    {
        Context cnt = new Context();
        public List<T> TList()
        {
            return cnt.Set<T>().ToList();
        }

        public void TAdd(T c)
        {
            cnt.Set<T>().Add(c);
            cnt.SaveChanges();
        }

        public void TDelete(T c)
        {
            cnt.Set<T>().Remove(c);
            cnt.SaveChanges();
        }

        public void TUpdate(T c)
        {
            cnt.Set<T>().Update(c);
            cnt.SaveChanges();
        }
        public T TGetById(int id)
        {
            return cnt.Set<T>().Find(id);
        }

        public List<T> TList(string p)
        {
            return cnt.Set<T>().Include(p).ToList();
        }
    }
}
