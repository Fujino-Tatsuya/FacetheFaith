using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JH_UIManager : MonoBehaviour
{

    public static JH_UIManager Instance { get; private set; }


    [Header("팝업 참조")]
    public PopupWindow optionPopup;
    public PopupWindow deckPopup;
    public PopupWindow chessPopup;
    public PopupWindow settingPopup;
    public PopupWindow creditPopup;
    public PopupWindow quitGameCheckPopup;
    public GameObject upgradePopup;

    [Header("아이콘 & 문구")]
    [SerializeField] private Image stageIcon;
    [SerializeField] private TMP_Text stageText;

    [Header("스테이지별 아이콘")]
    [SerializeField] private Sprite iconBattle;
    [SerializeField] private Sprite iconElite;
    [SerializeField] private Sprite iconBoss;
    [SerializeField] private Sprite iconRest;
    [SerializeField] private Sprite iconTreasure;
    [SerializeField] private Sprite iconUnknown;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);



    }

    private void Start()
    {
        CloseAll();
    }

    /// 모든 팝업 끄기
    public void CloseAll()
    {
        if (GameManager.instance.currentState == GameState.Title)  // 현재 타이틀상태일 때 오프시키는 팝업
        {
            settingPopup.Hide();// - setting pop 은 사운드 매니저에서 관리.
            creditPopup?.Hide();
            quitGameCheckPopup?.Hide();
            Debug.Log("타이틀 상태에서 팝업 닫기");
        }
        if (GameManager.instance.currentState == GameState.Map) // 현재 맵상태일 때 오프시키는 팝업
        {
            optionPopup?.Hide();
            deckPopup?.Hide();
            chessPopup?.Hide();
        }
        YSUIManager.Instance.isPopupOpen = false;
    }

    // ------------------------------------------------------아래 = 버튼 UI 영역
    // 버튼용 메서드 3개

    public void ToggleSetting()
    {
        CloseAll();
        settingPopup.Show();
    }

    public void ToggleCredit()
    {
        CloseAll();
        creditPopup.Show();
    }

    public void ToggleQuitGame()
    {
        CloseAll();
        quitGameCheckPopup.Show();
    }

    public void OnYesButtonClick()
    {
        Debug.Log("게임 종료");
        Application.Quit();
    }










    public void ToggleOption()
    {
        CloseAll();
        optionPopup.Show();
    }

    public void Toggledeck()
    {
        CloseAll();
        deckPopup.Show();
    }

    public void Togglechess()
    {
        CloseAll();
        chessPopup.Show();
    }

    public void On_BackButton()
    {
        CloseAll();
    }

    public void CloseCurrent() => CloseAll();


    public void On_OptionGiveUpButton()
    {
        Debug.Log("Give Up");
        Debug.Log("타이틀 씬 전환 넣기");
        //popup.SetActive(false);
    }




    public void On_TitleOptionButton()
    {
        Debug.Log("Option");
        //popup.SetActive(false);
    }

    public void On_TitleCreditButton()
    {
        Debug.Log("Credit");
        //popup.SetActive(false);
    }

    public void On_GiveUpButtonClicked()
    {
        MapManager.instance.gameover_gameobj?.SetActive(true);
    }

    public void On_UpgradeBackButtonClicked()
    {
        upgradePopup.SetActive(false);
    }




   











    //-------------------------------------------------------- 토글한 노드에 따라 상단 UI 변경하는 기능들임
    public void ShowStageInfo(StageNodeType type)
    {
        stageIcon.sprite = type switch
        {
            StageNodeType.NormalBattle => iconBattle,
            StageNodeType.EliteBattle => iconElite,
            StageNodeType.BossBattle => iconBoss,
            StageNodeType.Rest => iconRest,
            StageNodeType.Treasure => iconTreasure,
            _ => iconUnknown
        };

        stageText.text = type switch
        {
            StageNodeType.NormalBattle => "당신의 두려움을 마주하세요!",
            StageNodeType.EliteBattle => "당신의 두려움을 마주하세요!",
            StageNodeType.BossBattle => "당신의 두려움을 마주하세요!",
            StageNodeType.Rest => "잠깐 쉬고 가는 것도 괜찮을지도..?",
            StageNodeType.Treasure => "어떤 보상이 기다릴까요?",
            StageNodeType.Unknown => "무엇이 나올지 아무도 모릅니다!",
            _ => "???"
        };

        stageIcon.enabled = true;
        stageText.enabled = true;
    }

    public void HideStageInfo()
    {
        stageIcon.enabled = false;
        stageText.enabled = false;
    }

}
