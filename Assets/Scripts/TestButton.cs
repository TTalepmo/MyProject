using UnityEngine;
using Fungus;

public class TestButton : MonoBehaviour
{
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject canvasDialogue;
    private bool isOpen = false;
    private Flowchart flowchart;
    private Block currentBlock;

    void Start()
    {
        // Найдите компонент Flowchart в сцене
        flowchart = FindFirstObjectByType<Flowchart>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ToggleMenu();
        }
    }

    private void ToggleMenu()
    {
        if (isOpen)
        {
            CloseMenu();
        }
        else
        {
            OpenMenu();
        }
    }

    private void OpenMenu()
    {
        optionsMenu.SetActive(true);
        canvasDialogue.SetActive(false);
        isOpen = true;
        Time.timeScale = 0;
    }

    private void CloseMenu()
    {
        optionsMenu.SetActive(false);
        canvasDialogue.SetActive(true);
        isOpen = false;
        Time.timeScale = 1;
    }
}
