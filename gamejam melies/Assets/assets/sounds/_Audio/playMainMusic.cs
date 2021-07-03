using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playMainMusic : MonoBehaviour
{
    BgMusicScript BGMusic;
    private void Start()
    {
        BGMusic = GameObject.FindGameObjectWithTag("BGMusic").GetComponent<BgMusicScript>();
        BGMusic.ChangeAudioSnapshot();
    }

}
