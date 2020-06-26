using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private GameObject endLevelPanel;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;

        if (Instance != null)
            return;

        Instance = this;
        endLevelPanel.SetActive(false);
        DontDestroyOnLoad(gameObject);
    }

    public void FinishLevel()
    {
        endLevelPanel.SetActive(true);
    }

    public void ReloadLevel()
    {
        ScenesController.LoadScene(
            "Main",
            () => {
                endLevelPanel.SetActive(false);
            }
        );
    }
}
