using UnityEngine;
using UnityEngine.UI;

public class EnforceManager : MonoBehaviour
{
    // 캐릭터 레벨업 특성 및 팝업
    [SerializeField] Transform characterEnforceItemParent; 
    // 식물 레벨업 특성 및 팝업
    [SerializeField] Transform plantEnforceItemParent;

    [SerializeField] GameObject enforceItem; // 나중에 GameObject는 다른 형태의 스크립트 오브젝트로 대체


    void Start()
    {
        //for (int i = 0; i < 3; i++)
        //{
        //    GameObject characterEnforceItem = Instantiate(enforceItem, characterEnforceItemParent);
        //    GameObject plantEnforceItem = Instantiate(enforceItem, plantEnforceItemParent);
        //}
    }
}
