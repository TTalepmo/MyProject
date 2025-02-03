using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class Dialogues : MonoBehaviour
{
    private Story _currentStory;
    private TextAsset _inkjson;

    private GameObject _dialoguePanel;
    private TextMeshProUGUI _dialogueText;
    private TextMeshProUGUI _nameText;

    [HideInInspector] public GameObject _choiceButtonsPanel;
    private GameObject _choiceButton;
    private List<TextMeshProUGUI> _choicesText = new();
    private List<Character> characters = new();

    public bool DialogueStart { get; private set; }

    [Inject]
    public void Construct(DialogueInstaller dialogueInstaller)
    {
        _inkjson = dialogueInstaller.inkjson;
        _dialoguePanel = dialogueInstaller.dialoguePanel;
        _dialogueText = dialogueInstaller.dialogueText;
        _nameText = dialogueInstaller.nameText;
        _choiceButtonsPanel = dialogueInstaller.choiceButtonsPanel;
        _choiceButton = dialogueInstaller.choiceButton;
    }

    private void Awake()
    {
        _currentStory = new Story(_inkjson.text);
    }

    void Start()
    {
        foreach (var character in FindObjectsOfType<Character>())
        {
            characters.Add(character);
        }
        StartDialogue();
    }
    
    public void StartDialogue()
    {
        DialogueStart = true;
        _dialoguePanel.SetActive(true);
        ContinueStory();
    }
    public void ContinueStory(bool ChoiceBefore = false)
    {
        if (_currentStory.canContinue)
        {
            ShowDialogue();
            ShowChoiceButtons();
        }
        else if (!ChoiceBefore)
        {
            ExitDialogue();
        }
    }
    private void ShowDialogue()
    {
        _dialogueText.text = _currentStory.Continue();
        _nameText.text = (string)_currentStory.variablesState["characterName"];
        var index = characters.FindIndex(character=>character.characterName.Contains(_nameText.text));
        //characters[index].ChangeEmotion((int)_currentStory.variablesState["characterExpression"]);
    }
    private void ShowChoiceButtons()
    {
        List<Choice> currentChoices = _currentStory.currentChoices;
        _choiceButtonsPanel.SetActive(currentChoices.Count != 0);
        if(currentChoices.Count <= 0) {return;}
        _choiceButtonsPanel.transform.Cast<Transform>().ToList().ForEach(child => Destroy(child.gameObject));
        _choicesText.Clear();
        for(int i = 0; i < currentChoices.Count; i++)
        {
            GameObject choice = Instantiate(_choiceButton);
            choice.GetComponent<ButtonAction>().index = i;
            choice.transform.SetParent(_choiceButtonsPanel.transform);

            TextMeshProUGUI choiceText = choice.GetComponentInChildren<TextMeshProUGUI>();
            choiceText.text = currentChoices[i].text;
            _choicesText.Add(choiceText);
        } 
    }
    public void ChoiceButtonActions(int choiceIndex)
    {
        _currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory(true);
    }
    private void ExitDialogue()
    {
        DialogueStart = false;
        _dialoguePanel.SetActive(false);
        int nextChapterIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if(nextChapterIndex <= SceneManager.sceneCount)
        {
            SceneManager.LoadScene(nextChapterIndex);
        }

    }

}
