using System;
using System.Collections.Generic;

namespace SelfHost.Model
{
    public static class UserCollectionExtension
    {
        public static void Remove(this List<User> users, User user, string collectionName)
        {
            users.Remove(user);
            Logger.Instance.WriteLog($"User - {user.Id} has been removed from {collectionName} {Environment.NewLine} {users.Count} are left");
        }

        public static void Add(this List<User> users, User user, string collectionName)
        {
            users.Add(user);
            Logger.Instance.WriteLog($"User - {user.Id} has been added to {collectionName} {Environment.NewLine} {users.Count} are left");
        }

        public static void AddIfNotExists(this List<User> users, User user)
        {
            if (users.Exists(c => c.Id == user.Id))
                return;

            users.Add(user);
        }
    }
}