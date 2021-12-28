using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fencelogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        randrot();
    }

    public void randrot()
    {
        int randomnum = Random.Range(0, 180);
        transform.Rotate(0, randomnum, 0);
    }
}
