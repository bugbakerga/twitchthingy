using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menureturn : MonoBehaviour
{
    public void backtomenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
