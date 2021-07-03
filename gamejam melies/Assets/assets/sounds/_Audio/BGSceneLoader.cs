using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSceneLoader : MonoBehaviour
{
    BgMusicScript BGMusic;
    private void Start()
    {
        BGMusic = GameObject.FindGameObjectWithTag("BGMusic").GetComponent<BgMusicScript>();
        BGMusic.ChangeAudioSnapshot();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
