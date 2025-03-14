﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Diplom_popitka1.Models
{
    public partial class Clients
    {
        public Clients()
        {
            ChatRoom = new HashSet<ChatRoom>();
            MotorcyclesToClient = new HashSet<MotorcyclesToClient>();
            Reviews = new HashSet<Reviews>();
        }

        public int IdClient { get; set; }
        public string Fullname { get; set; }
        public string Telephone { get; set; }

        public virtual ICollection<ChatRoom> ChatRoom { get; set; }
        public virtual ICollection<MotorcyclesToClient> MotorcyclesToClient { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }
    }
}
