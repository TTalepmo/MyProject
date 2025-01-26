using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    [SerializeField] private GameObject scene1;
    [SerializeField] private Text uiText;
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject button3;

    [SerializeField] private GameObject scene2;


    [SerializeField] private float typingSpeed = 0.05f;
    private string currentText = "";
    private string fullText;

    public void Text1_Text2()
    {
        button1.SetActive(false);
        button2.SetActive(true);
        currentText = "";
        fullText = "¬ тот вечер, когда столица находилась под осадой, королевска€ семь€ была почти полночтью уничтожена,\n" +
            "за исключением наследника, который был похищен";
        StartCoroutine(TypeText());
    }

    public void Text2_Text3()
    {
        button2.SetActive(false);
        button3.SetActive(true);
        currentText = "";
        fullText = "Ётот наследник - ¬ы";
        StartCoroutine(TypeText());
    }

    public void Scene1_Scene2()
    {
        scene1.SetActive(false);
        scene2.SetActive(true);
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
