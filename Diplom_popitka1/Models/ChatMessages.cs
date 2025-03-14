﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Diplom_popitka1.Models
{
    public partial class ChatMessages
    {
        public int IdMess { get; set; }
        public int? SenderId { get; set; }
        public int? IdChatroom { get; set; }
        public string TextMessage { get; set; }
        public DateTime? Timestampp { get; set; }
        public string Status { get; set; }
        public int? IdRole { get; set; }

        public virtual ChatRoom IdChatroomNavigation { get; set; }
        public virtual Roles IdRoleNavigation { get; set; }
    }
}
