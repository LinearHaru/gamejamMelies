using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fakeWall : MonoBehaviour
{
    [SerializeField]private GameObject spriteMask;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteMask.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteMask.SetActive(false);
        }
    }
}
