using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    public Animator doorAnimator; // Reference to the door's Animator
    public TMP_InputField inputField; // Reference to the InputField
    public GameObject CodePanel;

    void Start()
    {
        // Find the InputField component in the scene
        //inputField = FindObjectOfType<InputField>();

        // Add a listener to the InputField to detect when the value changes
        inputField.onValueChanged.AddListener(CheckInputAndOpenDoor);
    }

    private void CheckInputAndOpenDoor(string input)
    {
        // Use inputField.text to get the text inside the InputField
        if (inputField.text.ToLower() == "arduino")
        {
            // Trigger the door opening animation
            doorAnimator.SetTrigger("OpenDoor");
            CodePanel.SetActive(false);

        }
    }

    void OnDestroy()
    {
        // Remove the listener to avoid memory leaks
        if (inputField != null)
    {
        inputField.onValueChanged.RemoveListener(CheckInputAndOpenDoor);
    }
    }
}
