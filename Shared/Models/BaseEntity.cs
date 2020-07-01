using System;

namespace Kolpi.Shared.Models
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
