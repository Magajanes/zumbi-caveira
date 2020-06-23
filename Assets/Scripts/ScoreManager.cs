using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private int brainCount;

    [SerializeField]
    private TextMeshProUGUI brainCounter;

    private int BrainCount
    {
        get => brainCount;

        set
        {
            brainCount = value;
            brainCounter.text = brainCount.ToString();
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    public void AddBrain()
    {
        BrainCount++;
    }
}
