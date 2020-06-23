using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ScenesController
{
    private static bool loading = false;

    public static void LoadScene(string sceneName)
    {
        if (loading)
            return;

        loading = true;

        var loadSceneOperation = SceneManager.LoadSceneAsync("Main");

        loadSceneOperation.completed += (operation) =>
        {
            loading = false;
        };
    }

    public static void LoadScene(string sceneName, Action action)
    {
        if (loading)
            return;

        loading = true;

        var loadSceneOperation = SceneManager.LoadSceneAsync("Main");

        loadSceneOperation.completed += (operation) =>
        {
            loading = false;
            action.Invoke();
        };
    }

}
