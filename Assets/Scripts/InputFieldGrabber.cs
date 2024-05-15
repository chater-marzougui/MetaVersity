using TMPro;
using UnityEngine;
public class InputFieldGrabber : MonoBehaviour
{
private string inputText;
[SerializeField] private GameObject reactionGroup; 
[SerializeField] private TMP_Text reactionTextBox;
public void GrabFromInputField (string input)
{
inputText = input;
DisplayReactionToInput();
}
private void DisplayReactionToInput()
{
reactionTextBox.text = "Welcome to the team, " + inputText + "!";
reactionGroup.SetActive(true);
}

}