using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static TreasureRoomRewardGenerator;

public class TreasureRewardContent : MonoBehaviour, IPointerDownHandler, IPointerClickHandler, IPointerUpHandler
{
    GameObject hoverImage;
    GameObject clickedObject;

    int count = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        clickedObject = eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject;
        if (clickedObject.name == "Index1" || clickedObject.name == "Index2" || clickedObject.name == "Index3")
        {
            for(int i = 0; i < 3; i++)
            {
                if(clickedObject.transform.GetChild(i).GetComponent<Image>().sprite != null)
                    clickedObject.transform.GetChild(i).GetComponent<Image>().color = new Color(0.7f, 0.7f, 0.7f, 1);
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (clickedObject.name)
        {
            case "Index1":
                PlayerManager.instance.AddPiece(rewardContents[0].pieceVariant, 1);
                PlayerManager.instance.AddPiece(rewardContents[0].secondPieceVariant, 1);
                BattleCardManager.BattleCardManagerInstance.initDeckIndices.Add(rewardContents[0].cardindex);
                print(rewardContents[0].cardindex);
                break;
            case "Index2":
                PlayerManager.instance.AddPiece(rewardContents[1].pieceVariant, 1);
                PlayerManager.instance.AddPiece(rewardContents[1].secondPieceVariant, 1);
                BattleCardManager.BattleCardManagerInstance.initDeckIndices.Add(rewardContents[1].cardindex);
                print(rewardContents[1].cardindex);
                break;
            case "Index3":
                PlayerManager.instance.AddPiece(rewardContents[2].pieceVariant, 1);
                PlayerManager.instance.AddPiece(rewardContents[2].secondPieceVariant, 1);
                BattleCardManager.BattleCardManagerInstance.initDeckIndices.Add(rewardContents[2].cardindex);
                print(rewardContents[2].cardindex);
                break;
        }

        print("Ä«µå ÁÜ");

        rewardContents.Clear();

        SceneChageManager.Instance.ChangeGameState(GameState.Map);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (clickedObject.name == "Index1" || clickedObject.name == "Index2" || clickedObject.name == "Index3")
        {
            for (int i = 0; i < 3; i++)
            {
                if (clickedObject.transform.GetChild(i).GetComponent<Image>().sprite != null)
                    clickedObject.transform.GetChild(i).GetComponent<Image>().color = new Color(1f, 1f, 1f, 1);
            }
        }
    }
}
