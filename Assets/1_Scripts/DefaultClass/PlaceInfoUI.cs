using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceInfoUI : MonoBehaviour
{
    public GameObject[] UIpieces = new GameObject[10];
    public GameObject[] sort = new GameObject[10];

    void Start()
    {
        int count = 0;

        if (PlayerManager.instance.pawnCount > 0)
        { 
            sort[count] = UIpieces[0];
            count++;
        }
        if (PlayerManager.instance.upgradedPawnCount > 0)
        {
            sort[count] = UIpieces[1];
            count++;
        }
        if (PlayerManager.instance.knightCount > 0)
        {
            sort[count] = UIpieces[2];
            count++;
        }
        if (PlayerManager.instance.upgradedKnightCount > 0)
        {
            sort[count] = UIpieces[3];
            count++;
        }
        if (PlayerManager.instance.rookCount > 0)
        {
            sort[count] = UIpieces[4];
            count++;
        }
        if (PlayerManager.instance.upgradedRookCount > 0)
        {
            sort[count] = UIpieces[5];
            count++;
        }
        if (PlayerManager.instance.bishopCount > 0)
        {
            sort[count] = UIpieces[6];
            count++;
        }
        if (PlayerManager.instance.upgradedBishopCount > 0)
        {
            sort[count] = UIpieces[7];
            count++;
        }
        if (PlayerManager.instance.queenCount > 0)
        {
            sort[count] = UIpieces[8];
            count++;
        }
        if (PlayerManager.instance.upgradedQueenCount > 0)
        {
            sort[count] = UIpieces[9];
            count++;
        }


        UpdateUIPieces(count);

        GridLayoutGroup gridLayoutGroup = GetComponent<GridLayoutGroup>();
        gridLayoutGroup.padding.top = -((count-1) / 2 - 4) * 80;

        //switch (count)
        //{
        //    case 0:
        //        break;
        //    case 1:
        //        SetRectPosition(sort[0], 0, 0);
        //        break;
        //    case 2:
        //        SetRectPosition(sort[0], -75, 0);
        //        SetRectPosition(sort[1], 75, 0);
        //        break;
        //    case 3:
        //        SetRectPosition(sort[0], -150, 0);
        //        SetRectPosition(sort[1], 0, 0);
        //        SetRectPosition(sort[2], 150, 0);
        //        break;
        //    case 4:
        //        SetRectPosition(sort[0], -150, 130);
        //        SetRectPosition(sort[1], 0, 130);
        //        SetRectPosition(sort[2], 150, 130);
        //        SetRectPosition(sort[3], 0, -130);
        //        break;
        //    case 5:
        //        SetRectPosition(sort[0], -150, 130);
        //        SetRectPosition(sort[1], 0, 130);
        //        SetRectPosition(sort[2], 150, 130);
        //        SetRectPosition(sort[3], -75, -130);
        //        SetRectPosition(sort[4], 75, -130);
        //        break;
        //    case 6:
        //        SetRectPosition(sort[0], -150, 130);
        //        SetRectPosition(sort[1], 0, 130);
        //        SetRectPosition(sort[2], 150, 130);
        //        SetRectPosition(sort[3], -150, -130);
        //        SetRectPosition(sort[4], 0, -130);
        //        SetRectPosition(sort[5], 150, -130);
        //        break;
        //}
        //for(int i = 0; i < count; i++)
        //{
        //    int x = 0;
        //    int y = ((i/2)-2);
        //    SetRectPosition(sort[i], x, y);
        //}
    }

    void UpdateUIPieces(int count)
    {
        for (int i = 0; i < 10; i++)
        {
            UIpieces[i].SetActive(false);
        }
        for (int i = 0; i < count; i++)
        {
            sort[i].SetActive(true);
        }
    }

    //void SetRectPosition(GameObject gameObject, float x, float y)
    //{
    //    RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
    //    rectTransform.anchoredPosition = new Vector2(x, y);
    //}
}
