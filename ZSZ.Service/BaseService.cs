using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.IService;
using ZSZ.Service.Entities;

namespace ZSZ.Service
{
    class BaseService<T> where T:BaseEntity
    {
        private MyDbContext db;
        public BaseService(MyDbContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// 获取所有没有软删除的数据
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return db.Set<T>().Where(e => e.IsDeleted == false);
        }

        /// <summary>
        /// 获取总数据条数
        /// </summary>
        /// <returns></returns>
        public long GetTotalCount()
        {
            return GetAll().LongCount();
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public IQueryable<T> GetPagedData(int start, int count)
        {
            return GetAll().OrderBy(e => e.CreateDateTime).Skip(start).Take(count);
        }

        /// <summary>
        /// 根据Id查找数据，查不到返回null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(long id)
        {
            return GetAll().Where(e => e.Id == id).SingleOrDefault();
        }

        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="id"></param>
        public void MarkDeleted(long id)
        {
            var data = GetById(id);
            data.IsDeleted = true;
            db.SaveChanges();
        }
    }
}
