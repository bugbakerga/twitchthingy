using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabdestroy : MonoBehaviour
{
    public float destroyTime;

    void Awake()
    {
        Destroy(gameObject, destroyTime);
    }
}
