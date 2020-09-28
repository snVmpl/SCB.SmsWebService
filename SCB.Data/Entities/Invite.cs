using SCB.Data.Interfaces;
using System;

namespace SCB.Data.Entities
{
    public class Invite : IEntity
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public string PhoneNumber { get; set; }

        public int ApiId { get; set; }

        public virtual Message Message { get; set; }
    }
}
