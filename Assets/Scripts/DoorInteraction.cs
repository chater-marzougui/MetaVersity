using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public GameObject passwordPanel;
    private bool isNearDoor = false;
    private bool isDoorOpen = false;

    void Update()
    {
        if (isNearDoor && Input.GetKeyDown(KeyCode.E))
        {
            passwordPanel.SetActive(true);
            // Disable player movement here if necessary
        }
    }

    public void OpenDoor(string password)
    {
        if (password == "YourPassword") // Replace with your password
        {
            if (!isDoorOpen)
            {
                transform.Rotate(0, 90, 0); // Rotates the door
                isDoorOpen = true;
            }
            passwordPanel.SetActive(false);
            // Enable player movement here if previously disabled
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure your player has the tag "Player"
        {
            isNearDoor = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNearDoor = false;
            passwordPanel.SetActive(false);
        }
    }
}