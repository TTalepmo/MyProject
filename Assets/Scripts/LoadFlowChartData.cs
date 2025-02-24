using UnityEngine;
using Fungus;

public class LoadFlowChartData : MonoBehaviour
{
    public Flowchart flowchart;

    private void Start()
    {
        if(!string.IsNullOrEmpty(GameData.SavedBlockName))
        {
            flowchart.ExecuteBlock(GameData.SavedBlockName);
        }
    }
}
