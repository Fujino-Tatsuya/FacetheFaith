using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public enum CardZone
{
    MapDeck,
    Deck,
    Grave
}

public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public CardData cardData;
    public CardZone cardZone;

    public float scaleFactor = 1.25f; // 마우스 오버 시 확대할 비율
    private Vector3 originalScale;

    public GameObject cardPrefab;

    public static GameObject currentCard;
    private static GameObject currentHover;

    static public GameObject GetCurrentHover()
    {
        return currentHover;
    }

    private void Start()
    {
        originalScale = GetComponent<RectTransform>().localScale;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        // 마우스가 오브젝트 위로 올라왔을 때
        currentCard = gameObject;

        Transform hoverLayer = null;

        switch(cardZone)
        {
            case CardZone.MapDeck:
                if(YSUIManager.MapDeckHoverLayer != null)
                {
                    hoverLayer = YSUIManager.MapDeckHoverLayer.transform;
                }
                break;
            case CardZone.Deck:
                if(YSUIManager.DeckHoverLayer != null)
                {
                    hoverLayer = YSUIManager.DeckHoverLayer.transform;
                }
                break;
            case CardZone.Grave:
                if (YSUIManager.GraveHoverLayer != null)
                {
                    hoverLayer = YSUIManager.GraveHoverLayer.transform;
                }
                break;
            default:
                break;
        }

        if (hoverLayer != null)
        {
            currentHover = Instantiate(cardPrefab, hoverLayer);
            currentHover.GetComponent<CanvasGroup>().blocksRaycasts = false;
            currentHover.GetComponent<RectTransform>().sizeDelta = new Vector2(270, 360);

            currentHover.GetComponent<RectTransform>().localScale = originalScale * scaleFactor;

            currentHover.transform.position = transform.position;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(currentHover);
        currentHover = null;
    }

    public void SetData(CardData data)
    {
        cardData = data;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(GameManager.instance.currentState == GameState.Stage_Battle || GameManager.instance.currentState == GameState.EliteBattle || GameManager.instance.currentState == GameState.BossBattle)
        {
            BattleCardManager.BattleCardManagerInstance.OnBeginDragEvent(gameObject);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (GameManager.instance.currentState == GameState.Stage_Battle || GameManager.instance.currentState == GameState.EliteBattle || GameManager.instance.currentState == GameState.BossBattle)
        {
            BattleCardManager.BattleCardManagerInstance.OnDragEvent(gameObject);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (GameManager.instance.currentState == GameState.Stage_Battle || GameManager.instance.currentState == GameState.EliteBattle || GameManager.instance.currentState == GameState.BossBattle)
        {
            BattleCardManager.BattleCardManagerInstance.OnEndDragEvent(gameObject);
        }
    }
}

//카드를 내면
//hand 에서 몇번째인지랑 > 
//카드 인덱스 > 