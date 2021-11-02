using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public GameObject piece;
    public GameObject text;
    public GameObject textWin;

    //liste des pièces et de leur position
    private List<GameObject>[,] positions;
    //liste des pièces
    private GameObject[] pieces;

    //liste des règles du niveau
    private List<string[]> rulesList = new List<string[]>();
    private List<string[]> transformationList = new List<string[]>();

    //quel objet le joueur est
    private string me;
    private List<GameObject> Me = new List<GameObject>();

    //où sont les objets pour win
    private List<int[]> whereToWin = new List<int[]>();
    //où sont les objets pour loose
    private List<int[]> whereToLoose = new List<int[]>();
    //partie terminée
    private bool win = false;
    private bool textDisplayed = false;



    // Start is called before the first frame update
    void Start()
    {
        //Reset entre les niveaux
        win = false;
        textDisplayed = false;
        positions = new List<GameObject>[18, 10];
        rulesList.Clear();
        transformationList.Clear();
        Me.Clear();

        //Création différente selon le niveau
        switch (LevelSelection.index)
        {
            case 1:
                pieces = new GameObject[33];
                int indice = 0;
                int[,] scene = new int[,] { {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                            {  0,  0,  0,  0,  0, 10, 10, 10, 10, 10, 10, 10,  0,  0,  0,  0,  0,  0},
                                            {  0,  0,  0,  0,  0,  0,  0,  0, 11,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                            {  0,  1,  2,  3,  0,  0,  0,  0, 11,  0,  0,  0,  0,  4,  2,  5,  0,  0},
                                            {  0,  0,  0,  0,  0, 13,  0,  0, 11,  0,  0, 12,  0,  0,  0,  0,  0,  0},
                                            {  0,  8,  2,  9,  0,  0,  0,  0, 11,  0,  0,  0,  0,  6,  2,  7,  0,  0},
                                            {  0,  0,  0,  0,  0,  0,  0,  0, 11,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                            {  0,  0,  0,  0,  0, 10, 10, 10, 10, 10, 10, 10,  0,  0,  0,  0,  0,  0},
                                            {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                            {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0}};
                for (int x = 1; x <= 18; x++)
                {
                    for (int y = 1; y <= 10; y++)
                    {
                        int id = scene[10 - y, x - 1];
                        switch (id)
                        {
                            case 1: pieces[indice] = CreateText("textNono", x, y); indice++; break;
                            case 2: pieces[indice] = CreateText("textIs", x, y); indice++; break;
                            case 3: pieces[indice] = CreateText("textMe", x, y); indice++; break;
                            case 4: pieces[indice] = CreateText("textBDA", x, y); indice++; break;
                            case 5: pieces[indice] = CreateText("textWin", x, y); indice++; break;
                            case 6: pieces[indice] = CreateText("textAJEE", x, y); indice++; break;
                            case 7: pieces[indice] = CreateText("textPush", x, y); indice++; break;
                            case 8: pieces[indice] = CreateText("textPoulpy", x, y); indice++; break;
                            case 9: pieces[indice] = CreateText("textStop", x, y); indice++; break;
                            case 10: pieces[indice] = Create("Poulpy", x, y); indice++; break;
                            case 11: pieces[indice] = Create("AJEE", x, y); indice++; break;
                            case 12: pieces[indice] = Create("BDA", x, y); indice++; break;
                            case 13: pieces[indice] = Create("Nono", x, y); indice++; break;
                        }
                    }
                }
                break;
            case 2:
                pieces = new GameObject[28];
                indice = 0;
                scene = new int[,] { {  0,  0,  1,  2,  3,  0,  0,  0,  8,  8,  0,  0,  0,  4,  2,  5,  0,  0},
                                     {  0,  0,  0,  0,  0,  0,  0,  0,  8,  8,  0,  0,  0,  0,  0,  0,  0,  0},
                                     {  0,  0,  0,  0,  0,  0,  0,  0,  8,  8,  0,  0,  0,  0,  0,  0,  0,  0},
                                     {  0,  0,  0,  0,  0,  0,  0,  0,  8,  8,  0,  0,  0,  0,  0,  0,  0,  0},
                                     {  0,  0,  0,  0,  0,  0,  0,  0,  8,  8,  0,  0,  0,  0,  0,  0,  0,  0},
                                     {  0,  0,  0,  6,  0,  0,  0,  0,  8,  8,  0,  0,  0,  0,  7,  0,  0,  0},
                                     {  0,  0,  0,  0,  0,  0,  0,  0,  8,  8,  0,  0,  0,  0,  0,  0,  0,  0},
                                     {  0,  0,  0,  0,  0,  0,  0,  0,  8,  8,  0,  0,  0,  0,  0,  0,  0,  0},
                                     {  0,  0,  0,  0,  0,  0,  0,  0,  8,  8,  0,  0,  0,  0,  0,  0,  0,  0},
                                     {  0,  0,  0,  0,  0,  0,  0,  0,  8,  8,  0,  0,  0,  0,  0,  0,  0,  0}};
                for (int x = 1; x <= 18; x++)
                {
                    for (int y = 1; y <= 10; y++)
                    {
                        int id = scene[10 - y, x - 1];
                        switch (id)
                        {
                            case 1: pieces[indice] = CreateText("textNono", x, y); indice++; break;
                            case 2: pieces[indice] = CreateText("textIs", x, y); indice++; break;
                            case 3: pieces[indice] = CreateText("textMe", x, y); indice++; break;
                            case 4: pieces[indice] = CreateText("textBDA", x, y); indice++; break;
                            case 5: pieces[indice] = CreateText("textWin", x, y); indice++; break;
                            case 6: pieces[indice] = Create("Nono", x, y); indice++; break;
                            case 7: pieces[indice] = Create("BDA", x, y); indice++; break;
                            case 8: pieces[indice] = Create("AJEE", x, y); indice++; break;
                        }
                    }
                }
                break;
            case 3:
                pieces = new GameObject[11];
                indice = 0;
                scene = new int[,] { {  0,  0,  1,  2,  3,  0,  0,  0,  0,  0,  0,  0,  0,  4,  2,  5,  0,  0},
                                     {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                     {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                     {  0,  0,  0,  0,  0,  0,  0,  4,  2,  6,  0,  0,  0,  0,  0,  0,  0,  0},
                                     {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                     {  0,  0,  0,  7,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  8,  0,  0,  0},
                                     {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                     {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                     {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                     {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0}};
                for (int x = 1; x <= 18; x++)
                {
                    for (int y = 1; y <= 10; y++)
                    {
                        int id = scene[10 - y, x - 1];
                        switch (id)
                        {
                            case 1: pieces[indice] = CreateText("textNono", x, y); indice++; break;
                            case 2: pieces[indice] = CreateText("textIs", x, y); indice++; break;
                            case 3: pieces[indice] = CreateText("textMe", x, y); indice++; break;
                            case 4: pieces[indice] = CreateText("textBDA", x, y); indice++; break;
                            case 5: pieces[indice] = CreateText("textWin", x, y); indice++; break;
                            case 6: pieces[indice] = CreateText("textPush", x, y); indice++; break;
                            case 7: pieces[indice] = Create("Nono", x, y); indice++; break;
                            case 8: pieces[indice] = Create("BDA", x, y); indice++; break;
                            case 9: pieces[indice] = Create("AJEE", x, y); indice++; break;
                        }
                    }
                }
                break;
            case 4:
                pieces = new GameObject[27];
                indice = 0;
                scene = new int[,] { {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                     {  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                     {  0,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0, 10, 10, 10, 10, 10,  0,  0},
                                     {  0,  3,  0,  0,  0,  0,  0,  0,  0,  0,  0, 10,  0,  0,  0, 10,  0,  0},
                                     {  0,  0,  0,  0,  0,  0,  8,  0,  0,  0,  0, 10,  0,  9,  0, 10,  0,  0},
                                     {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0, 10,  0,  0,  0, 10,  0,  0},
                                     {  0,  4,  0,  0,  0,  0,  0,  0,  0,  0,  0, 10, 10, 10, 10, 10,  0,  0},
                                     {  0,  2,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                     {  0,  5,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                     {  0,  0,  0,  0,  0,  0,  0,  0,  7,  2,  6,  0,  0,  0,  0,  0,  0,  0}};
                for (int x = 1; x <= 18; x++)
                {
                    for (int y = 1; y <= 10; y++)
                    {
                        int id = scene[10 - y, x - 1];
                        switch (id)
                        {
                            case 1: pieces[indice] = CreateText("textNono", x, y); indice++; break;
                            case 2: pieces[indice] = CreateText("textIs", x, y); indice++; break;
                            case 3: pieces[indice] = CreateText("textMe", x, y); indice++; break;
                            case 4: pieces[indice] = CreateText("textBDA", x, y); indice++; break;
                            case 5: pieces[indice] = CreateText("textWin", x, y); indice++; break;
                            case 6: pieces[indice] = CreateText("textStop", x, y); indice++; break;
                            case 7: pieces[indice] = CreateText("textAJEE", x, y); indice++; break;
                            case 8: pieces[indice] = Create("Nono", x, y); indice++; break;
                            case 9: pieces[indice] = Create("BDA", x, y); indice++; break;
                            case 10: pieces[indice] = Create("AJEE", x, y); indice++; break;
                        }
                    }
                }
                break;
            case 5:
                pieces = new GameObject[11];
                indice = 0;
                scene = new int[,] { {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                     {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                     {  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                     {  0,  0,  2,  0,  0,  0,  0,  0,  8,  0,  0,  0,  0,  0,  4,  0,  0,  0},
                                     {  0,  0,  3,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2,  0,  0,  0},
                                     {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  5,  0,  0,  0},
                                     {  0,  0,  0,  7,  2,  6,  0,  0,  0,  0,  9,  0,  0,  0,  0,  0,  0,  0},
                                     {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                     {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                     {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0}};
                for (int x = 1; x <= 18; x++)
                {
                    for (int y = 1; y <= 10; y++)
                    {
                        int id = scene[10 - y, x - 1];
                        switch (id)
                        {
                            case 1: pieces[indice] = CreateText("textArmise", x, y); indice++; break;
                            case 2: pieces[indice] = CreateText("textIs", x, y); indice++; break;
                            case 3: pieces[indice] = CreateText("textMe", x, y); indice++; break;
                            case 4: pieces[indice] = CreateText("textBDA", x, y); indice++; break;
                            case 5: pieces[indice] = CreateText("textWin", x, y); indice++; break;
                            case 6: pieces[indice] = CreateText("textStop", x, y); indice++; break;
                            case 7: pieces[indice] = CreateText("textPoulpy", x, y); indice++; break;
                            case 8: pieces[indice] = Create("Armise", x, y); indice++; break;
                            case 9: pieces[indice] = Create("Poulpy", x, y); indice++; break;
                        }
                    }
                }
                break;
            case 6:
                pieces = new GameObject[54];
                indice = 0;
                scene = new int[,] { {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                     {  0, 15, 15, 15, 15, 15, 15,  0,  0,  0,  0,  0,  0, 18,  0,  0,  0,  0},
                                     {  0,  4, 14,  1, 10,  0, 15,  0,  0, 12,  0,  0,  0,  0,  0,  0,  0,  0},
                                     {  0, 15,  2,  0,  2,  0, 15,  0,  0,  0,  0, 17, 17, 17, 17, 17,  0,  0},
                                     {  0, 15,  5,  0, 11,  0, 15,  0,  0,  0,  0, 17,  0,  0,  0, 17,  0,  0},
                                     {  0, 15, 15, 15, 15, 15, 15,  0,  8,  0,  0, 17,  0, 16,  0, 17,  0,  0},
                                     {  0,  0,  0,  0,  0,  0,  0,  0,  2,  0,  0, 17,  0,  0,  0, 17,  0,  0},
                                     {  0,  0,  0,  0,  0,  0,  0,  0,  9,  0, 13, 17, 17, 17, 17, 17,  0,  7},
                                     {  0,  0,  1,  2,  3,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  2},
                                     {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  6}};
                for (int x = 1; x <= 18; x++)
                {
                    for (int y = 1; y <= 10; y++)
                    {
                        int id = scene[10 - y, x - 1];
                        switch (id)
                        {
                            case 1: pieces[indice] = CreateText("textNono", x, y); indice++; break;
                            case 2: pieces[indice] = CreateText("textIs", x, y); indice++; break;
                            case 3: pieces[indice] = CreateText("textMe", x, y); indice++; break;
                            case 4: pieces[indice] = CreateText("textBDA", x, y); indice++; break;
                            case 5: pieces[indice] = CreateText("textWin", x, y); indice++; break;
                            case 6: pieces[indice] = CreateText("textStop", x, y); indice++; break;
                            case 7: pieces[indice] = CreateText("textPoulpy", x, y); indice++; break;
                            case 8: pieces[indice] = CreateText("textAJEE", x, y); indice++; break;
                            case 9: pieces[indice] = CreateText("textPush", x, y); indice++; break;
                            case 10: pieces[indice] = CreateText("textKedge", x, y); indice++; break;
                            case 11: pieces[indice] = CreateText("textDefeat", x, y); indice++; break;
                            case 12: pieces[indice] = Create("Nono", x, y); indice++; break;
                            case 13: pieces[indice] = Create("Armise", x, y); indice++; break;
                            case 14: pieces[indice] = Create("AJEE", x, y); indice++; break;
                            case 15: pieces[indice] = Create("Poulpy", x, y); indice++; break;
                            case 16: pieces[indice] = Create("BDA", x, y); indice++; break;
                            case 17: pieces[indice] = Create("Kedge", x, y); indice++; break;
                            case 18: pieces[indice] = CreateText("textArmise", x, y); indice++; break;
                        }
                    }
                }
                break;
            case 7:
                pieces = new GameObject[37];
                indice = 0;
                scene = new int[,] { {  1,  2,  3,  0,  0,  0,  0,  0,  0,  0,  0,  0, 10,  0,  0,  0,  0,  0},
                                     {  4,  2,  5,  0,  0,  0,  6,  2,  7,  0,  0,  0, 10,  0,  0,  0,  0,  0},
                                     {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0, 10,  0,  0,  8,  0,  0},
                                     {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0, 10,  0,  0,  2,  0,  0},
                                     {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0, 10,  0,  0,  9,  0,  0},
                                     {  0, 10,  0, 10,  0,  0,  0,  0,  0,  0,  0,  0, 10,  0,  0,  0,  0,  0},
                                     { 10, 10, 11, 10, 10, 10,  0,  0,  0,  0,  0,  0, 10,  0,  0,  0,  0,  0},
                                     {  0,  0, 11,  0,  0, 10,  0,  0,  0,  0,  0,  0, 10,  0,  0, 12,  0,  0},
                                     {  0,  0,  0,  0,  0, 10,  0,  0, 11,  0,  0,  0, 10,  0,  0,  0,  0,  0},
                                     {  0,  0, 13,  0,  0, 10,  0,  0,  0,  0,  0,  0, 10,  0,  0,  0,  0,  0}};
                for (int x = 1; x <= 18; x++)
                {
                    for (int y = 1; y <= 10; y++)
                    {
                        int id = scene[10 - y, x - 1];
                        switch (id)
                        {
                            case 1: pieces[indice] = CreateText("textNono", x, y); indice++; break;
                            case 2: pieces[indice] = CreateText("textIs", x, y); indice++; break;
                            case 3: pieces[indice] = CreateText("textMe", x, y); indice++; break;
                            case 4: pieces[indice] = CreateText("textBDA", x, y); indice++; break;
                            case 5: pieces[indice] = CreateText("textWin", x, y); indice++; break;
                            case 6: pieces[indice] = CreateText("textAJEE", x, y); indice++; break;
                            case 7: pieces[indice] = CreateText("textPush", x, y); indice++; break;
                            case 8: pieces[indice] = CreateText("textKedge", x, y); indice++; break;
                            case 9: pieces[indice] = CreateText("textDefeat", x, y); indice++; break;
                            case 10: pieces[indice] = Create("Kedge", x, y); indice++; break;
                            case 11: pieces[indice] = Create("AJEE", x, y); indice++; break;
                            case 12: pieces[indice] = Create("BDA", x, y); indice++; break;
                            case 13: pieces[indice] = Create("Nono", x, y); indice++; break;
                        }
                    }
                }
                break;
            case 8:
                pieces = new GameObject[57];
                indice = 0;
                scene = new int[,] { {  8,  2,  9, 10,  0,  0,  0,  0,  0,  0, 10,  0,  0,  0,  0,  0,  0,  0},
                                     {  4,  2,  5, 10,  0,  0,  0,  0,  0,  0, 10,  0,  0,  0,  0,  0,  0,  0},
                                     { 10, 10, 10, 10,  0,  0, 11, 11, 11, 11, 10, 11, 11, 11, 11, 11, 11,  0},
                                     {  0,  0,  0,  0,  0,  0, 11,  0,  0,  0, 10,  0,  0,  0,  0,  0, 11,  0},
                                     {  0,  0,  0,  0,  0,  0, 11,  0,  0,  0, 10,  0,  0, 12,  0,  0, 11,  0},
                                     {  0,  0,  0,  0,  0,  0, 11,  0, 13,  0, 10,  0,  0,  0,  0,  0, 11,  0},
                                     {  0,  0,  1,  0,  0,  0, 11,  0,  0,  0, 10, 10, 10, 10, 10, 10, 10, 10},
                                     {  0,  0,  2,  0,  0,  0, 11,  0,  0,  0,  0,  0,  0,  0,  0,  0, 11,  0},
                                     {  0,  0,  3,  0,  0,  0, 11,  0,  0,  0,  0,  0,  6,  2,  7,  0, 11,  0},
                                     {  0,  0,  0,  0,  0,  0, 11,  0,  0,  0,  0,  0,  0,  0,  0,  0, 11,  0}};
                for (int x = 1; x <= 18; x++)
                {
                    for (int y = 1; y <= 10; y++)
                    {
                        int id = scene[10 - y, x - 1];
                        switch (id)
                        {
                            case 1: pieces[indice] = CreateText("textNono", x, y); indice++; break;
                            case 2: pieces[indice] = CreateText("textIs", x, y); indice++; break;
                            case 3: pieces[indice] = CreateText("textMe", x, y); indice++; break;
                            case 4: pieces[indice] = CreateText("textBDA", x, y); indice++; break;
                            case 5: pieces[indice] = CreateText("textWin", x, y); indice++; break;
                            case 6: pieces[indice] = CreateText("textPoulpy", x, y); indice++; break;
                            case 7: pieces[indice] = CreateText("textStop", x, y); indice++; break;
                            case 8: pieces[indice] = CreateText("textKedge", x, y); indice++; break;
                            case 9: pieces[indice] = CreateText("textDefeat", x, y); indice++; break;
                            case 10: pieces[indice] = Create("Kedge", x, y); indice++; break;
                            case 11: pieces[indice] = Create("Poulpy", x, y); indice++; break;
                            case 12: pieces[indice] = Create("BDA", x, y); indice++; break;
                            case 13: pieces[indice] = Create("Nono", x, y); indice++; break;
                        }
                    }
                }
                break;
            case 9:
                pieces = new GameObject[55];
                indice = 0;
                scene = new int[,] { {  0,  0,  0, 11,  0,  1,  2,  3,  0,  0,  0,  0,  0,  0, 10, 10, 10,  0},
                                     {  0, 13,  0, 16,  0,  0,  0,  0,  0,  0,  8,  0,  0, 10, 10, 10,  0,  0},
                                     {  0,  0,  0, 11,  0,  0,  0,  0,  0,  0,  0,  0, 10, 10, 10,  0,  0,  0},
                                     { 11, 11, 11, 11,  0,  0,  0,  0,  0,  0,  0,  0, 10, 10, 10,  0,  0,  0},
                                     {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0, 10, 10, 10,  0,  0,  0,  4},
                                     {  0,  0,  0, 14,  2, 15,  0,  0,  0,  0,  0, 10, 10, 10,  0,  0,  0,  2},
                                     {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0, 10, 10, 10,  0,  0,  0,  0,  5},
                                     {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0, 10, 10, 10,  0,  0,  0,  0,  0},
                                     {  6,  2,  7,  0,  0,  0,  0,  0,  0,  0, 10, 10, 10,  0,  0, 12,  0,  0},
                                     {  8,  2,  9,  0,  0,  0,  0,  0,  0, 10, 10, 10,  0,  0,  0,  0,  0,  0}};
                for (int x = 1; x <= 18; x++)
                {
                    for (int y = 1; y <= 10; y++)
                    {
                        int id = scene[10 - y, x - 1];
                        switch (id)
                        {
                            case 1: pieces[indice] = CreateText("textNono", x, y); indice++; break;
                            case 2: pieces[indice] = CreateText("textIs", x, y); indice++; break;
                            case 3: pieces[indice] = CreateText("textMe", x, y); indice++; break;
                            case 4: pieces[indice] = CreateText("textBDA", x, y); indice++; break;
                            case 5: pieces[indice] = CreateText("textWin", x, y); indice++; break;
                            case 6: pieces[indice] = CreateText("textPoulpy", x, y); indice++; break;
                            case 7: pieces[indice] = CreateText("textStop", x, y); indice++; break;
                            case 8: pieces[indice] = CreateText("textKedge", x, y); indice++; break;
                            case 9: pieces[indice] = CreateText("textDefeat", x, y); indice++; break;
                            case 10: pieces[indice] = Create("Kedge", x, y); indice++; break;
                            case 11: pieces[indice] = Create("Poulpy", x, y); indice++; break;
                            case 12: pieces[indice] = Create("BDA", x, y); indice++; break;
                            case 13: pieces[indice] = Create("Nono", x, y); indice++; break;
                            case 14: pieces[indice] = CreateText("textAJEE", x, y); indice++; break;
                            case 15: pieces[indice] = CreateText("textPush", x, y); indice++; break;
                            case 16: pieces[indice] = Create("AJEE", x, y); indice++; break;
                        }
                    }
                }
                break;
        }

        //il faut initialiser les listes
        for (int i = 0; i < 18; i++)
        {
            for (int j = 0; j < 10; j++)
            { positions[i, j] = new List<GameObject>(); }
        }

        //on place les blocs de texte sur le plateau
        for (int i = 0; i < pieces.Length; i++)
        {
            if (pieces[i].tag != "Piece")
            { SetPosition(pieces[i]); }
        }

        //on initialise toutes les règles
        InitMe();
        InitRules();
        DoTransformations();
        WhereToWin(LookForWin());
        WhereToLoose(LookForDefeat());
    }

    //appelé toutes les frames
    void Update()
    {
        //restart le niveau
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("Game");
        }

        //retour au menu
        if (Input.GetKeyDown(KeyCode.Escape))
        { //If you press escape.
            SceneManager.LoadScene("Menu"); //Load scene called Menu
        }

        //affiche le texte qui dit qu'on a gagné si c'est le cas et s'il est pas déjà affiché
        if (win & !textDisplayed)
        {
            GameObject obj = Instantiate(textWin, new Vector3(0, 0, -2), Quaternion.identity);
            textDisplayed = true;
        }
    }

    //créer l'objet
    public GameObject Create(string name, int x, int y)
    {
        GameObject obj = Instantiate(piece, new Vector3(0, 0, 0), Quaternion.identity);
        PlayerScript ps = obj.GetComponent<PlayerScript>();
        ps.name = name;
        ps.SetXBoard(x);
        ps.SetYBoard(y);
        ps.Activate(); //après avoir donné les paramètres au PlayerScript on l'active
        obj.GetComponent<Attributs>().Activate();
        return obj;
    }

    //créer un objet text
    public GameObject CreateText(string name, int x, int y)
    {
        GameObject obj = Instantiate(text, new Vector3(0, 0, 0), Quaternion.identity);
        PlayerScript ps = obj.GetComponent<PlayerScript>();
        TextScript ts = obj.GetComponent<TextScript>();
        ps.name = name;
        ps.SetXBoard(x);
        ps.SetYBoard(y);
        ps.Activate();
        ts.Activate();
        return obj;
    }

    //ajoute l'objet au tableau en fonction de sa position (s'il ne y est pas déjà)
    public void SetPosition(GameObject obj)
    {
        PlayerScript ps = obj.GetComponent<PlayerScript>();
        if (!positions[ps.GetXBoard() - 1, ps.GetYBoard() - 1].Contains(obj))
        { positions[ps.GetXBoard() - 1, ps.GetYBoard() - 1].Add(obj); }
    }

    //enlève un objet du tableau
    public void PositionRemove(GameObject obj, int x, int y)
    {
        positions[x - 1, y - 1].Remove(obj);
    }

    //vide une case
    public void SetPositionEmpty(int x, int y)
    {
        positions[x - 1, y - 1].Clear();
    }

    //récupère les objets qui sont à une certaine position
    public List<GameObject> GetPosition(int x, int y)
    {
        if (positionOnBoard(x, y))
        { return positions[x - 1, y - 1]; }
        else
        { return null; }
    }

    //true si la position (x,y) est sur le plateau
    public bool positionOnBoard(int x, int y)
    {
        if (x < 1 || y < 1 || x > positions.GetLength(0) || y > positions.GetLength(1))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    //true s'il y a pas d'éléments stop en (x,y)
    public bool positionOnBoardNoStop(int x, int y)
    {
        if (positionOnBoard(x, y))
        {
            bool ok = true;
            foreach (GameObject obj in positions[x - 1, y - 1])
            {
                if (obj.tag == "Piece")
                { ok &= !obj.GetComponent<Attributs>().IsStop(); }
            }
            return ok;
        }
        else
        { return false; }
    }

    //true si la position (x,y) est libre sur le plateau
    public bool positionAvailable(int x, int y)
    {
        if (positionOnBoard(x, y))
        {
            return positions[x - 1, y - 1].Count == 0;
        }
        else
        {
            return false;
        }
    }

    //appelée quand il y a du mouvement (depuis le script Move)
    public void Mouvement()
    {
        SetMe(LookForMe());
        SetNewRules(GetRules());
        DoTransformations();
        WhereToLoose(LookForDefeat());
        HasLost();
        WhereToWin(LookForWin());
        win |= HasWin();
    }

    //ME

    public List<GameObject> GetMe()
    { return Me; }

    public string WhosMe()
    { return me; }

    //change le joueur
    public void SetMe(string newMe)
    {
        //si on change de type de Me
        if (newMe != me)
        {
            me = newMe;
            foreach (GameObject oldMe in Me)
            {
                //on enlève la propriété Me aux anciens
                RemoveMe(oldMe);
            }
            //on vide la liste des Me
            Me.Clear();
            //on la rajoute aux nouveaux
            foreach (GameObject obj in Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == me).ToList())
            {
                AddMe(obj);
            }
        }
        //c'est tjs le même type de me, mais il faut vérifier qu'ils ont bien tous tjs le bon nom et s'il y en pas des nouveaux
        else
        {
            List<GameObject> toRemove = new List<GameObject>();
            //on vérifie les anciens
            foreach (GameObject alreadyMe in Me)
            {
                if (alreadyMe.name != me)
                {
                    RemoveMe(alreadyMe);
                    toRemove.Add(alreadyMe);
                }
            }
            //on retire de la liste les me qui ne sont plus des me
            foreach (GameObject obj in toRemove)
            { Me.Remove(obj); }
            //on regarde s'il y a des nouveaux
            foreach (GameObject notYetMe in Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == me).ToList())
            {
                if (!Me.Contains(notYetMe))
                { AddMe(notYetMe); }
            }
        }
    }

    //enlève les propriétés du Me à un objet
    private void RemoveMe(GameObject obj)
    {
        obj.GetComponent<Attributs>().Remove("Me");
    }

    //donne les propriétés du Me à un objet et l'ajoute à la liste
    private void AddMe(GameObject obj)
    {
        Me.Add(obj);
        obj.GetComponent<Attributs>().Set("Me");
    }

    //cherche si me est attribué à un objet
    private string LookForMe()
    {
        //repérage de où se trouve le texte Me
        GameObject tMe = GameObject.FindGameObjectWithTag("Me");
        int tX = tMe.GetComponent<PlayerScript>().GetXBoard();
        int tY = tMe.GetComponent<PlayerScript>().GetYBoard();

        //on regarde en horizontal
        List<GameObject> list2 = GetPosition(tX - 2, tY);
        List<GameObject> list1 = GetPosition(tX - 1, tY);

        if (list1 != null & list2 != null)
        {
            foreach (GameObject tNoun in list2)
            {
                foreach (GameObject tOp in list1)
                {
                    if (tNoun != null & tOp != null)
                    {
                        if (tNoun.tag == "Noun" & tOp.tag == "Operator")
                        {
                            if (tOp.name.Remove(0, 4) == "Is")
                            {
                                string name = tNoun.name.Remove(0, 4);
                                return name;
                            }
                        }
                    }
                }
            }
        }

        //on regarde en vertical
        list2 = GetPosition(tX, tY + 2);
        list1 = GetPosition(tX, tY + 1);

        if (list1 != null & list2 != null)
        {
            foreach (GameObject tNoun in list2)
            {
                foreach (GameObject tOp in list1)
                {
                    if (tNoun != null & tOp != null)
                    {
                        if (tNoun != null & tOp != null & tNoun.tag == "Noun" & tOp.tag == "Operator")
                        {
                            if (tOp.name.Remove(0, 4) == "Is")
                            {
                                string name = tNoun.name.Remove(0, 4);
                                return name;
                            }
                        }
                    }
                }
            }
        }

        return "";
    }

    private void InitMe()
    {
        me = LookForMe();
        foreach (GameObject obj in Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == me).ToList())
        {
            AddMe(obj);
        }
    }

    //WIN

    //cherche si win est attribué à un objet
    private List<string> LookForWin()
    {
        List<string> liste = new List<string>();
        //repérage de où se trouve le texte Win
        GameObject tWin = GameObject.FindGameObjectWithTag("Win");
        int tX = tWin.GetComponent<PlayerScript>().GetXBoard();
        int tY = tWin.GetComponent<PlayerScript>().GetYBoard();

        //on regarde en horizontal
        List<GameObject> list2 = GetPosition(tX - 2, tY);
        List<GameObject> list1 = GetPosition(tX - 1, tY);

        if (list1 != null & list2 != null)
        {
            foreach (GameObject tNoun in list2)
            {
                foreach (GameObject tOp in list1)
                {
                    if (tNoun != null & tOp != null)
                    {
                        if (tNoun.tag == "Noun" & tOp.tag == "Operator")
                        {
                            if (tOp.name.Remove(0, 4) == "Is")
                            {
                                string name = tNoun.name.Remove(0, 4);
                                liste.Add(name);
                            }
                        }
                    }
                }
            }
        }

        //on regarde en vertical
        list2 = GetPosition(tX, tY + 2);
        list1 = GetPosition(tX, tY + 1);

        if (list1 != null & list2 != null)
        {
            foreach (GameObject tNoun in list2)
            {
                foreach (GameObject tOp in list1)
                {
                    if (tNoun != null & tOp != null)
                    {
                        if (tNoun != null & tOp != null & tNoun.tag == "Noun" & tOp.tag == "Operator")
                        {
                            if (tOp.name.Remove(0, 4) == "Is")
                            {
                                string name = tNoun.name.Remove(0, 4);
                                liste.Add(name);
                            }
                        }
                    }
                }
            }
        }
        return liste;
    }

    //détermine les endroits où on peut gagner
    private void WhereToWin(List<string> winList)
    {
        whereToWin.Clear();
        foreach (string win in winList)
        {
            foreach (GameObject obj in Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == win).ToList())
            {
                int x = obj.GetComponent<PlayerScript>().GetXBoard();
                int y = obj.GetComponent<PlayerScript>().GetYBoard();
                whereToWin.Add(new int[] { x, y });
            }
        }
    }

    //true si le joueur est sur un objet win
    private bool HasWin()
    {
        foreach (GameObject me in Me)
        {
            foreach (int[] coordWin in whereToWin)
            {
                int x = me.GetComponent<PlayerScript>().GetXBoard();
                int y = me.GetComponent<PlayerScript>().GetYBoard();
                if (x == coordWin[0] & y == coordWin[1])
                { return true; }
            }
        }
        return false;
    }

    //LOOSE

    //cherche si defeat est attribué à un objet
    private List<string> LookForDefeat()
    {
        List<string> liste = new List<string>();
        //repérage de où se trouve le texte Defeat
        GameObject tDefeat = GameObject.FindGameObjectWithTag("Defeat");
        if (tDefeat != null)
        {
            int tX = tDefeat.GetComponent<PlayerScript>().GetXBoard();
            int tY = tDefeat.GetComponent<PlayerScript>().GetYBoard();

            //on regarde en horizontal
            List<GameObject> list2 = GetPosition(tX - 2, tY);
            List<GameObject> list1 = GetPosition(tX - 1, tY);

            if (list1 != null & list2 != null)
            {
                foreach (GameObject tNoun in list2)
                {
                    foreach (GameObject tOp in list1)
                    {
                        if (tNoun != null & tOp != null)
                        {
                            if (tNoun.tag == "Noun" & tOp.tag == "Operator")
                            {
                                if (tOp.name.Remove(0, 4) == "Is")
                                {
                                    string name = tNoun.name.Remove(0, 4);
                                    liste.Add(name);
                                }
                            }
                        }
                    }
                }
            }

            //on regarde en vertical
            list2 = GetPosition(tX, tY + 2);
            list1 = GetPosition(tX, tY + 1);

            if (list1 != null & list2 != null)
            {
                foreach (GameObject tNoun in list2)
                {
                    foreach (GameObject tOp in list1)
                    {
                        if (tNoun != null & tOp != null)
                        {
                            if (tNoun != null & tOp != null & tNoun.tag == "Noun" & tOp.tag == "Operator")
                            {
                                if (tOp.name.Remove(0, 4) == "Is")
                                {
                                    string name = tNoun.name.Remove(0, 4);
                                    liste.Add(name);
                                }
                            }
                        }
                    }
                }
            }
        }
        return liste;
    }

    //détermine les endroits où on peut gagner
    private void WhereToLoose(List<string> defeatList)
    {
        whereToLoose.Clear();

        foreach (string defeat in defeatList)
        {
            foreach (GameObject obj in Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == defeat).ToList())
            {
                int x = obj.GetComponent<PlayerScript>().GetXBoard();
                int y = obj.GetComponent<PlayerScript>().GetYBoard();
                whereToLoose.Add(new int[] { x, y });
            }
        }
    }

    //détruit les objets me qui sont sur des objets Defeat
    private void HasLost()
    {
        List<GameObject> toDestroy = new List<GameObject>();
        foreach (GameObject me in Me)
        {
            int x = me.GetComponent<PlayerScript>().GetXBoard();
            int y = me.GetComponent<PlayerScript>().GetYBoard();
            foreach (int[] coordDefeat in whereToLoose)
            {
                if (x == coordDefeat[0] & y == coordDefeat[1])
                {
                    toDestroy.Add(me);
                    //RemoveMe(me);
                }
            }
        }
        while (toDestroy.Count != 0)
        {
            GameObject obj = toDestroy[0];
            Me.Remove(obj);
            toDestroy.Remove(obj);
            obj.GetComponent<Attributs>().Reset();
            obj.GetComponent<Attributs>().Remove("Me");
            Destroy(obj);
        }
    }

    //RULES

    private void InitRules()
    {
        List<string[]> newRules = GetRules();
        foreach (string[] rule in newRules)
        {
            string noun = rule[0];
            string ope = rule[1];
            string comp = rule[2];
            string type = rule[3];

            switch (ope)
            {
                case "Is":
                    switch (type)
                    {
                        //c'est une transformation
                        case "Noun":
                            //on l'ajoute juste à la liste, peu importe si c'était là avant, il faudra qu'on regarde tout à la fin
                            transformationList.Add(new string[] { noun, comp });
                            break;
                        //c'est une règle classique
                        case "Property":
                            string[] thisRule = new string[] { noun, ope, comp };

                            //on donne l'attribut aux objets correspondant
                            rulesList.Add(thisRule);
                            foreach (GameObject obj in Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == noun).ToList())
                            {
                                obj.GetComponent<Attributs>().Set(comp);
                            }
                            break;
                    }
                    break;
            }
        }
    }

    //Renvoie la liste des règles présentes sur le board
    private List<string[]> GetRules()
    {
        List<string[]> newRules = new List<string[]>();
        foreach (GameObject objOp in Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.tag == "Operator").ToList())
        {
            int opX = objOp.GetComponent<PlayerScript>().GetXBoard();
            int opY = objOp.GetComponent<PlayerScript>().GetYBoard();

            //cas vertical
            List<GameObject> listNoun = GetPosition(opX, opY + 1);
            List<GameObject> listComp = GetPosition(opX, opY - 1);

            if (listNoun != null & listComp != null)
            {
                foreach (GameObject tNoun in listNoun)
                {
                    foreach (GameObject tComp in listComp)
                    {
                        if (tNoun != null & tComp != null)
                        {
                            string[] thisRule = new string[] { tNoun.name, objOp.name, tComp.name, tComp.tag };
                            if (!newRules.Contains(thisRule) & tComp.tag != "Me" & tComp.tag != "Piece" & tComp.tag != "Win" & tComp.tag != "Defeat" & tNoun.tag == "Noun")
                            {
                                newRules.Add(new string[] { tNoun.name.Remove(0, 4), objOp.name.Remove(0, 4), tComp.name.Remove(0, 4), tComp.tag });
                            }
                        }
                    }
                }
            }

            //cas horizontal
            listNoun = GetPosition(opX - 1, opY);
            listComp = GetPosition(opX + 1, opY);

            if (listNoun != null & listComp != null)
            {
                foreach (GameObject tNoun in listNoun)
                {
                    foreach (GameObject tComp in listComp)
                    {
                        if (tNoun != null & tComp != null)
                        {
                            string[] thisRule = new string[] { tNoun.name, objOp.name, tComp.name, tComp.tag };
                            if (!newRules.Contains(thisRule) & tComp.tag != "Me" & tComp.tag != "Piece" & tComp.tag != "Win" & tComp.tag != "Defeat" & tNoun.tag == "Noun")
                            {
                                newRules.Add(new string[] { tNoun.name.Remove(0, 4), objOp.name.Remove(0, 4), tComp.name.Remove(0, 4), tComp.tag });
                            }
                        }
                    }
                }
            }
        }
        return newRules;
    }

    //mets à jour rulesList et transformationList et ajoute les attributs qu'il faut
    private void SetNewRules(List<string[]> newRules)
    {
        //List<string[]> existingRules = rulesList.ConvertAll(new Converter<string[], string[]>(StrToStr));
        List<string[]> existingRules = rulesList.Select(v => new string[3] { v[0], v[1], v[2] }).ToList();
        rulesList.Clear();
        transformationList.Clear();

        foreach (string[] rule in newRules)
        {
            string noun = rule[0];
            string ope = rule[1];
            string comp = rule[2];
            string type = rule[3];

            switch (ope)
            {
                case "Is":
                    switch (type)
                    {
                        //c'est une transformation
                        case "Noun":
                            //on l'ajoute juste à la liste, peu importe si c'était là avant, il faudra qu'on regarde tout à la fin
                            transformationList.Add(new string[] { noun, comp });
                            break;
                        //c'est une règle classique
                        case "Property":
                            string[] thisRule = new string[] { noun, ope, comp };
                            if (Contains(existingRules, thisRule))
                            {
                                //c'était déjà là avant pas besoin de rajouter les attributs
                                Remove(existingRules, thisRule);
                                rulesList.Add(thisRule);
                            }
                            else
                            {
                                //c'était pas là avant on rajoute l'attribut
                                rulesList.Add(thisRule);
                                foreach (GameObject obj in Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == noun).ToList())
                                {
                                    obj.GetComponent<Attributs>().Set(comp);
                                }
                            }
                            break;
                    }
                    break;
            }
        }

        //faut enlever les règles qui sont plus d'actualité
        foreach (string[] rule in existingRules)
        {
            string noun = rule[0];
            string ope = rule[1];
            string comp = rule[2];

            switch (ope)
            {
                case "Is":
                    foreach (GameObject obj in Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == noun).ToList())
                    {
                        obj.GetComponent<Attributs>().Remove(comp);
                    }
                    break;
            }
        }
    }

    //on transforme les objets en d'autres
    private void DoTransformations()
    {
        List<string> aChanger = new List<string>();
        List<string> resultat = new List<string>();
        foreach (string[] thisRule in transformationList)
        {
            string noun1 = thisRule[0];
            string noun2 = thisRule[1];
            aChanger.Add(noun1);
            resultat.Add(noun2);
            //on cherche le bout de la chaîne de transformation de cet objet
            while (aChanger.Contains(noun2))
            {
                int indice = aChanger.IndexOf(noun2);
                noun2 = resultat[indice];
            }
            //maintenant on doit changer noun1 en noun2
            foreach (GameObject obj in Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == noun1).ToList())
            {
                if (Me.Contains(obj))
                { RemoveMe(obj); }
                obj.name = noun2;
                obj.GetComponent<Attributs>().Reset();
                obj.GetComponent<PlayerScript>().Activate();
                foreach (string[] thatRule in rulesList)
                {
                    if (thatRule[0] == noun2)
                    {
                        switch (thatRule[1])
                        {
                            case "Is":
                                obj.GetComponent<Attributs>().Set(thatRule[2]);
                                break;
                        }
                    }
                }
            }
        }
    }

    //permet de vérifier si le contenu d'un tableau appartient à une liste de tableau
    public bool Contains(List<string[]> liste, string[] str)
    {
        int len = str.Length;
        foreach (string[] str2 in liste)
        {
            bool ok = true;
            for (int i = 0; i < len; i++)
            { ok &= str2[i] == str[i]; }
            if (ok)
            { return true; }
        }
        return false;
    }

    //permet de retirer d'un liste un tableau qui aurait un contenu en particuiler
    public void Remove(List<string[]> liste, string[] str)
    {
        int len = str.Length;
        foreach (string[] str2 in liste)
        {
            bool ok = true;
            for (int i = 0; i < len; i++)
            { ok &= str2[i] == str[i]; }
            if (ok)
            {
                liste.Remove(str2);
                break;  //on peut faire un break car on sait qu'on a qu'un seul élément à enlever et sinon le foreach est cassé car on enlève un élément de la liste
            }
        }
    }
}
