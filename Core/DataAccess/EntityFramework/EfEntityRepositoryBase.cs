using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity : class, IEntity,new()
        where TContext : DbContext,new()
    
    {
        public void Add(TEntity entity)
        {
            //using bittigi anda kaldirir
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); //referansi yakalama
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity); //referansi yakalama
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter) //burasi tek data getirecek
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()  //filtre null ise bu calisir
                    : context.Set<TEntity>().Where(filter).ToList(); //null degil filtre varsa burasi calisir
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity); //referansi yakalama
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
