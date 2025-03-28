using UnityEngine;
using UnityEngine.Events;

public class GunAmmoEvent : MonoBehaviour
{
    public UnityEvent<int> OnAmmoChanged = new UnityEvent<int>();

    private Gun gun;

    void Start()
    {
        gun = GetComponent<Gun>();
        if (gun != null)
        {
            gun.OnAmmoChanged.AddListener(HandleAmmoChanged);
        }
    }

    void OnDestroy()
    {
        if (gun != null)
        {
            gun.OnAmmoChanged.RemoveListener(HandleAmmoChanged);
        }
    }

    private void HandleAmmoChanged(int currentAmmo)
    {
        OnAmmoChanged.Invoke(currentAmmo); // Broadcast ammo changes
    }
}

