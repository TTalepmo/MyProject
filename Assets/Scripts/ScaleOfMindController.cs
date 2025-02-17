using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class ScaleOfMind : MonoBehaviour
{
    public Image scaleOfMindImage;
    private Flowchart myFlowchart;
    private float maxMind = 100;
    private float currentMind;

    void Start()
    {
        myFlowchart = FindFirstObjectByType<Flowchart>();
        currentMind = myFlowchart.GetIntegerVariable("Mind");

        UpdateScaleOfMind();
    }

    public void UpdateScaleOfMind()
    {
        currentMind = myFlowchart.GetIntegerVariable("Mind");
        scaleOfMindImage.fillAmount = currentMind / maxMind;
    }
}
