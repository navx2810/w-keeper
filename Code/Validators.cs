using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Keeper.Code.Validators
{
    public static class User 
    {
        public static bool IsValidAccount(this Models.User user, ModelStateDictionary m)
        {
            bool valid = true;
            if(user.Name.IsEmpty()) { m.AddModelError("Name", "Name can not be empty."); valid = false; }
            if(user.Password.IsEmpty()) { m.AddModelError("Password", "Password can not be empty."); valid = false; }
            return valid;
        }
    }
}