using UnityEngine;

public class OptionsImage : MonoBehaviour
{
    public GameObject pauseMenu;
    public KeyCode keyToPress = KeyCode.Alpha1;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        Debug.Log("sdsd");
        pauseMenu.SetActive(true);
    }
}
