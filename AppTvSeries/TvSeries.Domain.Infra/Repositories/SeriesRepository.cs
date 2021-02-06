using System;
using System.Collections.Generic;
using System.Linq;
using TvSeries.Domain.Entities;
using TvSeries.Domain.Repositories;

namespace TvSeries.Domain.Infra.Repositories
{
    public class SeriesRepository : IRepository<Series>
    {
        private IList<Series> series = new List<Series>();

        public void Delete(Series entity)
        {
            series.Remove(entity);
        }

        public Series GetById(Guid id)
        {
            return series.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Insert(Series entity)
        {
            series.Add(entity);
        }

        public IList<Series> List()
        {
            return series;
        }
        
        public void Update(Series entity)
        {
            series.Remove(entity);
            series.Add(entity);
        }
    }
}