using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StatusPiece : MonoBehaviour, IPointerDownHandler, IPointerClickHandler, IPointerUpHandler
{
    public Piece piece;
    public GameObject deathObject;
    public GameObject freezeObject;
    public GameObject weakObject;
    public GameObject shockObject;
    public GameObject distortObject;
    public GameObject knockbackObject;
    public GameObject[] blankHeart = new GameObject[5];
    public GameObject[] sort;

    public int blankHp = 0;

    public void StatusUpdate()
    {
        if (deathObject.active)
            return;
        DisableEffect();
        if (!piece.GetIsAlive())
        {
            deathObject.SetActive(true);
            for (int i = 0; i < blankHp; i++)
            {
                sort[i].transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        else
        {
            switch(piece.GetStatusEffect())
            {
                case eStatusEffectType.None:
                    break;
                case eStatusEffectType.Freeze:
                    freezeObject.SetActive(true);
                    break;
                case eStatusEffectType.Weak:
                    weakObject.SetActive(true);
                    break;
                case eStatusEffectType.Shock:
                    shockObject.SetActive(true);
                    break;
                case eStatusEffectType.Distort:
                    distortObject.SetActive(true);
                    break;
                //case eStatusEffectType.Knockback: // 넉백 스테이터스 이미지 없음
                //    knockbackObject.SetActive(true);
                //    break;
            }
            if(blankHp == 0)
            {
                blankHp = (int)(piece.GetHp());
                //Debug.Log(blankHp);
                //Debug.Log("됐어");
                sort = new GameObject[blankHp];
                for(int i = 0; i < blankHp; i++)
                {
                    sort[i] = blankHeart[i];
                    sort[i].SetActive(true);
                }
            }
            for (int i = 0; i < blankHp; i++)
            {
                if (piece.GetHp() - 1 >= i)
                    sort[i].transform.GetChild(0).gameObject.SetActive(true);
                else
                    sort[i].transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }

    void DisableEffect()
    {
        deathObject.SetActive(false);
        freezeObject.SetActive(false);
        weakObject.SetActive(false);
        shockObject.SetActive(false);
        distortObject.SetActive(false);
        //knockbackObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;

        if (clickedObject == gameObject)
        {
            BattlePieceManager.instance.DisableEffectPieces();
            BattlePieceManager.instance.EffectSelectedPiece(piece);
            PieceControlManager.instance.preventEffect = true;
            //if (BattlePieceManager.instance.GetCount(pieceVariant, upgrade) == 0)
            //    return;
            //GameObject piece = Instantiate(piecePrefab, new Vector3(0, 0, 0), transform.rotation);
            //print(pieceVariant);
            //piece.GetComponent<Piece>().SetVariant(pieceVariant);
            //PieceControlManager.instance.piece = piece.GetComponent<Piece>();
            //piece.GetComponent<Piece>().canMove = true;
            //if (upgrade)
            //    piece.GetComponent<Piece>().Upgrade();
            //myImage.color = new Color(0.7f, 0.7f, 0.7f, 1);
            //selected = true;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;

        //if (clickedObject == gameObject)
        //{
        //    Debug.Log("자식이 클릭됨: " + clickedObject.name);
        //}
        //else
        //{
        //    Debug.Log("자식 또는 다른 오브젝트 클릭됨: " + clickedObject.name);
        //}
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;

        //BattlePieceManager.instance.DisableEffectPieces();
        
        //if (!selected)
        //    return;
        //selected = false;
        ////InputManager.instance.isPlace = false;
        //myImage.color = new Color(1, 1, 1, 1);
        //BattlePieceManager.instance.SetCount(pieceVariant, upgrade, BattlePieceManager.instance.GetCount(pieceVariant, upgrade) - 1);
    }
}
