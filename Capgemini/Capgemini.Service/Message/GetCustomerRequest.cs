﻿//-----------------------------------------------------------------------
// <copyright file="GetCustomersRequest.cs" company="TB Enterprises">
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

namespace Capgemini.Service.Message
{
    [DataContract]
    public class GetCustomerRequest
    {
        #region Public Properties

        [DataMember]
        public int CustomerId { get; set; }

        #endregion // Public Properties
    }
}
