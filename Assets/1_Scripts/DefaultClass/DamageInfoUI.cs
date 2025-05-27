using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageInfoUI : MonoBehaviour
{
    public GameObject[] UIpieces = new GameObject[10];
    public GameObject[] sort = new GameObject[6];

    public void UpdateDamageInfo()
    {
        bool pawn = false;
        bool upgradedPawn = false;
        bool knight = false;
        bool upgradedKnight = false;
        bool rook = false;
        bool upgradedRook = false;
        bool bishop = false;
        bool upgradedBishop = false;
        bool queen = false;
        bool upgradedQueen = false;

        List<Piece> countPiece = BattlePieceManager.instance.pieces;
        TMP_Text textMeshPro;

        for(int i = 0; i < countPiece.Count; i++)
        {
            if (countPiece[i].GetIsAlive())
            {
                switch (countPiece[i].pieceVariant)
                {
                    case PieceVariant.Pawn:
                        if (countPiece[i].level)
                        {
                            upgradedPawn = true;
                            UIpieces[1].transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = countPiece[i].currentDamage.ToString();
                            
                        }
                        else
                        {
                            pawn = true;
                            UIpieces[0].transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = countPiece[i].currentDamage.ToString();
                        }
                        break;
                    case PieceVariant.Knight:
                        if (countPiece[i].level)
                        {
                            upgradedKnight = true;
                            UIpieces[3].transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = countPiece[i].currentDamage.ToString();
                        }
                        else
                        {
                            knight = true;
                            UIpieces[2].transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = countPiece[i].currentDamage.ToString();
                        }
                        break;
                    case PieceVariant.Rook:
                        if (countPiece[i].level)
                        {
                            upgradedRook = true;
                            UIpieces[5].transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = countPiece[i].currentDamage.ToString();
                        }
                        else
                        {
                            rook = true;
                            UIpieces[4].transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = countPiece[i].currentDamage.ToString();
                        }
                        break;
                    case PieceVariant.Bishop:
                        if (countPiece[i].level)
                        {
                            upgradedBishop = true;
                            UIpieces[7].transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = countPiece[i].currentDamage.ToString();
                        }
                        else
                        {
                            bishop = true;
                            UIpieces[6].transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = countPiece[i].currentDamage.ToString();
                        }
                        break;
                    case PieceVariant.Queen:
                        if (countPiece[i].level)
                        {
                            upgradedQueen = true;
                            UIpieces[9].transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = countPiece[i].currentDamage.ToString();
                        }
                        else
                        {
                            queen = true;
                            UIpieces[8].transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = countPiece[i].currentDamage.ToString();
                        }
                        break;

                }
            }
        }

        int count = 0;

        if(pawn)
        {
            sort[count] = UIpieces[0];
            count++;
        }
        if(upgradedPawn)
        {
            sort[count] = UIpieces[1];
            count++;
        }
        if(knight)
        {
            sort[count] = UIpieces[2];
            count++;
        }
        if (upgradedKnight)
        {
            sort[count] = UIpieces[3];
            count++;
        }
        if (rook)
        {
            sort[count] = UIpieces[4];
            count++;
        }
        if (upgradedRook)
        {
            sort[count] = UIpieces[5];
            count++;
        }
        if (bishop)
        {
            sort[count] = UIpieces[6];
            count++;
        }
        if (upgradedBishop)
        {
            sort[count] = UIpieces[7];
            count++;
        }
        if (queen)
        {
            sort[count] = UIpieces[8];
            count++;
        }
        if (upgradedQueen)
        {
            sort[count] = UIpieces[9];
            count++;
        }
        UpdateUIPieces(count);

        switch (count)
        {
            case 0:
                break;
            case 1:
                SetRectPosition(sort[0], 0, 0);
                break;
            case 2:
                SetRectPosition(sort[0], -56.125f, 0);
                SetRectPosition(sort[1], 56.125f, 0);
                break;
            case 3:
                SetRectPosition(sort[0], -112.5f, 0);
                SetRectPosition(sort[1], 0, 0);
                SetRectPosition(sort[2], 112.5f, 0);
                break;
            case 4:
                SetRectPosition(sort[0], -112.5f, 100);
                SetRectPosition(sort[1], 0, 100);
                SetRectPosition(sort[2], 112.5f, 100);
                SetRectPosition(sort[3], 0, -100);
                break;
            case 5:
                SetRectPosition(sort[0], -112.5f, 100);
                SetRectPosition(sort[1], 0, 100);
                SetRectPosition(sort[2], 112.5f, 100);
                SetRectPosition(sort[3], -56.125f, -100);
                SetRectPosition(sort[4], 56.125f, -100);
                break;
            case 6:
                SetRectPosition(sort[0], -112.5f, 100);
                SetRectPosition(sort[1], 0, 100);
                SetRectPosition(sort[2], 112.5f, 100);
                SetRectPosition(sort[3], -112.5f, -100);
                SetRectPosition(sort[4], 0, -100);
                SetRectPosition(sort[5], 112.5f, -100);
                break;
        }
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

    void SetRectPosition(GameObject gameObject, float x, float y)
    {
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(x, y);
    }
}
