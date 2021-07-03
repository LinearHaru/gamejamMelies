using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conectedLever : MonoBehaviour
{
    Elevator lever1;
    [SerializeField] Elevator lever2;

    private void Start()
    {
        lever1 = GetComponent<Elevator>();
    }
    public void updateLever()
    {
        lever2.flick();
    }
}
