using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.IService;
using ZSZ.Service.Entities;

namespace ZSZ.Service
{
    public class CityService : ICityService
    {
        /// <summary>
        /// 新建city城市名字
        /// </summary>
        /// <param name="name"></param>
        /// <returns>新建城市ID</returns>
        public long Add(string name)
        {
            using (MyDbContext db = new MyDbContext())
            {
                BaseService<CityEntity> bs = new BaseService<CityEntity>(db);
                bool exists = bs.GetAll().Any(e => e.Name == name);//判断是否已存在
                if (exists)
                {
                    throw new ArgumentException("城市已存在");
                }
                CityEntity city = new CityEntity();
                city.Name = name;
                db.Cities.Add(city);
                db.SaveChanges();
                return city.Id;
            }
        }
    }
}
