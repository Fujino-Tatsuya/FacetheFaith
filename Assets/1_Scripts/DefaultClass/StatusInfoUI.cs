using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class StatusInfoUI : MonoBehaviour
{
    public GameObject prefab;
    public Sprite[] UIs = new Sprite[10];
    public GameObject[] sort = new GameObject[6];

    public int count = 0;

    void Start()
    {
        count = 0;
        GameObject pieceObject;
        Image image;
        List<Piece> countPiece = BattlePieceManager.instance.pieces;

        for (int i = 0; i < countPiece.Count; i++)
        {
            pieceObject = Instantiate(prefab, transform.position, transform.rotation);
            pieceObject.transform.SetParent(transform);
            pieceObject.GetComponent<StatusPiece>().piece = countPiece[i];
            image = pieceObject.GetComponent<Image>();
            switch (countPiece[i].pieceVariant)
            {
                case PieceVariant.Pawn:
                    if (countPiece[i].level)
                        image.sprite = UIs[1];
                    else
                        image.sprite = UIs[0];
                    break;
                case PieceVariant.Knight:
                    if (countPiece[i].level)
                        image.sprite = UIs[3];
                    else
                        image.sprite = UIs[2];
                    break;
                case PieceVariant.Rook:
                    if (countPiece[i].level)
                        image.sprite = UIs[5];
                    else
                        image.sprite = UIs[4];
                    break;
                case PieceVariant.Bishop:
                    if (countPiece[i].level)
                        image.sprite = UIs[7];
                    else
                        image.sprite = UIs[6];
                    break;
                case PieceVariant.Queen:
                    if (countPiece[i].level)
                        image.sprite = UIs[9];
                    else
                        image.sprite = UIs[8];
                    break;

            }// 기물 6개 초과 배치 방지코드 짜야됨
            sort[count++] = pieceObject;
        }
        ReSortStatus();
        RePositionStatus();
        UpdateStatusInfo();
    }
    public void UpdateStatusInfo()
    {
        for (int i = 0; i < sort.Length; i++)
        {
            if (sort[i] != null)
                sort[i].GetComponent<StatusPiece>().StatusUpdate();
        }
    }

    void ReSortStatus()
    {
        int[] sortHelper = new int[count];
        for(int i = 0; i < count; i++)
        {
            Piece tempPiece = sort[i].GetComponent<StatusPiece>().piece;

            switch (tempPiece.pieceVariant)
            {
                case PieceVariant.Pawn:
                    sortHelper[i] = 0;
                    break;
                case PieceVariant.Knight:
                    sortHelper[i] = 2;
                    break;
                case PieceVariant.Rook:
                    sortHelper[i] = 4;
                    break;
                case PieceVariant.Bishop:
                    sortHelper[i] = 6;
                    break;
                case PieceVariant.Queen:
                    sortHelper[i] = 8;
                    break;
            }
            if (tempPiece.level)
                sortHelper[i] += 1;
        }

        for(int i = 0; i < count-1; i++)
        {
            for(int j = 0; j < count-1; j++)
            {
                if (sortHelper[j] > sortHelper[j + 1])
                {
                    int tempInt = sortHelper[j];
                    sortHelper[j] = sortHelper[j + 1];
                    sortHelper[j + 1] = tempInt;
                    GameObject tempObject = sort[j];
                    sort[j] = sort[j + 1];
                    sort[j + 1] = tempObject;
                }
            }
        }
    }

    //void RePositionStatus() // 태현이 코드 : 가로 3, 세로 2
    //{
    //    switch (count)
    //    {
    //        case 0:
    //            break;
    //        case 1:
    //            SetRectPosition(sort[0], 0, 0);
    //            break;
    //        case 2:
    //            SetRectPosition(sort[0], -75, 0);
    //            SetRectPosition(sort[1], 75, 0);
    //            break;
    //        case 3:
    //            SetRectPosition(sort[0], -150, 0);
    //            SetRectPosition(sort[1], 0, 0);
    //            SetRectPosition(sort[2], 150, 0);
    //            break;
    //        case 4:
    //            SetRectPosition(sort[0], -150, 130);
    //            SetRectPosition(sort[1], 0, 130);
    //            SetRectPosition(sort[2], 150, 130);
    //            SetRectPosition(sort[3], 0, -130);
    //            break;
    //        case 5:
    //            SetRectPosition(sort[0], -150, 130);
    //            SetRectPosition(sort[1], 0, 130);
    //            SetRectPosition(sort[2], 150, 130);
    //            SetRectPosition(sort[3], -75, -130);
    //            SetRectPosition(sort[4], 75, -130);
    //            break;
    //        case 6:
    //            SetRectPosition(sort[0], -150, 130);
    //            SetRectPosition(sort[1], 0, 130);
    //            SetRectPosition(sort[2], 150, 130);
    //            SetRectPosition(sort[3], -150, -130);
    //            SetRectPosition(sort[4], 0, -130);
    //            SetRectPosition(sort[5], 150, -130);
    //            break;
    //    }
    //}

    void RePositionStatus()
    {
        switch (count)
        {
            case 0:
                break;

            case 1:
                SetRectPosition(sort[0], -10, 0);
                break;

            case 2:
                SetRectPosition(sort[0], -55, 0);
                SetRectPosition(sort[1], 35, 0);
                break;

            case 3:
                SetRectPosition(sort[0], -55, 220);
                SetRectPosition(sort[1], 35, 220);
                SetRectPosition(sort[2], -10, 0);
                break;

            case 4:
                SetRectPosition(sort[0], -55, 220);
                SetRectPosition(sort[1], 35, 220);
                SetRectPosition(sort[2], -55, 0);
                SetRectPosition(sort[3], 35, 0);
                break;

            case 5:
                SetRectPosition(sort[0], -55, 220);
                SetRectPosition(sort[1], 35, 220);
                SetRectPosition(sort[2], -55, 0);
                SetRectPosition(sort[3], 35, 0);
                SetRectPosition(sort[4], -10, -220);
                break;

            case 6:
                SetRectPosition(sort[0], -55, 220);
                SetRectPosition(sort[1], 35, 220);
                SetRectPosition(sort[2], -55, 0);
                SetRectPosition(sort[3], 35, 0);
                SetRectPosition(sort[4], -55, -220);
                SetRectPosition(sort[5], 35, -220);
                break;
        }
    }











    //void UpdateUIPieces(int count)
    //{
    //    for (int i = 0; i < 10; i++)
    //    {
    //        UIpieces[i].SetActive(false);
    //    }
    //    for (int i = 0; i < count; i++)
    //    {
    //        sort[i].SetActive(true);
    //    }
    //}

    void SetRectPosition(GameObject gameObject, float x, float y)
    {
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(x, y);
    }
}
