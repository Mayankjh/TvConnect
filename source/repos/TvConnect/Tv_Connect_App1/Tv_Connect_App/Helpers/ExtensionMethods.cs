﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tv_Connect_App.Entities;

namespace Tv_Connect_App.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<User> WithoutPasswords(this IEnumerable<User> users)
        {
            if (users == null) return null;

            return users.Select(x => x.WithoutPassword());
        }

        public static User WithoutPassword(this User user)
        {
            if (user == null) return null;

            user.PasswordHash = null;
            return user;
        }
    }
}
