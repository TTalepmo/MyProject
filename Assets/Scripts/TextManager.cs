using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    private int money = 0;

    [SerializeField] private GameObject[] Scenes;

    [SerializeField] private Text dialogueText;
    [SerializeField] private Button button;
    [SerializeField] private Text moneyCount;

    [SerializeField] private Button[] buttonsDecision;

    private float typingSpeed = 0.02f;
    private string fullText;
    private string currentText = "";

    private int currentDialogueIndex = 0;
    private int currentDecisionsIndex = 0;

    private string[] dialogues = {
        /*1.1*/"Когда-то единое королевство раскололось на две части - Северное и Южное",
        /*1.2*/"В тот вечер, когда столица находилась под осадой, королевская семья была почти полностью уничтожена,\n" +
        "за исключением наследника, который был похищен",
        /*1.3*/"Этот наследник - Вы",
        /*2.1*/"Вы просыпаетесь в своей комнате, в небольшой избушке",
        /*3.1*/"Встав с кровати вы делаете решение:"
    };
    private string[] decisions = {
        /*3.1.1*/"Вы заправили кровать",
        /*3.1.2*/"Да кому это вообще нужно"
    };

    void Start()
    {
        ShowDialogue();
        button.onClick.AddListener(OnButtonClick);
        buttonsDecision[0].onClick.AddListener(makeTheBed);
        buttonsDecision[1].onClick.AddListener(notMakeTheBed);
    }

    void ShowDialogue()
    {
        if (currentDialogueIndex < dialogues.Length)
        {
            fullText = dialogues[currentDialogueIndex];
            currentText = "";
            StartCoroutine(TypeText());
        }
    }

    void ShowDecisionsDialogue()
    {
        if (currentDecisionsIndex < decisions.Length)
        {
            fullText = decisions[currentDecisionsIndex];
            currentText = "";
            StartCoroutine(TypeText());
        }
    }

    void OnButtonClick()
    {
        StopAllCoroutines();
        if (currentText != fullText)
        {
            currentText = fullText;
            dialogueText.text = currentText;
        }
        else
        {
            currentDialogueIndex++;
            ShowDialogue();
        }
        switch(currentDialogueIndex)
        {
            case 3:
                Scenes[0].SetActive(false);
                Scenes[1].SetActive(true);
                break;
            case 4:
                Scenes[1].SetActive(false);
                Scenes[2].SetActive(true);
                break;
            case 5:
                buttonsDecision[0].gameObject.SetActive(true);
                buttonsDecision[1].gameObject.SetActive(true);
                break;
        }

    }

    private IEnumerator TypeText()
    {
        foreach (char letter in fullText.ToCharArray())
        {
            currentText += letter;
            dialogueText.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void makeTheBed()
    {
        currentDecisionsIndex = 0;
        money += 5;
        moneyCount.text = money.ToString();
        ShowDecisionsDialogue();
        StopAllCoroutines();
        if (currentText != fullText)
        {
            currentText = fullText;
            dialogueText.text = currentText;
        }
        else
        {
            currentDecisionsIndex++;
            ShowDialogue();
        }
        buttonsDecision[0].gameObject.SetActive(false);
        buttonsDecision[1].gameObject.SetActive(false);
    }
    void notMakeTheBed()
    {
        currentDecisionsIndex = 1;
        ShowDecisionsDialogue();
        StopAllCoroutines();
        if (currentText != fullText)
        {
            currentText = fullText;
            dialogueText.text = currentText;
        }
        else
        {
            currentDecisionsIndex++;
            ShowDialogue();
        }
        buttonsDecision[0].gameObject.SetActive(false);
        buttonsDecision[1].gameObject.SetActive(false);
    }

}
