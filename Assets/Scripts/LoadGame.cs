using UnityEngine;
using Fungus;

public class LoadGame : MonoBehaviour
{
    private void Start()
    {
        Flowchart flowchart = FindObjectOfType<Flowchart>();
        if (flowchart != null)
        {
            // ��������� ��� ������������ �����
            string savedBlockName = PlayerPrefs.GetString("SavedBlock", "");
            if (!string.IsNullOrEmpty(savedBlockName))
            {
                Block savedBlock = flowchart.FindBlock(savedBlockName);
                if (savedBlock != null)
                {
                    // ��������� ������ ����������� �������
                    int savedCommandIndex = PlayerPrefs.GetInt("SavedCommandIndex", 0);

                    // ��������� ���� � ����������� �������
                    flowchart.ExecuteBlock(savedBlock, savedCommandIndex);
                    Debug.Log("���� ���������: ���� " + savedBlockName + ", ������� " + savedCommandIndex);
                }
                else
                {
                    Debug.LogError("���� �� ������: " + savedBlockName);
                }
            }
            else
            {
                Debug.Log("����������� ���� �� ������. �������� � ������.");
            }
        }
    }
}
