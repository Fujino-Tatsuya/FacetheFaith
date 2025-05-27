using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    GameObject popup;

    private void Awake()
    {
        Debug.Log("��?");
        popup = GameObject.FindWithTag("Popup");

        popup.SetActive(false);
    }



    // ------------------------------------------------------�Ʒ� = ��ư UI ����
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
        Debug.Log("Ÿ��Ʋ �� ��ȯ �ֱ�");
        //popup.SetActive(false);
    }
}
