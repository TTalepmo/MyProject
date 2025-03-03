using UnityEngine;
using Fungus;

public class LoadGame : MonoBehaviour
{
    private void Start()
    {
        Flowchart flowchart = FindObjectOfType<Flowchart>();
        if (flowchart != null)
        {
            // Загружаем имя сохраненного блока
            string savedBlockName = PlayerPrefs.GetString("SavedBlock", "");
            if (!string.IsNullOrEmpty(savedBlockName))
            {
                Block savedBlock = flowchart.FindBlock(savedBlockName);
                if (savedBlock != null)
                {
                    // Загружаем индекс сохраненной команды
                    int savedCommandIndex = PlayerPrefs.GetInt("SavedCommandIndex", 0);

                    // Запускаем блок с сохраненной команды
                    flowchart.ExecuteBlock(savedBlock, savedCommandIndex);
                    Debug.Log("Игра загружена: блок " + savedBlockName + ", команда " + savedCommandIndex);
                }
                else
                {
                    Debug.LogError("Блок не найден: " + savedBlockName);
                }
            }
            else
            {
                Debug.Log("Сохраненный блок не найден. Начинаем с начала.");
            }
        }
    }
}
