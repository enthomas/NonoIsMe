using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributs : MonoBehaviour
{
    public GameObject controller;

    //tous les attributs possibles
    private bool me;
    private bool push;
    private bool stop;

    public void Activate()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
    }


    //Demandes à voir les valeurs
    public bool IsMe()
    { return me; }

    public bool IsPush()
    { return push; }

    public bool IsStop()
    { return stop; }


    //SET
    public void Set(string prop)
    {
        switch (prop)
        {
            case "Me":
                me = true;
                GameObject obj = this.gameObject;
                //on donne la possibilité de bouger
                Move move = obj.AddComponent<Move>();
                move.Activate();
                //on l'ajoute au tableau des positions s'il est pas déjà dessus
                controller.GetComponent<Game>().SetPosition(obj);
                //on le met en avant par rapport aux autres objets
                obj.transform.position += new Vector3(0, 0, -1);
                break;
            case "Push":
                push = true;
                obj = this.gameObject;
                //on l'ajoute au tableau des positions s'il est pas déjà dessus
                controller.GetComponent<Game>().SetPosition(obj);
                break;
            case "Stop": 
                stop = true;
                obj = this.gameObject;
                //on l'ajoute au tableau des positions s'il est pas déjà dessus
                controller.GetComponent<Game>().SetPosition(obj);
                break;
        }
    }


    //REMOVE
    public void Remove(string prop)
    {
        switch (prop)
        {
            case "Me":
                me = false;
                GameObject obj = this.gameObject;
                //on enlève la possibilité de bouger
                obj.GetComponent<Move>().DestroyScriptInstance();
                //s'il n'a plus de raison d'être dans le tableau des positions on l'enlève
                if (!push & !stop)
                {
                    int x = obj.GetComponent<PlayerScript>().GetXBoard();
                    int y = obj.GetComponent<PlayerScript>().GetYBoard();
                    controller.GetComponent<Game>().PositionRemove(obj, x, y);
                }
                //on le remet au même plan que les autres objets
                obj.transform.position += new Vector3(0, 0, 1);
                break;
            case "Push":
                push = false;
                //s'il n'a plus de raison d'être dans le tableau des positions on l'enlève
                if (!stop)
                {
                    obj = this.gameObject;
                    int x = obj.GetComponent<PlayerScript>().GetXBoard();
                    int y = obj.GetComponent<PlayerScript>().GetYBoard();
                    controller.GetComponent<Game>().PositionRemove(obj, x, y);
                }                
                break;
            case "Stop": 
                stop = false;
                //s'il n'a plus de raison d'être dans le tableau des positions on l'enlève
                if (!push)
                {
                    obj = this.gameObject;
                    int x = obj.GetComponent<PlayerScript>().GetXBoard();
                    int y = obj.GetComponent<PlayerScript>().GetYBoard();
                    controller.GetComponent<Game>().PositionRemove(obj, x, y);
                }                
                break;
        }
    }


    //reset
    public void Reset()
    {
        me = false;
        push = false;
        stop = false;
    }
}
