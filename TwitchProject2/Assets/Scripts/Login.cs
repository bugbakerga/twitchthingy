using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public Text usernameText;
    public Text passwordText;
    public Text publicnameText;

    public string user;
    public string puser;
    public string pass;

    private bool loggedin;
    public GameObject enterbutton;
    public LoginInfo sendmanager;

    void Update()
    {
        if (loggedin == false)
        {
            if (usernameText.text == "" || passwordText.text == "" || publicnameText.text == "")
            {
                enterbutton.SetActive(false);
            }
            else
            {
                enterbutton.SetActive(true);
            }
        }
    }

    public void SubmitUser()
    {
        loggedin = true;
        user = usernameText.text;
        pass = passwordText.text;
        puser = publicnameText.text;
        sendacross();
    }

    public void sendacross()
    {
        sendmanager.username = user;
        sendmanager.displayname = puser;
        sendmanager.password = pass;
    }

    public void tmilink()
    {
        Application.OpenURL("https://twitchapps.com/tmi/");
    }

    public void playgame()
    {
        SceneManager.LoadScene(1);
    }
}
