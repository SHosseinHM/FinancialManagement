using System;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public partial class Diposite: BaseEntity
    {
        public Guid DipositId { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual User User { get; set; }
    }
}
