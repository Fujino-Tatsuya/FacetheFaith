using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class YSUIManager : MonoBehaviour
{
    public static YSUIManager Instance;

    public GameObject canvas;
    public GameObject MapDeckUI;
    public GameObject DeckUI;
    public GameObject GraveUI;
    public GameObject MapDeckContent;
    public GameObject DeckContent;
    public GameObject GraveContent;

    public ScrollRect MapScrollRect;
    public ScrollRect DeckScrollRect;
    public ScrollRect GraveScrollRect;

    public static GameObject MapDeckHoverLayer;
    public static GameObject DeckHoverLayer;
    public static GameObject GraveHoverLayer;

    public bool isPopupOpen = false;

    public GameObject cardPrefab;
    public Sprite[] sprites;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void LoadDeck()
    {
        if (GameManager.instance.currentState == GameState.Map || GameManager.instance.currentState == GameState.Stage_Rest)
        {
            foreach (CardData data in BattleCardManager.BattleCardManagerInstance.GetDeckData())
            {
                GameObject currentCard = Instantiate(cardPrefab);
                currentCard.GetComponent<Card>().SetData(data);
                currentCard.transform.SetParent(MapDeckContent.transform);
                currentCard.GetComponent<Card>().cardZone = CardZone.MapDeck;

                string path = data.image;
                currentCard.GetComponent<Image>().sprite = Resources.Load<Sprite>(path);
                currentCard.SetActive(true);
            }
        }
        else if (GameManager.instance.currentState == GameState.Stage_Battle
           || GameManager.instance.currentState == GameState.EliteBattle
           || GameManager.instance.currentState == GameState.BossBattle)
        {
            foreach (GameObject card in BattleCardManager.BattleCardManagerInstance.GetDeckObject())
            { 
                GameObject currentCard = GameObject.Instantiate(card);
                currentCard.GetComponent<Card>().cardZone = CardZone.Deck;
                currentCard.transform.SetParent(DeckContent.transform);
                currentCard.SetActive(true);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (MapScrollRect != null)
        {
            MapScrollRect.onValueChanged.AddListener(valueChanged);
            MapDeckHoverLayer = MapScrollRect.transform.Find("Viewport").transform.Find("HoverLayer").gameObject;
        }
        if(DeckScrollRect != null && GraveScrollRect != null)
        {
            DeckScrollRect.onValueChanged.AddListener(valueChanged);
            GraveScrollRect.onValueChanged.AddListener(valueChanged);

            DeckHoverLayer = DeckScrollRect.transform.Find("Viewport").transform.Find("HoverLayer").gameObject;
            GraveHoverLayer = GraveScrollRect.transform.Find("Viewport").transform.Find("HoverLayer").gameObject;
        }

        canvas = GameObject.Find("Canvas_Overlay");
        if (GameManager.instance.currentState == GameState.Map || GameManager.instance.currentState == GameState.Stage_Rest)
        {
            MapDeckContent = MapScrollRect.transform.Find("Viewport").Find("MapDeckContent").gameObject;
        }
        else if (GameManager.instance.currentState == GameState.Stage_Battle
            || GameManager.instance.currentState == GameState.EliteBattle
            || GameManager.instance.currentState == GameState.BossBattle)
        {
            DeckContent = DeckScrollRect.transform.Find("Viewport").Find("DeckContent").gameObject;
            GraveContent = GraveScrollRect.transform.Find("Viewport").Find("GraveContent").gameObject;
        }


        LoadDeck();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClickBack();
        }
    }

    public void OnMapDeckClicked()
    {
        if(GameManager.instance.currentState == GameState.Map || GameManager.instance.currentState == GameState.Stage_Rest)
        {
            MapDeckUI.SetActive(true);
        }
    }

    public void OnDeckClicked()
    {
        if (GameManager.instance.currentState == GameState.Stage_Battle
             || GameManager.instance.currentState == GameState.EliteBattle
             || GameManager.instance.currentState == GameState.BossBattle)
        {
            DeckUI.SetActive(true);
            isPopupOpen = true;
        }
    }

    public void OnGraveClicked()
    {
        if (GameManager.instance.currentState == GameState.Stage_Battle
            || GameManager.instance.currentState == GameState.EliteBattle
            || GameManager.instance.currentState == GameState.BossBattle)
        {
            GraveUI.SetActive(true);
            isPopupOpen = true;
        }
    }

    public void ClearChildren(GameObject parent)
    {
        foreach (Transform child in parent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void UpdateCard()
    {
        ClearChildren(DeckContent);
        foreach (GameObject card in BattleCardManager.BattleCardManagerInstance.GetDeckObject())
        {
            GameObject currentCard = GameObject.Instantiate(card);
            currentCard.GetComponent<Card>().cardZone = CardZone.Deck;
            currentCard.transform.SetParent(DeckContent.transform);
            currentCard.transform.SetSiblingIndex(currentCard.GetComponent<Card>().cardData.index);
            currentCard.SetActive(true);
        }
        ClearChildren(GraveContent);
        foreach (GameObject card in BattleCardManager.BattleCardManagerInstance.GetGraveObject())
        {
            GameObject currentCard = GameObject.Instantiate(card);
            currentCard.GetComponent<Card>().cardZone = CardZone.Grave;
            currentCard.transform.rotation = Quaternion.identity;
            currentCard.transform.SetParent(GraveContent.transform);
            currentCard.transform.SetSiblingIndex(currentCard.GetComponent<Card>().cardData.index);
            currentCard.SetActive(true);
        }
    }

    void valueChanged(Vector2 scrollPos)
    {
        if (Card.GetCurrentHover() != null && Card.currentCard != null)
        {
            Card.GetCurrentHover().transform.position = Card.currentCard.transform.position;
        }
    }

    public void ClickBack()
    {
        if (GameManager.instance.currentState == GameState.Map || GameManager.instance.currentState == GameState.Stage_Rest)
        {
            MapDeckUI.gameObject.SetActive(false);
        }
        else if (GameManager.instance.currentState == GameState.Stage_Battle
            || GameManager.instance.currentState == GameState.EliteBattle
            || GameManager.instance.currentState == GameState.BossBattle)
        {
            DeckUI.gameObject.SetActive(false);
            GraveUI.gameObject.SetActive(false);
            isPopupOpen = false;
        }
    }
}
