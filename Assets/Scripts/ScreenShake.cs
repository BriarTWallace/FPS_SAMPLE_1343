using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.Events;


public class ScreenShake : MonoBehaviour
{
    [SerializeField] CinemachineCamera vcam;

    void Start()
    {
        Gun gun = FindObjectOfType<Gun>();
        if (gun != null)
        {
            gun.OnGunFired.AddListener(StartShake);
        }
    }

    
    void Update()
    {
        
    }

    
    public void StartShake()
    {
        
        vcam.GetComponent<CinemachineBasicMultiChannelPerlin>().AmplitudeGain = 1;
        
        Invoke(nameof(EndShake), 0.1f);
    }

    
    public void EndShake()
    {
        vcam.GetComponent<CinemachineBasicMultiChannelPerlin>().AmplitudeGain = 0;
    }
}
