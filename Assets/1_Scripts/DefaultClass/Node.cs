using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum NodeColorType
{
    None,
    White,
    Gray
}

public enum NodeStyleType 
{
    first,
    second,
    third,
    fourth,
    fifth
}

public enum StageNodeType
{
    NormalBattle,   // �Ϲ����� 
    Rest,           // �޽�(����)
    Treasure,       // ������
    Unknown,        // ����

    EliteBattle,    // ��������
    BossBattle,     // ����
    Road,           // �ε�
    King,

}


public class Node : MonoBehaviour
{
    public Vector2Int GridPos { get; private set; }
    public NodeColorType ColorType { get; private set; }
    
    public StageNodeType stageNodeType = StageNodeType.Road; // �⺻���� Road

    public List<Node> nextNodes = new();

    public eMonsterAttackType monsterAttackType;

    [SerializeField] MeshRenderer meshRenderer;// ���� ���׸���
    [SerializeField] MeshRenderer frontRenderer;  // ����� ���׸���

    //[SerializeField] SpriteRenderer spriteRenderer;  // ��������Ʈ ������

    [Header("����")]
    public GameObject currentPiece;
    public bool isObstacle;
    public bool isStageNode = false;

    public int stageIndex = -1; // 1~10 �������� ��ȣ, -1�� �������� ���
    public string sceneName;  // �� ��带 Ŭ���ϸ� ��ȯ�� �� �̸�

    public void Init(Vector2Int pos, NodeColorType color, Material mat, Material frontMat) //��� �ʱ�ȭ �Լ� 
    {
        GridPos = pos;
        ColorType = color;
        currentPiece = null;
        isObstacle = false;
        isStageNode = false;
        meshRenderer.material = mat;   // ���޹��� ���׸��� ����
        frontRenderer.material = frontMat;  // ���� ���׸��� ����
    }
    
    public void SetStageNode(StageNodeType style) //����� ��Ÿ���� ���� = ����� �������� Ÿ���� ����
    {
        //Debug.Log("���� ��?"); // ����� �α� �߰�
        isStageNode = true;
        stageNodeType = style;
        gameObject.SetActive(true);
        // �ð� ȿ��: frontRenderer ���� ����
        //switch (style)
        //{
        //    case StageNodeType.NormalBattle:
        //        meshRenderer.material.color = Color.red; // �Ϲ� = ����
        //        break;
        //    case StageNodeType.EliteBattle:
        //        meshRenderer.material.color = Color.green;
        //        break;
        //    case StageNodeType.BossBattle:
        //        meshRenderer.material.color = Color.blue;
        //        break;
        //    case StageNodeType.Rest:
        //        meshRenderer.material.color = Color.white;
        //        break;
        //    case StageNodeType.Treasure:
        //        meshRenderer.material.color = Color.yellow;
        //        break;
        //    case StageNodeType.Unknown:
        //        meshRenderer.material.color = Color.black;
        //        break;
        //    case StageNodeType.King:
        //        meshRenderer.material.color = Color.magenta;
        //        break;
        //}
    }
    
    public void setMaterial(Material mat) {

        //meshRenderer.material = mat;
        transform.GetChild(1).GetComponent<MeshRenderer>().material =mat;
    }

    //public void setSprite(Sprite sprite)
    //{
    //    spriteRenderer.sprite = sprite;
    //}


    void OnMouseEnter() // ���콺 Ŀ���� ��忡 �ö���� ��
    {
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            return; //  UI ���� Ŀ���� ������ ����

        if (GameManager.instance.currentState == GameState.Map)
            JH_UIManager.Instance.ShowStageInfo(stageNodeType);
    }

    public void SetTileVisible(bool visible)
    {
        if (meshRenderer != null)
            meshRenderer.enabled = visible;
    }

    public bool IsOccupied() => currentPiece != null || isObstacle;

    //private void OnMouseDown()
    //{
    //    if (stageIndex > 0 && !string.IsNullOrEmpty(sceneName))
    //    {
    //        MapManager.instance.currentStageNum = stageIndex; // ���� ���õ� �������� ����
    //        Debug.Log($"[�������� {stageIndex}] Ŭ���� �� �� ��ȯ: {sceneName}");
    //        //SceneManager.LoadScene(sceneName);����ȯ �ӽ� �ּ�ó��
    //    }
    //}


}
