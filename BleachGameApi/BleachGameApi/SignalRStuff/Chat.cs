using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapsAndModels;
using Microsoft.AspNetCore.SignalR;

namespace BleachGameApi.SignalRStuff
{
    public class Chat : Hub
    {
        public Task Send(HubInputModel message)
        {
            //Send Response to Indivijual
            //return Clients.User("userid").InvokeAsync("Send", message);

            // Send Response To Group
            //return Clients.Group("group1").InvokeAsync("Send", message);

            //Send Response To All
            return Clients.All.InvokeAsync("Send", message);
        }

        public override Task OnConnectedAsync()
        {
            // on connection update user for connection id
            this.Groups.AddAsync(this.Context.ConnectionId, "group1");

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            // on connection updare user online status and connection id
            return base.OnDisconnectedAsync(exception);
        }
    }
}
