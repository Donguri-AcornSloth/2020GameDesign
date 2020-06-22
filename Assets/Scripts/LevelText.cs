using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    public GameObject character;
    public Judge judge;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        judge = character.GetComponent<Judge>();
        text = GetComponent<Text>();
        text.text = "Lv." + judge.minPower;
    }

    // Update is called once per frame
    void Update()
    {
        if(character.activeSelf==false)
        {
            text.text = "Die...";
        }
        if(character.activeSelf==true)
        {
            text.text = "Lv." + judge.minPower;
        }
    }
}
