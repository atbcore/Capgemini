//-----------------------------------------------------------------------
// <copyright file="NHibernateHelper.cs" company="TB Enterprises">
//     Copyright (c) TB Enterprises. All rights reserved.
// </copyright>
// <author>Tomasz Bednarski</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NHibernate;
using NHibernate.Cfg;

using Capgemini.Domain;

namespace Capgemini.Repository
{
    public sealed class NHibernateHelper
    {
        private static ISessionFactory sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (sessionFactory != null) return sessionFactory;

                var configuration = new Configuration();
                configuration.Configure();
                configuration.AddAssembly(typeof(Capgemini.Domain.Customer).Assembly);
                sessionFactory = configuration.BuildSessionFactory();

                return sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        public static void CloseSessionFactory()
        {
            if (sessionFactory != null)
            {
                sessionFactory.Close();
            }
        }
    }
}
