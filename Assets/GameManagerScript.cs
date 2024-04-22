using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    public GameObject playerPrefab;

    GameObject obj;
    //obj.tag;
    // Start is called before the first frame update
    

    GameObject[,] field;

    void Start()
    {

       int[,] map = {
            { 0,0,0,0,0 },
            { 1,0,0,0,0 },
            { 0,0,0,0,0 } ,
    };

        field = new GameObject[map.GetLength(0), map.GetLength(1)];

        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == 1)
                {
                    field[y,x]=Instantiate(playerPrefab,new Vector3(x,map.GetLength(0)-y,0),Quaternion.identity);

                    // GameObject instance = Instantiate(playerPrefab, new Vector3(x, map.GetLength(0)-1-y, 0.0f), Quaternion.identity);
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

    private Vector2Int GetPlayerIndex()
    {
        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
                if (field[y, x] == null)
                {
                    return new Vector2Int(y,x);
                }
            }
        }
        return new Vector2Int(-1,-1);
    }

    //bool MoveNumber(int number, int moveFrom, int moveTo)
    //{
    //    //移動可能か判断
    //    if (number < 0 || moveTo >= map.Length) { return false; }

    //    //移動先に 2 がいたら
    //    if (map[moveTo] == 2)
    //    {
    //        //どの方向に移動するかを算出
    //        int velocity = moveTo - moveFrom;

    //        //プレイヤーの移動先から、さらに先へ 2 を移動させる
    //        //箱の移動処理。MoveNumber
    //        bool success = MoveNumber(2, moveTo, moveTo + velocity);

    //        if (!success) { return false; }

    //    }

    //    map[moveTo] = number;
    //    map[moveFrom] = 0;
    //    return true;
    //}

}
