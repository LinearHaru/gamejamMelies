using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamShake : MonoBehaviour
{
    CinemachineVirtualCamera virtualCamera;
    float shakeTimer;

    public static CamShake instance { get; private set; }
    void Awake()
    {
        instance = this;
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void CameraShake(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin channelPerlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        channelPerlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }

    private void Update()
    {
        if(shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
        }
        if(shakeTimer <= 0)
        {
            CinemachineBasicMultiChannelPerlin channelPerlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            channelPerlin.m_AmplitudeGain = 0f;
        }
    }
}
