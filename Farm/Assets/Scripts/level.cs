using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;


public class level : MonoBehaviour
{
    private Text lvlText;
    private RectTransform barRectTransform;

    void Start()
    {
        lvlText = GetComponentInChildren<Text>();
        barRectTransform = GetComponentsInChildren<Image>()[1].GetComponent<RectTransform>();



    }
    private void Update()
    {
                barRectTransform.localScale = new Vector3(Player.lvlProgress, 0.16f, 1);
        lvlText.text = "Lvl " + Player.lvl;
    }
}
