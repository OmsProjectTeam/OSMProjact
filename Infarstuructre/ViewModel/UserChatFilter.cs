using Infarstuructre.BL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infarstuructre.ViewModel
{
    public class UserChatFilter : IAsyncActionFilter
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IIMessageChat _iMessageChat;

        public UserChatFilter(UserManager<ApplicationUser> userManager, IIMessageChat iMessageChat)
        {
            _userManager = userManager;
            _iMessageChat = iMessageChat;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var user = await _userManager.GetUserAsync(context.HttpContext.User);
            if (user != null)
            {
                var controller = context.Controller as Controller;
                if (controller != null)
                {
                    controller.ViewData["ViewChatMessage"] = _iMessageChat.GetByReciverId(user.Id);
                }
            }

            await next();
        }
    }
}
