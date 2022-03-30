using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingJoke : MonoBehaviour
{
    public string[] jokes;

    private Text jokeText;

    // Start is called before the first frame update
    void Start()
    {
        jokeText = gameObject.GetComponent<Text>();
        GenerateJoke();
    }

    public void GenerateJoke()
    {
        int randnumber = Random.Range(0, jokes.Length);
        jokeText.text = jokes[randnumber];
    }
}
