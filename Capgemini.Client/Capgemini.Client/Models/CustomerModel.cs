//-----------------------------------------------------------------------
// <copyright file="CustomerModel.cs" company="TB Enterprises">
//     Copyright (c) TB Enterprises. All rights reserved.
// </copyright>
// <author>Tomasz Bednarski</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Client.Models
{
    public class CustomerModel
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the customer's identity
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the customer's name
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the customer's surname
        /// </summary>
        public virtual string Surname { get; set; }

        /// <summary>
        /// Gets or sets the customer's telephone number
        /// </summary>
        public virtual string TelephoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the customer's address
        /// </summary>
        public virtual string Address { get; set; }

        #endregion // Public Properties
    }
}
