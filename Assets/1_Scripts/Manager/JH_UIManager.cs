using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JH_UIManager : MonoBehaviour
{

    public static JH_UIManager Instance { get; private set; }


    [Header("�˾� ����")]
    public PopupWindow optionPopup;
    public PopupWindow deckPopup;
    public PopupWindow chessPopup;
    public PopupWindow settingPopup;
    public PopupWindow creditPopup;
    public PopupWindow quitGameCheckPopup;
    public GameObject upgradePopup;

    [Header("������ & ����")]
    [SerializeField] private Image stageIcon;
    [SerializeField] private TMP_Text stageText;

    [Header("���������� ������")]
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

    /// ��� �˾� ����
    public void CloseAll()
    {
        if (GameManager.instance.currentState == GameState.Title)  // ���� Ÿ��Ʋ������ �� ������Ű�� �˾�
        {
            settingPopup.Hide();// - setting pop �� ���� �Ŵ������� ����.
            creditPopup?.Hide();
            quitGameCheckPopup?.Hide();
            Debug.Log("Ÿ��Ʋ ���¿��� �˾� �ݱ�");
        }
        if (GameManager.instance.currentState == GameState.Map) // ���� �ʻ����� �� ������Ű�� �˾�
        {
            optionPopup?.Hide();
            deckPopup?.Hide();
            chessPopup?.Hide();
        }
        YSUIManager.Instance.isPopupOpen = false;
    }

    // ------------------------------------------------------�Ʒ� = ��ư UI ����
    // ��ư�� �޼��� 3��

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
        Debug.Log("���� ����");
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
        Debug.Log("Ÿ��Ʋ �� ��ȯ �ֱ�");
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




   











    //-------------------------------------------------------- ����� ��忡 ���� ��� UI �����ϴ� ��ɵ���
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
            StageNodeType.NormalBattle => "����� �η����� �����ϼ���!",
            StageNodeType.EliteBattle => "����� �η����� �����ϼ���!",
            StageNodeType.BossBattle => "����� �η����� �����ϼ���!",
            StageNodeType.Rest => "��� ���� ���� �͵� ����������..?",
            StageNodeType.Treasure => "� ������ ��ٸ����?",
            StageNodeType.Unknown => "������ ������ �ƹ��� �𸨴ϴ�!",
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
