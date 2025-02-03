using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{

    public List<Sprite> emotions;
    public string characterName;

    public void ChangeEmotion(int currentExpression)
    {
        GetComponent<Image>().sprite = emotions[currentExpression];
    }
}
