using UnityEngine;
using Fungus;

public class SaveGame : MonoBehaviour
{
    public void SaveCurrentState()
    {
        Flowchart flowchart = FindObjectOfType<Flowchart>();
        if (flowchart != null)
        {
            Block currentBlock = flowchart.SelectedBlock;
            if (currentBlock != null)
            {
                // Сохраняем имя текущего блока
                PlayerPrefs.SetString("SavedBlock", currentBlock.BlockName);

                // Получаем индекс текущей команды
                int currentCommandIndex = GetCurrentCommandIndex(flowchart, currentBlock);
                PlayerPrefs.SetInt("SavedCommandIndex", currentCommandIndex);

                PlayerPrefs.Save(); // Сохраняем данные
                Debug.Log("Игра сохранена: блок " + currentBlock.BlockName + ", команда " + currentCommandIndex);
            }
            else
            {
                Debug.Log("ОШибка");
            }
        }
    }

    // Метод для получения индекса текущей команды
    private int GetCurrentCommandIndex(Flowchart flowchart, Block block)
    {
        // Получаем все команды в блоке
        var commands = block.CommandList;

        // Проходим по командам и находим текущую
        for (int i = 0; i < commands.Count; i++)
        {
            if (commands[i].IsExecuting)
            {
                return i; // Возвращаем индекс текущей команды
            }
        }

        return 0; // Если текущая команда не найдена, возвращаем 0 (начало блока)
    }
}
