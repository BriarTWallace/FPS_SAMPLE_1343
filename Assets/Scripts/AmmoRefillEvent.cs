using UnityEngine;
using UnityEngine.Events;

public class AmmoRefillEvent : MonoBehaviour
{
    public UnityEvent OnInteracted;

    private void Start()
    {
        if (OnInteracted == null)
            OnInteracted = new UnityEvent();

        Gun gun = FindAnyObjectByType<Gun>();
        if (gun != null)
        {
            OnInteracted.AddListener(gun.RefillAmmo);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerInteractionEvent player = other.GetComponent<PlayerInteractionEvent>();
        if (player != null)
        {
            player.OnInteractPressed.AddListener(HandleInteraction);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerInteractionEvent player = other.GetComponent<PlayerInteractionEvent>();
        if (player != null)
        {
            player.OnInteractPressed.RemoveListener(HandleInteraction);
        }
    }

    private void HandleInteraction()
    {
        OnInteracted.Invoke(); 
    }
}
