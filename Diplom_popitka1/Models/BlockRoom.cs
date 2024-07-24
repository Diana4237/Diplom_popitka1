using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Diplom_popitka1.Models
{
    public partial class BlockRoom
    {
        public int IdBlock { get; set; }
        public int? IdChatroom { get; set; }
        public int? LokedByUserId { get; set; }
        public DateTime? LockStartTime { get; set; }
        public DateTime? LockEndTime { get; set; }

        public virtual ChatRoom IdChatroomNavigation { get; set; }
    }
}
