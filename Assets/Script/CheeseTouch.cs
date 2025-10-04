using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseTouch : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindAnyObjectByType<ScoreManager>().AddScore(10);
            Destroy(gameObject);
        }
    }
}
