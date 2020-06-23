using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDetector : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!player.gameObject.activeInHierarchy)
            return;

        player.StopWalk();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!player.gameObject.activeInHierarchy)
            return;

        player.StartWalk();
    }
}
