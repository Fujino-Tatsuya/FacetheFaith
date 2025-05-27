using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    GameObject popup;

    private void Awake()
    {
        Debug.Log("뜸?");
        popup = GameObject.FindWithTag("Popup");

        popup.SetActive(false);
    }



    // ------------------------------------------------------아래 = 버튼 UI 영역
    public void On_OptionButton() 
    {

        popup.SetActive(true);
    }

    public void On_OptionBackButton()
    {

        popup.SetActive(false);
    }
    public void On_OptionGiveUpButton()
    {
        Debug.Log("Give Up");
        Debug.Log("타이틀 씬 전환 넣기");
        //popup.SetActive(false);
    }
}
