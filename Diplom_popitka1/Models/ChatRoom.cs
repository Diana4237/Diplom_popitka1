using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Diplom_popitka1.Models
{
    public partial class ChatRoom
    {
        public ChatRoom()
        {
            BlockRoom = new HashSet<BlockRoom>();
            ChatMessages = new HashSet<ChatMessages>();
        }

        public int IdChatroom { get; set; }
        public int? IdClient { get; set; }

        public virtual Clients IdClientNavigation { get; set; }
        public virtual ICollection<BlockRoom> BlockRoom { get; set; }
        public virtual ICollection<ChatMessages> ChatMessages { get; set; }
    }
}
