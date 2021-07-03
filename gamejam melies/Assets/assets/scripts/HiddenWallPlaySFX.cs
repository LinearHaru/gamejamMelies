using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenWallPlaySFX : MonoBehaviour
{
    [SerializeField] SfxManager SFXManager;
    bool played = false;
    private void Start()
    {
        if(SFXManager==null)
            SFXManager = GameObject.FindGameObjectWithTag("SFXManager").GetComponent<SfxManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!played)
        {
            SFXManager.PlaySfx(5);
            played=true;
        }
    }

}
