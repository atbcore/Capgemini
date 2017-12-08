//-----------------------------------------------------------------------
// <copyright file="ICustomerRepository.cs" company="TB Enterprises">
//     Copyright (c) TB Enterprises. All rights reserved.
// </copyright>
// <author>Tomasz Bednarski</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Domain.Repository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        #region Methods

        /// <summary>
        /// Gets customers by name
        /// </summary>
        /// <param name="name">Customer name</param>
        /// <returns>Customers collection</returns>
        IEnumerable<Customer> GetByName(string name);

        /// <summary>
        /// Gets customers by name
        /// </summary>
        /// <param name="surname">Customer surname</param>
        /// <returns>Customers collection</returns>
        IEnumerable<Customer> GetBySurname(string surname);

        #endregion // Methods
    }
}
