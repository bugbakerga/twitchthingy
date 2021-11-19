using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class presstostart : MonoBehaviour
{
    public GameObject blur;
    public GameObject loginmenu;

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
}
