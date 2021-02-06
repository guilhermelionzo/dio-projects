using System;

namespace Domain.TvSeries.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
    }
}