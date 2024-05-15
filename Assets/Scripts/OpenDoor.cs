using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class OpenDoor: MonoBehaviour
{
    private Animator anim;
    private bool IsAtDoor = false;
    private string CodeTextValue = "";
    public string password = "arduuuuino";
    public GameObject CodePanel;
    [SerializeField] private TextMeshProUGUI CodeText;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        //CodeText.text = CodeTextValue;
        if(CodeTextValue == password)
        {
            anim.SetTrigger("OpenDoor");
            CodePanel.SetActive(false);
        }
        if (CodeTextValue.Length > password.Length){CodeTextValue = "";}
        if (Input.GetKey(KeyCode.E) && IsAtDoor == true)
        {
            CodePanel.SetActive(true);
        }
    }
private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"){
            IsAtDoor = true;
        }
    }
private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player"){
            IsAtDoor = false;
            CodePanel.SetActive(false);
        }
    }
public void AddDigit(string digit)
    {
        CodeTextValue += digit;
    }
}
