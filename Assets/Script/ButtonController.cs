using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonController : MonoBehaviour
{
    public void ReturnToNewGame()
    {
        SceneManager.LoadScene("Loading");
    }

    public void Refresh()
    {

    }
}
