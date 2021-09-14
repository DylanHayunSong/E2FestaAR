using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataManager : SingletonBehavior<UserDataManager>
{
    private UserData userData = new UserData();

    public void SetUserData (string n, string c, string contact, string m)
    {
        userData.userName = n;
        userData.company = c;
        userData.contact = contact;
        userData.message = m;


        if (EventManager.inst.OnUserDataUpdated != null)
        {
            EventManager.inst.OnUserDataUpdated.Invoke(userData);
        }
    }

    public UserData GetUserData ()
    {
        return userData;
    }

    public struct UserData
    {
        public string userName;
        public string company;
        public string contact;
        public string message;
    }
}
