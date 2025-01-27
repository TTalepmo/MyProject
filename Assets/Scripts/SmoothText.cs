using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmoothText : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 6f;
    private string fullText;
    private string currentText = ""; 

    [SerializeField] private Text uiText;

    private void Start()
    {
        fullText = uiText.text;
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        foreach (char letter in fullText.ToCharArray())
        {
            currentText += letter;
            uiText.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
