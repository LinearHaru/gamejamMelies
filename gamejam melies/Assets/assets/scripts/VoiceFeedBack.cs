using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceFeedBack : MonoBehaviour
{
    public GameObject feedBack;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        { 
            if (Voice.canVoice)
            {
                feedBack.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            feedBack.SetActive(false);
        }
    }
}
