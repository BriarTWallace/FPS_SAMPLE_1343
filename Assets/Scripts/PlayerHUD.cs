using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] Image healthBar;
    [SerializeField] TMP_Text currentAmmoText;
    [SerializeField] TMP_Text maxAmmoText;
    [SerializeField] Image damageOverlay;
    [SerializeField] float flashDuration = 0.2f;



    FPSController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<FPSController>();
        if (player != null)
        {
            player.OnPlayerDamaged.AddListener(UpdateHealthBar);
            player.OnPlayerDamaged.AddListener(FlashDamageOverlay);

        }
    }

    void UpdateHealthBar(float normalizedHealth)
    {
        healthBar.fillAmount = normalizedHealth;
    }

    void FlashDamageOverlay(float damageAmount)
    {
        StartCoroutine(DamageFlashRoutine());
    }

    IEnumerator DamageFlashRoutine()
    {
        damageOverlay.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(flashDuration);
        damageOverlay.color = new Color(1, 0, 0, 0);
    }

    private void OnDestroy()
    {
        if (player != null)
        {
            player.OnPlayerDamaged.RemoveListener(UpdateHealthBar);
            player.OnPlayerDamaged.RemoveListener(FlashDamageOverlay);
        }
    }
}
