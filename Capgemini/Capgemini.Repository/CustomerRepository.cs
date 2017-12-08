//-----------------------------------------------------------------------
// <copyright file="CustomerRepository.cs" company="TB Enterprises">
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

using NHibernate;
using NHibernate.Linq;

using Capgemini.Domain;
using Capgemini.Domain.Repository;

namespace Capgemini.Repository
{
    /// <summary>
    /// Class represents the customer repository
    /// </summary>
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        #region ICustomerRepository Implementation

        /// <summary>
        /// Gets customers by name
        /// </summary>
        /// <param name="name">Customer name</param>
        /// <returns>Customers collection</returns>
        public IEnumerable<Customer> GetByName(string name)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Customer>().Where(x => x.Name == name);
            }
        }

        /// <summary>
        /// Gets customers by name
        /// </summary>
        /// <param name="surname">Customer surname</param>
        /// <returns>Customers collection</returns>
        public IEnumerable<Customer> GetBySurname(string surname)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Customer>().Where(x => x.Name == surname);
            }
        }

        #endregion // ICustomerRepository Implementation
    }
}
