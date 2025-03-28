using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.Events;


public class ScreenShake : MonoBehaviour
{
    [SerializeField] CinemachineCamera vcam;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    [ContextMenu("Start Shake")]
    public void StartShake()
    {
        vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().AmplitudeGain = 1;
    }

    [ContextMenu("End Shake")]
    public void EndShake()
    {
        vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().AmplitudeGain = 0;
    }
}
