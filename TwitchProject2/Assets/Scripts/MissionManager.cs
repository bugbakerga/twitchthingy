using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionManager : MonoBehaviour
{
    public RawImage display;
    public RawImage proggressdisplay;

    public Emote[] emote;
    public Slider bar;

    public float maxHype;
    public float hype;

    public Animator message;
    public Animator baranim;

    public int chatthreshhold;
    public float smoothspeed;
    public TextMeshProUGUI textDisplay;
    public int randomnumber;

    bool inMission;

    void Start()
    {
        StartCoroutine(missiondelay());
    }

    public void BeginMission()
    {
        missionContents();
    }

    public void AddHype()
    {
        if (hype + chatthreshhold <= maxHype)
        {
            hype += chatthreshhold;
        }
        else
        {
            hype = maxHype;
        }
    }

    void Update()
    {
        if (bar.value != hype)
        {
            bar.value = Mathf.Lerp(bar.value, hype, smoothspeed * Time.deltaTime);
        }
    }

    public void missionContents()
    {
        randomnumber = Random.Range(0, emote.Length);
        display.texture = emote[randomnumber].emoteImage;
        proggressdisplay.texture = emote[randomnumber].emoteImage;
        textDisplay.text = "Emote Mission: " + emote[randomnumber].emoteName;
        message.SetTrigger("mission");
        baranim.SetBool("isopen", true);
    }

    IEnumerator missiondelay ()
    {
        yield return new WaitForSeconds(9f);
        BeginMission();
    }
}
