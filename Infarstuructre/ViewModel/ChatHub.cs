using Domin.Entity;
using Domin.Entity.SignalR;
using Infarstuructre.BL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Infarstuructre.ViewModel
{
	public class ChatHub : Hub
	{
        IIUserInformation iUserInformation;
        IIConnectAndDisconnect iConnectAndDisconnect;
        UserManager<ApplicationUser> _userManager;
        MasterDbcontext dbcontext;
        public ChatHub(UserManager<ApplicationUser> _userManager1, IIUserInformation iUserInformation1, MasterDbcontext dbcontext1, IIConnectAndDisconnect iConnectAndDisconnect1)
        {
            _userManager = _userManager1;
            iUserInformation = iUserInformation1;   
            dbcontext = dbcontext1;
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

                var userName = Context.User.Identity.Name;
                var profileImageUrl = GetProfileImageFromDatabase(userName);

                if (!string.IsNullOrEmpty(userName))
                {
                    var connect = new TBConnectAndDisConnect
                    {
                        ConnectId = Context.ConnectionId,
                        UserImg = profileImageUrl,
                        UserName = userName
                    };

                    iConnectAndDisconnect.addConnection(connect);
                }
                await Clients.All.SendAsync("UserConnected", userName, profileImageUrl);
                await base.OnConnectedAsync();
            }
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var connectId = Context.ConnectionId;
			var user = iConnectAndDisconnect.GetById(connectId);
			iConnectAndDisconnect.RemoveConnection(connectId);
			await Clients.All.SendAsync("UserDisconnected", user.UserName);
            await base.OnDisconnectedAsync(exception);
        }


        // Send and recive messages from and to clients with admin

        public async Task SendMessageToAdmin(string user, string message)
        {
            var currentUserName = Context.User.Identity.Name;
            var currentUserProfileImage = GetProfileImageFromDatabase(currentUserName);
        
			await Clients.Group("Admins").SendAsync("ReceiveMessage", currentUserName, message, currentUserProfileImage);
        }

        public async Task SendMessageToClient(string user1, string message, string userId, string reciver)
        {

            ViewmMODeElMASTER vmodel = new ViewmMODeElMASTER();
            var userd = vmodel.sUser = iUserInformation.GetById(userId);

            var user = await _userManager.FindByIdAsync(userId);
            //var user = await _userManager.GetUserAsync(User);
            //var user = await _userManager.GetUserAsync(User);

            //var currentUserName = Context.User.Identity.Name;
            var currentUserName = await _userManager.GetUserNameAsync(user);

            var currentUserProfileImage = GetProfileImageFromDatabase(currentUserName);


            await Clients.All.SendAsync("ReceiveMessage", currentUserName, message);
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

    public class UserConnection
    {
        public string ConnectionId { get; set; }
        public string UserName { get; set; }
        public string ProfileImageUrl { get; set; }
    }

}
