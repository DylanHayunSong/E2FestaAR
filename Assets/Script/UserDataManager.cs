using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataManager : SingletonBehavior<UserDataManager>
{
    private static UserData userData = new UserData();

    public static void SetUserData (string n, string c, string m, string phoneF, string phoneM, string phoneE)
    {
        userData.userName = n;
        userData.company = c;
        userData.message = m;
        userData.phoneFirst = phoneF;
        userData.phoneMiddle = phoneM;
        userData.phoneEnd = phoneE;
    }

    public static UserData GetUserData ()
    {
        return userData;
    }

    public struct UserData
    {
        public string userName;
        public string company;
        public string message;
        public string phoneFirst;
        public string phoneMiddle;
        public string phoneEnd;
    }
}
