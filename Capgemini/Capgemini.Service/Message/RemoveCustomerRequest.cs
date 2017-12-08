//-----------------------------------------------------------------------
// <copyright file="RemoveCustomerRequest.cs" company="TB Enterprises">
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

using Capgemini.Service.ContractType;

namespace Capgemini.Service.Message
{
    [DataContract]
    public class RemoveCustomerRequest
    {
        #region Public Properties

        [DataMember]
        public CustomerDto CustomerDto { get; set; }

        #endregion // Public Properties
    }
}
