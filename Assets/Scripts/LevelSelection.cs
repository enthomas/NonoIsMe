using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    static public int index = 1;
    int nbLevels = 9;
    int nbColumns = 2;
    float stepH;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = transform.position;
        stepH = GameObject.FindGameObjectWithTag("Level1").transform.position.x - position.x;
        Vector3 currentLevelPosition = GameObject.FindGameObjectWithTag("Level" + index).transform.position;
        position.x = currentLevelPosition.x - stepH;
        position.y = currentLevelPosition.y;
        transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (index + nbColumns <= nbLevels & index + nbColumns <= nbLevels)
            {
                index += nbColumns;
                Vector3 position = transform.position;
                Vector3 currentLevelPosition = GameObject.FindGameObjectWithTag("Level" + index).transform.position;
                position.x = currentLevelPosition.x - stepH;
                position.y = currentLevelPosition.y;
                transform.position = position;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (index - nbColumns > 0)
            {
                index -= nbColumns;
                Vector3 position = transform.position;
                Vector3 currentLevelPosition = GameObject.FindGameObjectWithTag("Level" + index).transform.position;
                position.x = currentLevelPosition.x - stepH;
                position.y = currentLevelPosition.y;
                transform.position = position;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (index % nbColumns != 0 & index + 1 <= nbLevels)
            {
                index++;
                Vector3 position = transform.position;
                Vector3 currentLevelPosition = GameObject.FindGameObjectWithTag("Level" + index).transform.position;
                position.x = currentLevelPosition.x - stepH;
                position.y = currentLevelPosition.y;
                transform.position = position;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (index % nbColumns != 1)
            {
                index--;
                Vector3 position = transform.position;
                Vector3 currentLevelPosition = GameObject.FindGameObjectWithTag("Level" + index).transform.position;
                position.x = currentLevelPosition.x - stepH;
                position.y = currentLevelPosition.y;
                transform.position = position;
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Game");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        { Application.Quit(); }
    }
}
