using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreManager.Instance.AddBrain();
        Destroy(gameObject);
    }
}
