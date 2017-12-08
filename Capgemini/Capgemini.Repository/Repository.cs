//-----------------------------------------------------------------------
// <copyright file="Repository.cs" company="TB Enterprises">
//     Copyright (c) TB Enterprises. All rights reserved.
// </copyright>
// <author>Tomasz Bednarski</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using NHibernate.Linq;

using Capgemini.Domain.Repository;

namespace Capgemini.Repository
{
    public abstract class Repository<T> : IRepository<T> where T: class
    {
        #region Public Methods

        public virtual T Add(T t)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(t);
                    transaction.Commit();

                    return t;
                }
            }
        }

        public virtual void Update(T t)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(t);
                    transaction.Commit();
                }
            }
        }

        public virtual void Delete(T t)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(t);
                    transaction.Commit();
                }
            }
        }

        public virtual T GetById(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Get<T>(id);
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<T>();
            }
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<T>().Where(expression);
            }
        }

        #endregion // Public Methods
    }
}
