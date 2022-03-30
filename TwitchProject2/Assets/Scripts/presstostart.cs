using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class presstostart : MonoBehaviour
{
    public GameObject blur;
    public GameObject loginmenu;
    public GameObject dashboard;

    #region Singleton

    public static presstostart instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            blur.SetActive(true);
            loginmenu.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void StraighttoDash()
    {
        blur.SetActive(true);
        loginmenu.SetActive(true);
        gameObject.SetActive(false);

    }
}
