using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    int[] map = { 0, 2, 1, 0, 2, 0, 2, 0, 1 };
    void Start()
    {

        //
        //Debug.Log("Hello World");


        string debugTXT = "";

        for (int i = 0; i < map.Length; i++)
        {
            //Debug.Log(map[i]);
            debugTXT += map[i].ToString() + ",";
        }

        Debug.Log(debugTXT);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            int playerIndex = GetPlayerIndex();

            MoveNumber(1, playerIndex, playerIndex + 1);

            PrintArray();
        }

    }

    private void PrintArray()
    {
        string debugText = "";

        for (int i = 0; i < map.Length; i++)
        {
            debugText += map[i].ToString() + ",";
        }
        Debug.Log(debugText);

    }

    private int GetPlayerIndex()
    {
        for (int i = 0; i < map.Length; i++)
        {
            if (map[i] == 1)
            {
                return i;
            }
        }
        return -1;
    }

    bool MoveNumber(int number, int moveFrom, int moveTo)
    {
        //移動可能か判断
        if (number < 0 || moveTo >= map.Length) { return false; }

        //移動先に 2 がいたら
        if (map[moveTo] == 2)
        {
            //どの方向に移動するかを算出
            int velocity = moveTo - moveFrom;

            //プレイヤーの移動先から、さらに先へ 2 を移動させる
            //箱の移動処理。MoveNumber
            bool success = MoveNumber(2, moveTo, moveTo + velocity);

            if (!success) { return false; }

        }

        map[moveTo] = number;
        map[moveFrom] = 0;
        return true;
    }

}
