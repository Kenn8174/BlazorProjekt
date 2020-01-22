using BlazorProjekt.Service.DataTransferObjects;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorProjekt.Web.Extensions
{
    public static class Extensions
    {
        public static OwnerDTO ConvertToOwnerDTO(this AuthenticationState user) {
            Claim jsonValue = user.User.Claims.Single(o => o.Type == ClaimTypes.Actor);
            object owner = JsonSerializer.Deserialize(jsonValue.Value, typeof(OwnerDTO));

            return (OwnerDTO)owner;
        }  
    }
}
