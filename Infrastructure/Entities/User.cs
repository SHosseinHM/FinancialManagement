using System;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public partial class User : BaseEntity
    {
        public User()
        {
            Diposites = new HashSet<Diposite>();
            Withdrows = new HashSet<Withdrow>();
        }

        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<Diposite> Diposites { get; set; }
        public virtual ICollection<Withdrow> Withdrows { get; set; }
    }
}
