using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginInfo : MonoBehaviour
{
    public static LoginInfo instance;

    private void Awake()
    {
        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public string username;
    public string displayname;
    public string password;
}
