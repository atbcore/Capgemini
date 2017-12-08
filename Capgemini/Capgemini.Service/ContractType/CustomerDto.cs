//-----------------------------------------------------------------------
// <copyright file="CustomerDto.cs" company="TB Enterprises">
//     Copyright (c) TB Enterprises. All rights reserved.
// </copyright>
// <author>Tomasz Bednarski</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Service.ContractType
{
    [DataContract]
    public class CustomerDto
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the customer's identity
        /// </summary>
        [DataMember]
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the customer's name
        /// </summary>
        [DataMember]
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the customer's surname
        /// </summary>
        [DataMember]
        public virtual string Surname { get; set; }

        /// <summary>
        /// Gets or sets the customer's telephone number
        /// </summary>
        [DataMember]
        public virtual string TelephoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the customer's address
        /// </summary>
        [DataMember]
        public virtual string Address { get; set; }

        #endregion Public Properties
    }
}
