using SCB.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace SCB.Data.Entities
{
    public class Message : IEntity
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public virtual List<Invite> Invites { get; set; }
    }
}
