using System.Collections;
using System.Collections.Generic;
//using System.Runtime.CompilerServices;
//using UnityEditor.Compilation;
using Unity.VisualScripting;
using UnityEngine;


public class GameManagerScript : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject boxPrefab;
    public GameObject goalPrefab;

    public GameObject clearText;


    int[,] map;

   

    GameObject obj;
    //obj.tag;
    // Start is called before the first frame update


    GameObject[,] field;

    void Start()
    {

        map = new int[,]{
            { 0,0,0,0,0 },
            { 0,0,1,0,0 },
            { 3,2,0,2,3 },
            { 0,0,0,0,0 },
            { 0,0,0,0,0 } 
        };

        field = new GameObject[map.GetLength(0), map.GetLength(1)];

        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == 1)
                {
                    field[y, x] = Instantiate(playerPrefab, new Vector3(x, map.GetLength(0) - y, 0), Quaternion.identity);

                    // GameObject instance = Instantiate(playerPrefab, new Vector3(x, map.GetLength(0)-1-y, 0.0f), Quaternion.identity);
                }

                if (map[y, x] == 2)
                {
                    field[y, x] = Instantiate(boxPrefab, new Vector3(x, map.GetLength(0) - y, 0), Quaternion.identity);
                }

               

            }
        }

        string debugText = "";
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {


                debugText += map[y, x].ToString() + ",";
            }
            debugText += "\n";
        }

        Debug.Log(debugText);

        Screen.SetResolution(1280, 720, false);
       

        //
        //Debug.Log("Hello World");


        //string debugTXT = "";

        //for (int i = 0; i < map.Length; i++)
        //{
        //    //Debug.Log(map[i]);
        //    debugTXT += map[i].ToString() + ",";
        //}

        //Debug.Log(debugTXT);
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            Vector2Int playerIndex = GetPlayerIndex();

            MoveNumber(playerIndex, playerIndex + new Vector2Int(1, 0));

            if (IsCleard())
            {
                //Debug.Log("Clear!");

                clearText.SetActive(true);
            }

            

            //    int playerIndex = GetPlayerIndex();

            //    MoveNumber(1, playerIndex, playerIndex + 1);

            //    PrintArray();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            Vector2Int playerIndex = GetPlayerIndex();

            MoveNumber(playerIndex, playerIndex + new Vector2Int(-1, 0));

            if (IsCleard())
            {
                // Debug.Log("Clear!");

                clearText.SetActive(true);
            }

            //    int playerIndex = GetPlayerIndex();

            //    MoveNumber(1, playerIndex, playerIndex + 1);

            //    PrintArray();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            Vector2Int playerIndex = GetPlayerIndex();

            MoveNumber(playerIndex, playerIndex + new Vector2Int(0, -1));

            if (IsCleard())
            {
                //Debug.Log("Clear!");

                clearText.SetActive(true);
            }

            //    int playerIndex = GetPlayerIndex();

            //    MoveNumber(1, playerIndex, playerIndex + 1);

            //    PrintArray();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            Vector2Int playerIndex = GetPlayerIndex();

            MoveNumber(playerIndex, playerIndex + new Vector2Int(0, 1));

            if (IsCleard())
            {
                //Debug.Log("Clear!");

                clearText.SetActive(true);
            }

            //    int playerIndex = GetPlayerIndex();

            //    MoveNumber(1, playerIndex, playerIndex + 1);

            //    PrintArray();
        }

    }

    //private void PrintArray()
    //{
    //    string debugText = "";

    //    for (int i = 0; i < map.Length; i++)
    //    {
    //        debugText += map[i].ToString() + ",";
    //    }
    //    Debug.Log(debugText);

    //}

    Vector2Int GetPlayerIndex()
    {
        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
                if (field[y, x] == null)
                {
                    continue;
                }

                if (field[y, x].tag == "Player")
                {
                    return new Vector2Int(x, y);
                }

            }
        }

        return new Vector2Int(-1, -1);
    }

    bool MoveNumber(Vector2Int moveFrom, Vector2Int moveTo)
    {
        //à⁄ìÆâ¬î\Ç©îªíf
        if (moveTo.y < 0 || moveTo.y >= field.GetLength(0)) { return false; }
        if (moveTo.x < 0 || moveTo.x >= field.GetLength(1)) { return false; }

        //à⁄ìÆêÊÇ… 2 Ç™Ç¢ÇΩÇÁ

        if (field[moveTo.y, moveTo.x] != null && field[moveTo.y, moveTo.x].tag == "Box")
        {
            Vector2Int velocity = moveTo - moveFrom;
            bool success = MoveNumber(moveTo, moveTo + velocity);
            if (!success) { return false; }
        }

        field[moveTo.y, moveTo.x] = field[moveFrom.y, moveFrom.x];
        //field[moveFrom.y, moveFrom.x].transform.position = new Vector3(moveTo.x, field.GetLength(0) - moveTo.y, 0);

        Vector3 moveToPosition = new Vector3(moveTo.x, map.GetLength(0) - moveTo.y, 0);

        field[moveFrom.y, moveFrom.x].GetComponent<Move>().MoveTo(moveToPosition);
        field[moveFrom.y, moveFrom.x] = null;

        return true;
    }

    bool IsCleard()
    {
        List<Vector2Int> goals = new List<Vector2Int>();

        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {

                if (map[y, x] == 3)
                {
                    goals.Add(new Vector2Int(x, y));
                }

            }
        }

        for (int i = 0; i < goals.Count; i++)
        {
            GameObject f = field[goals[i].y, goals[i].x];
            if (f == null || f.tag != "Box")
            {
                return false;
            }
        }

        return true;
    }

  


}
