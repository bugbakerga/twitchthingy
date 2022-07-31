using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinnerText : MonoBehaviour
{
    public TextMeshProUGUI overhead;
    public TextMeshProUGUI huddisplay;

    public GameObject copied;
    public Transform copiedposition;


    // Start is called before the first frame update
    void Start()
    {
        overhead.text = WinnerInfo.instance.winnername;
        huddisplay.text = "Winner!: " + WinnerInfo.instance.winnername;
    }

    public void CopyWinner()
    {
        Instantiate(copied, copiedposition).GetComponent<AudioSource>().Play();
        TextEditor textEditor = new TextEditor();
        textEditor.text = WinnerInfo.instance.winnername;
        textEditor.SelectAll();
        textEditor.Copy();
    }
}
