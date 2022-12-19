using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelSelectManager : MonoBehaviour
{
    public Color buttonTint;
    public Image previousimage;
    public RawImage closeup;

    public Text desctext;

    public int sceneselected = 1;

    void Start()
    {
        previousimage.color = buttonTint;
    }

    public void Select(levelbutton info)
    {
        previousimage.color = Color.white;
        previousimage = info.bg;
        previousimage.color = buttonTint;
        sceneselected = info.scenenum;
        closeup.texture = info.mappreview;
        desctext.text = info.description;
    }

    public void PlayMatch()
    {
        SceneManager.LoadScene(sceneselected);
    }
}
