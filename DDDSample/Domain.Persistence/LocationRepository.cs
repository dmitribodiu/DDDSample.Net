using System;
using System.Collections.Generic;
using DDDSample.Domain.Location;
using NHibernate;

namespace DDDSample.Domain.Persistence
{
   /// <summary>
   /// Location repository implementation based on NHibernate.
   /// </summary>
   public class LocationRepository : AbstractRepository, ILocationRepository
   {
      public LocationRepository(ISessionFactory sessionFactory) : base(sessionFactory)
      {
      }

      public Location.Location Find(UnLocode locode)
      {
         const string query = @"from DDDSample.Domain.Location.Location l where l.UnLocode = :unLocode";
         return Session.CreateQuery(query).SetString("unLocode",locode.CodeString)
            .UniqueResult<Location.Location>();
      }

      public IEnumerable<Location.Location> FindAll()
      {
         const string query = @"from DDDSample.Domain.Location.Location l";
         return Session.CreateQuery(query).Enumerable<Location.Location>();
      }
   }
}