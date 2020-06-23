using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private bool loading = false;

    public void StartGame()
    {
        ScenesController.LoadScene("Main");
    }
}
