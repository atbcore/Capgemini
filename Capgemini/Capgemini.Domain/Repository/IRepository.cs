//-----------------------------------------------------------------------
// <copyright file="ICustomerRepository.cs" company="TB Enterprises">
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

namespace Capgemini.Domain.Repository
{
    public interface IRepository<T> where T : class
    {
        #region Methods

        T Add(T t);
        void Update(T t);
        void Delete(T t);
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);

        #endregion // Methods
    }
}
