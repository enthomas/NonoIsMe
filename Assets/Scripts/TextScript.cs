using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    public GameObject controller;

    public void Activate()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        //donne le bon tag aux objets
        switch (this.name)
        {
            case "textNono": this.tag = "Noun"; break;
            case "textAJEE": this.tag = "Noun"; break;
            case "textBDA": this.tag = "Noun"; break;
            case "textArmise": this.tag = "Noun"; break;
            case "textPoulpy": this.tag = "Noun"; break;
            case "textKedge": this.tag = "Noun"; break;
            case "textIs": this.tag = "Operator"; break;
            case "textMe": this.tag = "Me"; break;
            case "textPush": this.tag = "Property"; break;
            case "textStop": this.tag = "Property"; break;
            case "textWin": this.tag = "Win"; break;
            case "textDefeat": this.tag = "Defeat"; break;
        }
    }
}
