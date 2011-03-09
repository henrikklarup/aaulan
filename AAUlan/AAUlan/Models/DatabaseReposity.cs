﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AAUlan.Models;

namespace AAUlan.Models
{
    public class DatabaseReposity
    {
        AAULANHOMEPAGEEntities aauEnt = new AAULANHOMEPAGEEntities();


        #region GetCurrentEvent
        public Event GetCurrentEvent()
        {

        }
        #endregion


        #region AddOrder
        public bool AddOrder(Mad mad)
        {
            //Find last id
            Mad idmad = aauEnt.Mad.Where(s => s.ID > 0).OrderByDescending(s => s.ID).FirstOrDefault();
            if (idmad == null)
            {
                mad.ID = 1;
            }
            else
            {
                mad.ID = idmad.ID;
                mad.ID++;
            }

            aauEnt.AddToMad(mad);
            Save();
            return true;
        }
        #endregion

        #region AddLan
        public bool AddLan(LAN lan)
        {
            //Find last id
            LAN idlan = aauEnt.LAN.Where(s => s.ID > 0).OrderByDescending(s => s.ID).FirstOrDefault();
            if (idlan == null)
            {
                lan.ID = 1;
            }
            else
            {
                lan.ID = idlan.ID;
                lan.ID++;
            }

            aauEnt.AddToLAN(lan);
            Save();
            return true;
        }
        #endregion

        #region AddEvent
        public bool AddEvent(Event event1)
        {
            //Find last id
            Event idevent = aauEnt.Event.Where(s => s.ID > 0).OrderByDescending(s => s.ID).FirstOrDefault();
            if (idevent == null)
            {
                event1.ID = 1;
            }
            else
            {
                event1.ID = idevent.ID;
                event1.ID++;
            }

            aauEnt.AddToEvent(event1);
            Save();
            return true;
        }
        #endregion

        #region AddUser
        /// <summary>
        /// Add user to the database
        /// </summary>
        /// <param name="user">User wich will be added</param>
        public void AddUser(User user)
        {
            //Add user
            aauEnt.AddToUser(user);

            //Save database
            Save();
        }
        #endregion

        #region User
        #region GetAllUsers
        /// <summary>
        /// Get all users from database
        /// </summary>
        /// <returns>All users</returns>
        public IQueryable<User> GetAllUsers()
        {
            return aauEnt.User;
        }
        #endregion
        #endregion

        #region User Validation
        #region GetUserRoleFromUsername
        /// <summary>
        /// Get the userrole from the username
        /// </summary>
        /// <param name="Username">Username of user</param>
        /// <returns>User role of user</returns>
        public string GetUserRoleFromUsername(string Username)
        {
            return aauEnt.User.FirstOrDefault(d => d.Username == Username).Role;
        }
        #endregion

        #region GetUserFromUsername
        public User GetUserFromUsername(string Username)
        {
            return aauEnt.User.FirstOrDefault(d => d.Username == Username);
        }
        #endregion

        #region Promote
        public void Promote(string Username)
        {
            User user = GetUserFromUsername(Username);
            if (user.Role.Trim() == "Crew")
            {
                user.Role = "Moderator";
            }
            else if (user.Role.Trim() == "Moderator")
            {
                user.Role = "Administrator";
            }
            Save();
        }
        #endregion

        #region Demote
        public void Demote(string Username)
        {
            User user = GetUserFromUsername(Username);
            if (user.Role.Trim() == "Administrator")
            {
                user.Role = "Moderator";
            }
            else if (user.Role.Trim() == "Crew")
            {
                user.Role = "User";
            }
            Save();
        }
        #endregion

        #region ValidateUser
        /// <summary>
        /// Validate the user with the database
        /// </summary>
        /// <param name="Username">Username</param>
        /// <param name="Password">Encrypted password</param>
        /// <returns>State of user. True if valid</returns>
        public bool ValidateUser(string Username, string Password)
        {
            //Declare user to validate
            User validateUser = aauEnt.User.FirstOrDefault(d => d.Username == Username);

            //Validate Username
            if (validateUser == null)
            {
                return false;
            }

            //Validate passwords and return
            if (Password.Trim() == validateUser.Password.Trim())
                return true;
            else
                return false;
        }
        #endregion

        #region GetUsersByUsername
        /// <summary>
        /// Get all the users matching the username search text
        /// </summary>
        /// <param name="username">Username to search for</param>
        /// <returns>Matching Users</returns>
        public IQueryable<User> GetUsersByUsername(string username)
        {
            return from e in GetAllUsers()
                   where e.Username.ToLower().Contains(username.ToLower())
                   select e;
        }
        #endregion
        #endregion

        #region Save
        public void Save()
        {
            aauEnt.SaveChanges();
        }
        #endregion

    }
}