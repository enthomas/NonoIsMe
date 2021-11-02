using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //Références
    public GameObject controller;

    //Positions
    private int xBoard = -1;
    private int yBoard = -1;
    //References for all the sprites
    public Sprite nono, ajee, bda, armise, poulpy, kedge, textNono, textAJEE, textBDA, textArmise, textPoulpy, textKedge, textIs, textMe, textPush, textStop, textWin, textDefeat;

    public void Activate()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        //take the instantiated location and adjust the transform
        SetCoords();

        //donne le bon sprite aux objets
        switch (this.name)
        {
            case "Nono": this.GetComponent<SpriteRenderer>().sprite = nono; break;
            case "AJEE": this.GetComponent<SpriteRenderer>().sprite = ajee; break;
            case "BDA": this.GetComponent<SpriteRenderer>().sprite = bda; break;
            case "Armise": this.GetComponent<SpriteRenderer>().sprite = armise; break;
            case "Poulpy": this.GetComponent<SpriteRenderer>().sprite = poulpy; break;
            case "Kedge": this.GetComponent<SpriteRenderer>().sprite = kedge; break;
            case "textNono": this.GetComponent<SpriteRenderer>().sprite = textNono; break;
            case "textAJEE": this.GetComponent<SpriteRenderer>().sprite = textAJEE; break;
            case "textBDA": this.GetComponent<SpriteRenderer>().sprite = textBDA; break;
            case "textArmise": this.GetComponent<SpriteRenderer>().sprite = textArmise; break;
            case "textPoulpy": this.GetComponent<SpriteRenderer>().sprite = textPoulpy; break;
            case "textKedge": this.GetComponent<SpriteRenderer>().sprite = textKedge; break;
            case "textIs": this.GetComponent<SpriteRenderer>().sprite = textIs; break;
            case "textMe": this.GetComponent<SpriteRenderer>().sprite = textMe; break;
            case "textPush": this.GetComponent<SpriteRenderer>().sprite = textPush; break;
            case "textStop": this.GetComponent<SpriteRenderer>().sprite = textStop; break;
            case "textWin": this.GetComponent<SpriteRenderer>().sprite = textWin; break;
            case "textDefeat": this.GetComponent<SpriteRenderer>().sprite = textDefeat; break;
        }

        this.tag = "Piece";
    }

    //transforme les coordonnées sur le plateau en coordonnées sur la scène
    public void SetCoords()
    {
        float x = xBoard;
        float y = yBoard;
        float z = this.transform.position.z;

        x = (float)(-8.5 + (x - 1));
        y = (float)(-4.5 + (y - 1));

        this.transform.position = new Vector3(x, y, z);
    }

    public int GetXBoard()
    { return xBoard; }

    public int GetYBoard()
    { return yBoard; }

    public void SetXBoard(int x)
    { xBoard = x; }

    public void SetYBoard(int y)
    { yBoard = y; }
}
