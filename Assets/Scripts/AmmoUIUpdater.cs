using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoUIUpdater : MonoBehaviour
{
    [SerializeField] private GunAmmoEvent gunAmmoEvent;
    [SerializeField] private TMP_Text currentAmmoText;

    void Start()
    {
        if (gunAmmoEvent != null)
        {
            gunAmmoEvent.OnAmmoChanged.AddListener(UpdateAmmoUI);
        }
    }

    void OnDestroy()
    {
        if (gunAmmoEvent != null)
        {
            gunAmmoEvent.OnAmmoChanged.RemoveListener(UpdateAmmoUI);
        }
    }

    private void UpdateAmmoUI(int currentAmmo)
    {
        if (currentAmmoText != null)
        {
            currentAmmoText.text = currentAmmo.ToString();
        }
    }
}
