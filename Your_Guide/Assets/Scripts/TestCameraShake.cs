using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TestCameraShake : MonoBehaviour
{
    [SerializeField]CinemachineVirtualCamera cam;
    [SerializeField] float timeToShake;
    [SerializeField] string key;
    [SerializeField] float shakeAmplitude;

    bool onShake;
    // Start is called before the first frame update
    void Start()
    {
        onShake = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key) && !onShake)
        {
            StartCoroutine(CameraShake());
        }
    }

    IEnumerator CameraShake()
    {
        onShake = true;
        CinemachineBasicMultiChannelPerlin camPerlin = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        camPerlin.m_AmplitudeGain = shakeAmplitude;

        yield return new WaitForSeconds(timeToShake);

        camPerlin.m_AmplitudeGain = 0;
        onShake = false;
    }
}
