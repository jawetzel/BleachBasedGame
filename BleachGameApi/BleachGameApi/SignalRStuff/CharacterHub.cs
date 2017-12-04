using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreServices.AccountServices;
using MapsAndModels;
using MapsAndModels.ViewModels;
using Microsoft.AspNetCore.SignalR;

namespace BleachGameApi.SignalRStuff
{
    public class CharacterHub : Hub
    {
        private readonly UserService _userService;
        private readonly AccountSerurityService _accountSerurityService;
        public CharacterHub(UserService userService, AccountSerurityService accountSerurityService)
        {
            _userService = userService;
            _accountSerurityService = accountSerurityService;
        }

        public Task Send(CharacterModel model)
        {
            //var connectionId = Context.ConnectionId;
            if (model.PositionX == 0M || model.PositionY == 0M || model.PositionZ == 0M || model.FacingDirection == 0)
            {
                Clients.User("userid").InvokeAsync("Send", "success = false");
            };
            //_userService.UpdateCharacterPosition(model, connectionId);

            //Send Response to Indivijual
            //return Clients.User("userid").InvokeAsync("Send", message);

            // Send Response To Group
            //return Clients.Group("group1").InvokeAsync("Send", message);

            //Send Response To All
            return Clients.All.InvokeAsync("Send", model);
        }

        public override Task OnConnectedAsync()
        {
            //var connectionId = Context.ConnectionId;

            //pull value off queery string ?Token=[string]
            //var token = Context.Connection.GetHttpContext().Request.Query["Token"][0];

            ////if (_accountSerurityService.CheckToken(token) == null)
            //{
           ///     Context.Connection.Abort();
            //    return base.OnConnectedAsync();
            //}

            //_userService.AssignConnectionId(token, connectionId);

            // on connection update user for connection id
            //this.Groups.AddAsync(this.Context.ConnectionId, "group1");
            return base.OnConnectedAsync();

        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            //var connectionId = Context.ConnectionId;
            //_userService.UnassignConnectionId(connectionId);
            // on connection updare user online status and connection id
            return base.OnDisconnectedAsync(exception);
        }
    }
}
