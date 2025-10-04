using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StinkyCheeseTouch : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindAnyObjectByType<PlayerHealth>().TakeDamage(30);
            Destroy(gameObject);
        }
    }
}
