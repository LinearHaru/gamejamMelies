using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamOnRotate : MonoBehaviour
{

    bool isInRange;
    public float intensity;
    public float timer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            isInRange = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            isInRange = false;
    }

    private void Update()
    {
        if(isInRange && Input.GetButtonDown("Use"))
        {
            CamShake.instance.CameraShake(intensity, timer);
        }
    }
}
