using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingGraphics : MonoBehaviour
{
    public Texture2D[] loadgraphics;
    private RawImage loadui;

    void Start()
    {
        loadui = gameObject.GetComponent<RawImage>();
        randomgraphic();
    }

    public void randomgraphic ()
    {
        int randnumber = Random.Range(0, loadgraphics.Length);
        loadui.texture = loadgraphics[randnumber];
    }
}
