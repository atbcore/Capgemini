//-----------------------------------------------------------------------
// <copyright file="CapgeminiProfile.cs" company="TB Enterprises">
//     Copyright (c) TB Enterprises. All rights reserved.
// </copyright>
// <author>Tomasz Bednarski</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Capgemini.Domain;
using Capgemini.Service.ContractType;

namespace Capgemini.Service.Mapper
{
    public class CapgeminiProfile : Profile
    {
        #region Constructors

        public CapgeminiProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<IEnumerable<Customer>, IEnumerable<CustomerDto>>();
        }

        #endregion // Constructors
    }
}
