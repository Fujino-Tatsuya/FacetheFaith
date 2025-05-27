using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BouyouPiece : MonoBehaviour
{
    public Image[] UIpieces = new Image[10];
    public Image[] sort = new Image[10];

    Image numberImage;

    Image myImage;

    private Sprite[] sprites;

    // Start is called before the first frame update
    void OnEnable()
    {
        sprites = new Sprite[10];

        for (int i = 0; i < 10; i++)
        {
            sprites[i] = Resources.Load<Sprite>("TestImage/TestNumber/" + i.ToString());

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenKimuel()
    {
        gameObject.SetActive(true);
        SpriteCheck();
    }

    public void CloseKimuel()
    {
        gameObject.SetActive(false);
    }
    public void SpriteCheck()
    {
        int count = 0;

        if (PlayerManager.instance.pawnCount > 0)
        {
            sort[count] = UIpieces[0];
            UIpieces[0].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = sprites[PlayerManager.instance.pawnCount];
            count++;
        }
        if (PlayerManager.instance.upgradedPawnCount > 0)
        {
            if (UIpieces[1] != null)
            {
                sort[count] = UIpieces[1];
                UIpieces[1].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = sprites[PlayerManager.instance.upgradedPawnCount];
                count++;
            }
        }
        if (PlayerManager.instance.knightCount > 0)
        {
            sort[count] = UIpieces[2];
            UIpieces[2].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = sprites[PlayerManager.instance.knightCount];
            count++;
        }
        if (PlayerManager.instance.upgradedKnightCount > 0)
        {
            if (UIpieces[3] != null)
            {
                sort[count] = UIpieces[3];
                UIpieces[3].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = sprites[PlayerManager.instance.upgradedKnightCount];
                count++;
            }
        }
        if (PlayerManager.instance.rookCount > 0)
        {
            sort[count] = UIpieces[4];
            UIpieces[4].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = sprites[PlayerManager.instance.rookCount];
            count++;
        }
        if (PlayerManager.instance.upgradedRookCount > 0)
        {
            if (UIpieces[5] != null)
            {
                sort[count] = UIpieces[5];
                UIpieces[5].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = sprites[PlayerManager.instance.upgradedRookCount];
                count++;
            }
        }
        if (PlayerManager.instance.bishopCount > 0)
        {
            sort[count] = UIpieces[6];
            UIpieces[6].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = sprites[PlayerManager.instance.bishopCount];
            count++;
        }
        if (PlayerManager.instance.upgradedBishopCount > 0)
        {
            if (UIpieces[7] != null)
            {
                sort[count] = UIpieces[7];
                UIpieces[7].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = sprites[PlayerManager.instance.upgradedBishopCount];
                count++;
            }
        }
        if (PlayerManager.instance.queenCount > 0)
        {
            sort[count] = UIpieces[8];
            UIpieces[8].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = sprites[PlayerManager.instance.queenCount];
            count++;
        }
        if (PlayerManager.instance.upgradedQueenCount > 0)
        {
            if (UIpieces[9] != null)
            {
                sort[count] = UIpieces[9];
                UIpieces[9].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = sprites[PlayerManager.instance.upgradedQueenCount];
                count++;
            }
        }

        UpdateUIPieces(count);

        if (count>5)
        {
            int Xoffset = 125 * (5 -(count - 5));
            for(int i = 0; i < count; i++)
            {
                if (i > 4)
                {
                    SetRectPosition(sort[i].gameObject, -500 + (i-5) * 250 + Xoffset, -200);
                }
                else
                {
                    SetRectPosition(sort[i].gameObject, -500 + i * 250, 200);
                }
            }
        }
        else
        {
            int Xoffset = 125 * (5 - count);
            for (int i = 0; i < count; i++)
            {

                SetRectPosition(sort[i].gameObject, -500 + i * 250 + Xoffset, 0);
                
            }
        }


    }

    void UpdateUIPieces(int count)
    {
        for (int i = 0; i < 10; i++)
        {
            if (UIpieces[i] != null)
                UIpieces[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < count; i++)
        {
            sort[i].gameObject.SetActive(true);
        }
    }
    void SetRectPosition(GameObject gameObject, float x, float y)
    {
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(x, y);
    }

    //void SetRectPosition(GameObject gameObject, float xy, bool isX)
    //{
    //    RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
    //    if(isX)
    //    {
    //        rectTransform.anchoredPosition = new Vector2(xy, rectTransform.anchoredPosition.y);
    //    }
    //    else
    //    {
    //        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, xy);
    //    }
    //}
}
