using UnityEngine;
using System.IO;
using Fungus;

public class SaveLoadSystem : MonoBehaviour
{
    public Flowchart flowchart;

    public void SaveGame()
    {
        GameData.SavedBlockName = flowchart.GetExecutingBlocks()[0].BlockName;
    }

    public void LoadGame()
    {
        if(!string.IsNullOrEmpty(GameData.SavedBlockName))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
    }
}
