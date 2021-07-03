using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableCam : MonoBehaviour
{
    [SerializeField] private string camToChange,camToChangeOnExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CinemachineSwitcher.instance.SwitchCamera(camToChange);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CinemachineSwitcher.instance.SwitchCamera(camToChangeOnExit);
        }
    }
}
