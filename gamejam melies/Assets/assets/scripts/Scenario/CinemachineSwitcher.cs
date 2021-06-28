using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineSwitcher : MonoBehaviour
{
    private Animator anim;
    private bool isCam1 = true;

    public static CinemachineSwitcher instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        anim = GetComponent<Animator>(); 
    }


    public void SwitchCamera(string cameraName)
    {
        anim.Play(cameraName);
    }
}
