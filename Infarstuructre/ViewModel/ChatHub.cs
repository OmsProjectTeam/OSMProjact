﻿using Domin.Entity;
using Domin.Entity.SignalR;
using Infarstuructre.BL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Infarstuructre.ViewModel
{
	public class ChatHub : Hub
	{
        IIUserInformation iUserInformation;
        IIMessageChat iMessageChat;
        IIConnectAndDisconnect iConnectAndDisconnect;
        UserManager<ApplicationUser> _userManager;
        MasterDbcontext dbcontext;
        public ChatHub(UserManager<ApplicationUser> _userManager1, IIUserInformation iUserInformation1, MasterDbcontext dbcontext1, IIConnectAndDisconnect iConnectAndDisconnect1, IIMessageChat iMessageChat1)
        {
            _userManager = _userManager1;
            iUserInformation = iUserInformation1;   
            dbcontext = dbcontext1;
            iMessageChat = iMessageChat1;
			iConnectAndDisconnect = iConnectAndDisconnect1;

		}

		private readonly IDictionary<string, string> _connectedUsers = new Dictionary<string, string>();

        // connection & Disconnection Logic
        public override async Task OnConnectedAsync()
        {
            var userId = Context.UserIdentifier;
            var user = await _userManager.FindByIdAsync(userId);

            if (user != null && await _userManager.IsInRoleAsync(user, "Admin"))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "Admins");
            }
            var profileImageUrl = GetProfileImageFromDatabase(user.ImageUser) ?? "No img";
            if (!string.IsNullOrEmpty(user.UserName))
            {
                var connect = new TBConnectAndDisConnect
                {
                    ConnectId = Context.ConnectionId,
                    UserImg = profileImageUrl,
                    UserName = user.UserName
                };

                iConnectAndDisconnect.addConnection(connect);
                await Clients.All.SendAsync("UserConnected", user.UserName, profileImageUrl);
            }
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var connectId = Context.ConnectionId;
			var user = iConnectAndDisconnect.GetById(connectId);
            iConnectAndDisconnect.RemoveConnection(connectId);
            await base.OnDisconnectedAsync(exception);
        }


        // Send and recive messages from and to clients with admin

        public async Task SendMessageToAdmin(string message, string to)
        {
            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            var userd = vmodel.sUser = iUserInformation.GetByName(to);
            var reciverId = userd.Id;
            var senderId = Context.UserIdentifier;

            var chatMsg = new TBMessageChat
            {
                Message = message,
                ReciverId = reciverId,
                SenderId = senderId
            };
            iMessageChat.saveData(chatMsg);

            var currentUserName = Context.User.Identity.Name;
            var currentUserProfileImage = GetProfileImageFromDatabase(currentUserName);
			await Clients.Group("Admins").SendAsync("ReceiveMessage", currentUserName, message, currentUserProfileImage, DateTime.Now.ToString("HH:mm"));
        }

        public async Task SendMessageToClients(string message, string to)
        {

            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            var userd = vmodel.sUser = iUserInformation.GetByName(to);
            var reciverId = userd.Id;
            var senderId = Context.UserIdentifier;

            var chatMsg = new TBMessageChat
            {
                Message = message,
                ReciverId = reciverId,
                SenderId = senderId
            };
            iMessageChat.saveData(chatMsg);

            var user = iConnectAndDisconnect.GetByName(to);
            if (user != null)
            {
                var currentUserName = Context.User.Identity.Name;
                var currentUserProfileImage = GetProfileImageFromDatabase(currentUserName);
                await Clients.All.SendAsync("ReceiveMessage", currentUserName, message, DateTime.Now.ToString("HH:mm"));
            }

        }


        //      // Send and recive messages from and to AirFreight with admin
        //      public async Task SendMessageToAdminFromAirFreightArea(string user, string message)
        //{
        //	await Clients.Group("Admin").SendAsync("ReceiveMessageFromAirFreight", user, message);
        //}

        //      public async Task SendMessageToAirFreight(string user, string message)
        //      {
        //          await Clients.Group("DeliveryCompanies").SendAsync("ReceiveMessage", user, message);
        //      }

        //      // Send and recive messages from and to AirFreight with admin
        //      public async Task SendMessageToAdminFromMerchantsArea(string user, string message)
        //{
        //	await Clients.Group("Admin").SendAsync("ReceiveMessageFromMerchant", user, message);
        //}

        //      public async Task SendMessageToMerchants(string user, string message)
        //      {
        //          await Clients.Group("ShippingCompanies").SendAsync("ReceiveMessage", user, message);
        //      }

        private string GetProfileImageFromDatabase(string userName)
        {
            var user = iUserInformation.GetAllByName(userName).FirstOrDefault();
            if (user != null)
            {
                var photo = $"{Helper.PathImageuser}/{user.ImageUser}";
                return photo;
            }

            return null;
        }

		private async Task<bool> CheckIfUserIsAdmin(string userId)
		{
            var user = await _userManager.FindByIdAsync(userId);
            if(user != null)
            {
                if(await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    return true;
                }
            }
            return false;
		}
	}
}
