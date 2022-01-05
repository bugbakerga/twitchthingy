using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prizeNotis : MonoBehaviour
{
    public string nameofprize;

    // Start is called before the first frame update
    void Start()
    {
        NotiManager.instance.addAppearence(nameofprize);
    }
}
