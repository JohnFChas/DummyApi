using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using DummyApi.Models.EntityModels;

namespace DummyApi.SignalRHubs
{
    public class ChatHub : Hub
    {
        public void BroadcastMessage(Message message)
        {
            Clients.All.recieveMessage(message);
        }
    }
}