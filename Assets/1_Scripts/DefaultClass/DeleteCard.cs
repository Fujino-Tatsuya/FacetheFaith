using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeleteCard : MonoBehaviour, IPointerDownHandler, IPointerClickHandler, IPointerUpHandler
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
        clickedObject = eventData.pointerCurrentRaycast.gameObject;

        if (clickedObject.GetComponent<Card>() != null)
        {
            if (transform.GetChild(1).childCount != 0)
            {
                hoverImage = transform.GetChild(1).GetChild(0).gameObject;
                hoverImage.GetComponent<Image>().color = new Color(0.7f, 0.7f, 0.7f, 1);
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Å¬¸¯µÊ");
        if (clickedObject != null)
            if (clickedObject.GetComponent<Card>() != null)
            {
                count++;
                BattleCardManager.BattleCardManagerInstance.initDeckIndices.Remove(clickedObject.GetComponent<Card>().cardData.index);
                
                Destroy(clickedObject);
                if (transform.GetChild(1).childCount != 0)
                {
                    hoverImage = transform.GetChild(1).GetChild(0).gameObject;
                }
                Destroy(hoverImage);

                if (count > 2)
                {
                    SceneChageManager.Instance.ChangeGameState(GameState.Map);
                }
            }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log(transform.GetChild(1).name);
        if (transform.GetChild(1).childCount != 0)
        {
            Debug.Log(transform.GetChild(1).GetChild(0).name);
            hoverImage = transform.GetChild(1).GetChild(0).gameObject;
            hoverImage.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
    }
}
