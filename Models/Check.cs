namespace Airbnb.Models
{
    public static class Check
    {
        public static string OwnerExists(AirBnbContext ctx, string userId)
        {
            string msg = string.Empty;

            if (!string.IsNullOrWhiteSpace(userId) && int.TryParse(userId, out int id))
            {
                var user = ctx.User
                    .FirstOrDefault(u => u.UserId == id);

                if (user == null)
                {
                    msg = $"User with ID {userId} does not exist.";
                }
                else if (user.UserType.ToLower() != "owner")
                {
                    msg = $"{user.Name} is not registered as an Owner.";
                }
            }
            else
            {
                msg = "Invalid Owner ID format.";
            }

            return msg;
        }

    }
}