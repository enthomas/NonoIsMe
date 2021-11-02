using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject controller; //controller.GetComponent<Game>().SetPosition(reference);

    public void Activate()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        //quand on appuie sur la flèche du haut
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GameObject obj = this.gameObject;
            int x = obj.GetComponent<PlayerScript>().GetXBoard();
            int y = obj.GetComponent<PlayerScript>().GetYBoard();
            if (CanMoveUp(x, y))
            {
                MoveUp(obj, x, y);
            }
            controller.GetComponent<Game>().Mouvement();
        }
        //quand on appuie sur la flèche du bas
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GameObject obj = this.gameObject;
            int x = obj.GetComponent<PlayerScript>().GetXBoard();
            int y = obj.GetComponent<PlayerScript>().GetYBoard();
            if (CanMoveDown(x, y))
            {
                MoveDown(obj, x, y);
            }
            controller.GetComponent<Game>().Mouvement();
        }
        //quand on appuie sur la flèche de droite
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameObject obj = this.gameObject;
            int x = obj.GetComponent<PlayerScript>().GetXBoard();
            int y = obj.GetComponent<PlayerScript>().GetYBoard();
            if (CanMoveRight(x, y))
            {
                MoveRight(obj, x, y);
            }
            controller.GetComponent<Game>().Mouvement();
        }
        //quand on appuie sur la flèche de gauche
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameObject obj = this.gameObject;
            int x = obj.GetComponent<PlayerScript>().GetXBoard();
            int y = obj.GetComponent<PlayerScript>().GetYBoard();
            if (CanMoveLeft(x, y))
            {
                MoveLeft(obj, x, y);
            }
            controller.GetComponent<Game>().Mouvement();
        }
    }

    //change la position de object de (x1,y1) à (x2,y2)
    public void ChangePosition(GameObject obj, int x1, int y1, int x2, int y2)
    {
        controller.GetComponent<Game>().PositionRemove(obj, x1, y1);
        obj.GetComponent<PlayerScript>().SetXBoard(x2);
        obj.GetComponent<PlayerScript>().SetYBoard(y2);
        controller.GetComponent<Game>().SetPosition(obj);
        obj.GetComponent<PlayerScript>().SetCoords();
    }

    //Send true if you can move up from the position (x,y)
    public bool CanMoveUp(int x, int y)
    {
        if (controller.GetComponent<Game>().positionAvailable(x, y + 1))
        { return true; }
        if (!controller.GetComponent<Game>().positionOnBoardNoStop(x, y + 1))
        { return false; }
        return CanMoveUp(x, y + 1);
    }

    //Move up obj from the position (x,y)
    public void MoveUp(GameObject obj, int x, int y)
    {
        if (controller.GetComponent<Game>().positionAvailable(x, y + 1))
        { ChangePosition(obj, x, y, x, y + 1); }
        else
        {
            List<GameObject> obj2List = controller.GetComponent<Game>().GetPosition(x, y + 1);
            if (obj2List.Count == 1)
            {
                GameObject obj2 = obj2List[0];
                if (controller.GetComponent<Game>().WhosMe() != obj2.name)
                { MoveUp(obj2, x, y + 1); }
            }
            else
            { MoveUpMultiple(obj2List, x, y + 1); }
            ChangePosition(obj, x, y, x, y + 1);
        }
    }

    //Move up plusieurs obj qui sont clipés from the position (x,y)
    public void MoveUpMultiple(List<GameObject> objList, int x, int y)
    {
        if (controller.GetComponent<Game>().positionAvailable(x, y + 1))
        {
            foreach (GameObject obj in objList)
            { ChangePosition(obj, x, y, x, y + 1); }            
        }
        else
        {
            List<GameObject> obj2List = controller.GetComponent<Game>().GetPosition(x, y + 1);
            if (obj2List.Count == 1)
            {
                GameObject obj2 = obj2List[0];
                if (controller.GetComponent<Game>().WhosMe() != obj2.name)
                { MoveUp(obj2, x, y + 1); }
            }
            else
            { MoveUpMultiple(obj2List, x, y + 1); }
            foreach (GameObject obj in objList)
            { ChangePosition(obj, x, y, x, y + 1); }
        }
    }

    //Send true if you can move down from the position (x,y)
    public bool CanMoveDown(int x, int y)
    {
        if (controller.GetComponent<Game>().positionAvailable(x, y - 1))
        { return true; }
        if (!controller.GetComponent<Game>().positionOnBoardNoStop(x, y - 1))
        { return false; }
        return CanMoveDown(x, y - 1);
    }

    //Move down obj from the position (x,y)
    public void MoveDown(GameObject obj, int x, int y)
    {
        if (controller.GetComponent<Game>().positionAvailable(x, y - 1))
        { ChangePosition(obj, x, y, x, y - 1); }
        else
        {
            List<GameObject> obj2List = controller.GetComponent<Game>().GetPosition(x, y - 1);
            if (obj2List.Count == 1)
            {
                GameObject obj2 = obj2List[0];
                if (controller.GetComponent<Game>().WhosMe() != obj2.name)
                { MoveDown(obj2, x, y - 1); }
            }
            else
            { MoveDownMultiple(obj2List, x, y - 1); }
            ChangePosition(obj, x, y, x, y - 1);
        }
    }

    //Move down plusieurs obj qui sont clipés from the position (x,y)
    public void MoveDownMultiple(List<GameObject> objList, int x, int y)
    {
        if (controller.GetComponent<Game>().positionAvailable(x, y - 1))
        {
            foreach (GameObject obj in objList)
            { ChangePosition(obj, x, y, x, y - 1); }
        }
        else
        {
            List<GameObject> obj2List = controller.GetComponent<Game>().GetPosition(x, y - 1);
            if (obj2List.Count == 1)
            {
                GameObject obj2 = obj2List[0];
                if (controller.GetComponent<Game>().WhosMe() != obj2.name)
                { MoveDown(obj2, x, y - 1); }
            }
            else
            { MoveDownMultiple(obj2List, x, y - 1); }
            foreach (GameObject obj in objList)
            { ChangePosition(obj, x, y, x, y - 1); }
        }
    }

    //Send true if you can move right from the position (x,y)
    public bool CanMoveRight(int x, int y)
    {
        if (controller.GetComponent<Game>().positionAvailable(x + 1, y))
        { return true; }
        if (!controller.GetComponent<Game>().positionOnBoardNoStop(x + 1, y))
        { return false; }
        return CanMoveRight(x + 1, y);
    }

    //Move right obj from the position (x,y)
    public void MoveRight(GameObject obj, int x, int y)
    {
        if (controller.GetComponent<Game>().positionAvailable(x + 1, y))
        { ChangePosition(obj, x, y, x + 1, y); }
        else
        {
            List<GameObject> obj2List = controller.GetComponent<Game>().GetPosition(x + 1, y);
            if (obj2List.Count == 1)
            {
                GameObject obj2 = obj2List[0];
                if (controller.GetComponent<Game>().WhosMe() != obj2.name)
                { MoveRight(obj2, x + 1, y); }
            }
            else
            { MoveRightMultiple(obj2List, x + 1, y); }
            ChangePosition(obj, x, y, x + 1, y);
        }
    }

    //Move right plusieurs obj qui sont clipés from the position (x,y)
    public void MoveRightMultiple(List<GameObject> objList, int x, int y)
    {
        if (controller.GetComponent<Game>().positionAvailable(x + 1, y))
        {
            foreach (GameObject obj in objList)
            { ChangePosition(obj, x, y, x + 1, y); }
        }
        else
        {
            List<GameObject> obj2List = controller.GetComponent<Game>().GetPosition(x + 1, y);
            if (obj2List.Count == 1)
            {
                GameObject obj2 = obj2List[0];
                if (controller.GetComponent<Game>().WhosMe() != obj2.name)
                { MoveRight(obj2, x + 1, y); }
            }
            else
            { MoveRightMultiple(obj2List, x + 1, y); }
            foreach (GameObject obj in objList)
            { ChangePosition(obj, x, y, x + 1, y); }
        }
    }

    //Send true if you can move left from the position (x,y)
    public bool CanMoveLeft(int x, int y)
    {
        if (controller.GetComponent<Game>().positionAvailable(x - 1, y))
        { return true; }
        if (!controller.GetComponent<Game>().positionOnBoardNoStop(x - 1, y))
        { return false; }
        return CanMoveLeft(x - 1, y);
    }

    //Move left obj from the position (x,y)
    public void MoveLeft(GameObject obj, int x, int y)
    {
        if (controller.GetComponent<Game>().positionAvailable(x - 1, y))
        { ChangePosition(obj, x, y, x - 1, y); }
        else
        {
            List<GameObject> obj2List = controller.GetComponent<Game>().GetPosition(x - 1, y);
            if (obj2List.Count == 1)
            {
                GameObject obj2 = obj2List[0];
                if (controller.GetComponent<Game>().WhosMe() != obj2.name)
                { MoveLeft(obj2, x - 1, y); }
            }
            else
            { MoveLeftMultiple(obj2List, x - 1, y); }
            ChangePosition(obj, x, y, x - 1, y);
        }
    }

    //Move left plusieurs obj qui sont clipés from the position (x,y)
    public void MoveLeftMultiple(List<GameObject> objList, int x, int y)
    {
        if (controller.GetComponent<Game>().positionAvailable(x - 1, y))
        {
            foreach (GameObject obj in objList)
            { ChangePosition(obj, x, y, x - 1, y); }
        }
        else
        {
            List<GameObject> obj2List = controller.GetComponent<Game>().GetPosition(x - 1, y);
            if (obj2List.Count == 1)
            {
                GameObject obj2 = obj2List[0];
                if (controller.GetComponent<Game>().WhosMe() != obj2.name)
                { MoveLeft(obj2, x - 1, y); }
            }
            else
            { MoveLeftMultiple(obj2List, x - 1, y); }
            foreach (GameObject obj in objList)
            { ChangePosition(obj, x, y, x - 1, y); }
        }
    }

    public void DestroyScriptInstance()
    {
        // Removes this script instance from the game object
        Destroy(this);
    }
}
