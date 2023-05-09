using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //Generic constraint : generic kisitlama
    //class : referans tip olabilir
    //class, IEntity demek ; IEntity veya IEntity implemente eden bir nesne olabilir
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //degiskenden kayip yasamamak icin T degiskeni seklinde generic kullaniyoruz; product category veya baska bir sey olabilir 
        List<T> GetAll(Expression<Func<T,bool>> filter = null); //expresson: bir degeri uretmek icin kullanilan ifade, yapiyi kullanabilmemizi saglayan yapi
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        
    }
}
