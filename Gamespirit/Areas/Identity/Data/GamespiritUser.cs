using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gamespirit.Data.DbModels;
using Microsoft.AspNetCore.Identity;

namespace Gamespirit.Areas.Identity.Data;

// Add profile data for application users by adding properties to the GamespiritUser class
public class GamespiritUser : IdentityUser<Guid>
{
	public string? StatusDescription { get; set; }
	public DateTime? JoinDate { get; set; }
	public string? ProfileImageUrl { get; set; }
	public ICollection<PlayerGameRequest>? Requests { get; set; }
	public ICollection<RentHistory>? RentHistory { get; set; }
	public ICollection<Wishlist>? Wishlists { get; set; }
}

