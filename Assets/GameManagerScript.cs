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
        //�ړ��\�����f
        if (number < 0 || moveTo >= map.Length) { return false; }

        //�ړ���� 2 ��������
        if (map[moveTo] == 2)
        {
            //�ǂ̕����Ɉړ����邩���Z�o
            int velocity = moveTo - moveFrom;

            //�v���C���[�̈ړ��悩��A����ɐ�� 2 ���ړ�������
            //���̈ړ������BMoveNumber
            bool success = MoveNumber(2, moveTo, moveTo + velocity);

            if (!success) { return false; }

        }

        map[moveTo] = number;
        map[moveFrom] = 0;
        return true;
    }

}
