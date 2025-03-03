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
                // ��������� ��� �������� �����
                PlayerPrefs.SetString("SavedBlock", currentBlock.BlockName);

                // �������� ������ ������� �������
                int currentCommandIndex = GetCurrentCommandIndex(flowchart, currentBlock);
                PlayerPrefs.SetInt("SavedCommandIndex", currentCommandIndex);

                PlayerPrefs.Save(); // ��������� ������
                Debug.Log("���� ���������: ���� " + currentBlock.BlockName + ", ������� " + currentCommandIndex);
            }
            else
            {
                Debug.Log("������");
            }
        }
    }

    // ����� ��� ��������� ������� ������� �������
    private int GetCurrentCommandIndex(Flowchart flowchart, Block block)
    {
        // �������� ��� ������� � �����
        var commands = block.CommandList;

        // �������� �� �������� � ������� �������
        for (int i = 0; i < commands.Count; i++)
        {
            if (commands[i].IsExecuting)
            {
                return i; // ���������� ������ ������� �������
            }
        }

        return 0; // ���� ������� ������� �� �������, ���������� 0 (������ �����)
    }
}
