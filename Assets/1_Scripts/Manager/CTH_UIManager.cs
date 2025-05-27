using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CTH_UIManager : MonoBehaviour
{
    public static CTH_UIManager instance;
    StatusInfoUI statusInfoUI;
    DamageInfoUI damageInfoUI;
    RectTransform hpRectTransform;
    RectTransform hpDrainRectTransform;

    Monster monster;

    bool isBossDamaged = false;
    float prevWidth = 0;
    float currentWidth = 989;
    float speed = 0;

    private TextMeshProUGUI currentCostText;
    private TextMeshProUGUI maxCostText;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // 중복 제거
        }
    }

    private void Start()
    {
        monster = GameObject.Find("Monster").GetComponent<Monster>();
        hpRectTransform = GameObject.Find("Boss_Hp").GetComponent<RectTransform>();
        hpDrainRectTransform = GameObject.Find("Boss_DrainingHp").GetComponent<RectTransform>();

        Invoke("Damage", 0.1f);

        GameObject currentObj = GameObject.Find("current_cost");
        GameObject maxObj = GameObject.Find("max_cost");

        if (currentObj != null && maxObj != null)
        {
            currentCostText = currentObj.GetComponent<TextMeshProUGUI>();
            maxCostText = maxObj.GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.LogError("TMP 텍스트 오브젝트를 찾을 수 없습니다.");
        }
    }


    public void HidePlaceUI()
    {
        GameObject placeUI = GameObject.Find("PlaceUI");
        if (placeUI != null)
        {
            for (int i = 0; i < placeUI.transform.childCount; i++)
                placeUI.transform.GetChild(i).gameObject.SetActive(false);

            ShowBattleUI();
            
        }
    }

    public void ShowBattleUI()
    {
        GameObject battleUIContainer = GameObject.Find("BattleUI");
        for(int i = 0; i < battleUIContainer.transform.childCount; i++)
        {
            battleUIContainer.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void OpenBattleUIs()
    {
        GameObject battleUIContainer = GameObject.Find("BattleUI");
        for (int i = 0; i < battleUIContainer.transform.childCount; i++)
        {
            if(battleUIContainer.transform.GetChild(i).gameObject.GetComponent<ImageClickHandler>() != null)
                battleUIContainer.transform.GetChild(i).gameObject.GetComponent<ImageClickHandler>().Open();
        }

    }

    public void CloseBattleUIs()
    {
        GameObject battleUIContainer = GameObject.Find("BattleUI");
        for (int i = 0; i < battleUIContainer.transform.childCount; i++)
        {
            battleUIContainer.transform.GetChild(i).gameObject.GetComponent<ImageClickHandler>().Close();
        }

    }

    public void UpdateBattleUIs()
    {
        if(statusInfoUI == null)
            statusInfoUI = GameObject.Find("StatusInfoUI").GetComponent<StatusInfoUI>();
        if(statusInfoUI != null)
            statusInfoUI.UpdateStatusInfo();
        if (damageInfoUI == null)
            damageInfoUI = GameObject.Find("DamageInfoUI").GetComponent<DamageInfoUI>();
        if(damageInfoUI != null)
            damageInfoUI.UpdateDamageInfo();
    }

    private void Update()
    {
        if (PlayerManager.instance != null && currentCostText != null && maxCostText != null)
        {
            currentCostText.text = PlayerManager.instance.cost.ToString();
            maxCostText.text = PlayerManager.instance.maxCost.ToString();
        }
        DrainWidth();
        if(isBossDamaged)
        {
            SetWidth(hpDrainRectTransform, prevWidth);
            isBossDamaged = false;
        }
    }

    public void SetWidth(RectTransform rectTransform,float width)
    {
        // 현재 RectTransform의 크기를 가져와서 변경
        Vector2 sizeDelta = rectTransform.sizeDelta;
        sizeDelta.x = width;
        rectTransform.sizeDelta = sizeDelta;
    }

    public void DrainWidth()
    {
        if (prevWidth == 0)
            return;
        // 현재 RectTransform의 크기를 가져와서 변경
        Vector2 sizeDelta = hpDrainRectTransform.sizeDelta;
        if(sizeDelta.x >= currentWidth)
            sizeDelta.x-= Time.deltaTime*speed;
        hpDrainRectTransform.sizeDelta = sizeDelta;
    }

    public void Damage()
    {
        prevWidth = currentWidth > hpDrainRectTransform.sizeDelta.x ? currentWidth : hpDrainRectTransform.sizeDelta.x;
        currentWidth = 989 * monster.GetHpRatio();
        speed = (prevWidth - currentWidth);
        isBossDamaged = true;
        SetWidth(hpRectTransform, currentWidth);
        hpRectTransform.parent.GetChild(4).gameObject.GetComponent<TMP_Text>().text = (monster.GetHp() >= 0 ? monster.GetHp() : 0).ToString() + '/' + monster.GetMaxHp();
    }
}
