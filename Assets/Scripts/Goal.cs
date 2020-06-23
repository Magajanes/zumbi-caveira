using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private Coroutine finishLevelCoroutine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (finishLevelCoroutine != null)
            return;

        var player = collision.gameObject;
        finishLevelCoroutine = StartCoroutine(FinishLevel(player));
    }

    private IEnumerator FinishLevel(GameObject player)
    {
        yield return new WaitForSeconds(2);

        player.SetActive(false);
        GameManager.Instance.FinishLevel();
    }
}
