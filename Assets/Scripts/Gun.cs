using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent<int> OnAmmoChanged;
    public UnityEvent OnAmmoRefilled;
    public UnityEvent OnGunFired;

    // references
    [SerializeField] Transform gunBarrelEnd;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Animator anim;

    // stats
    [SerializeField] int maxAmmo;
    [SerializeField] float timeBetweenShots = 0.1f;

    // private variables
    int ammo;
    float elapsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        ammo = maxAmmo;
        if (OnAmmoChanged == null)
            OnAmmoChanged = new UnityEngine.Events.UnityEvent<int>();
        OnAmmoChanged.Invoke(ammo);

        if (OnAmmoRefilled == null)
            OnAmmoRefilled = new UnityEvent();

        if (OnGunFired == null)
            OnGunFired = new UnityEvent();
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
    }

    public bool AttemptFire()
    {
        if (ammo <= 0)
        {
            return false;
        }

        if(elapsed < timeBetweenShots)
        {
            return false;
        }

        Debug.Log("Bang");
        Instantiate(bulletPrefab, gunBarrelEnd.transform.position, gunBarrelEnd.rotation);
        anim.SetTrigger("shoot");
        timeBetweenShots = 0;
        ammo -= 1;

        OnAmmoChanged.Invoke(ammo);

        return true;
    }

    public void AddAmmo(int amount)
    {
        ammo += amount;

    }

    public void RefillAmmo()
    {
        ammo = maxAmmo;
        OnAmmoRefilled.Invoke();
        OnAmmoChanged.Invoke(ammo);
    }

    private void Fire()
    {
        OnGunFired.Invoke();
    }
}
