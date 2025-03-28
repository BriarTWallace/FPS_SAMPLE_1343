using UnityEngine;
using UnityEngine.Events;

public class PlayerInteractionEvent : MonoBehaviour
{
    public UnityEvent OnInteractPressed = new UnityEvent();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnInteractPressed.Invoke(); // Notify all listeners
        }
    }
}
