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
    public Prize[] prizes;
    public int amountofselectedPrizes = 0;

    public GameObject warning;
    public GameObject Loading;

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

    public void determineSelection()
    {
        for (int i = 0; i < prizes.Length; i++)
        {
            if (PlayerPrefs.GetInt(prizes[i].prefname) == 1)
            {
                amountofselectedPrizes += 1;
            }
        }

        PlayMatch();
    }

    public void PlayMatch()
    {
        if(amountofselectedPrizes > 0)
        {
            Loading.SetActive(true);
            SceneManager.LoadScene(sceneselected);
        }
        else
        {
            warning.SetActive(true);
        }
    }
}
