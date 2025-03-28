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
        vcam.GetComponent<CinemachineBasicMultiChannelPerlin>().AmplitudeGain = 1;
    }

    [ContextMenu("End Shake")]
    public void EndShake()
    {
        vcam.GetComponent<CinemachineBasicMultiChannelPerlin>().AmplitudeGain = 0;
    }
}
