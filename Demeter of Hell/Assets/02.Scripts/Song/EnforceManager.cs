using UnityEngine;

public class EnforceManager : MonoBehaviour
{
    // 캐릭터 레벨업 특성 및 팝업
    [SerializeField] Transform characterEnforceItemParent; 
    // 식물 레벨업 특성 및 팝업
    [SerializeField] Transform plantEnforceItemParent; 

    [SerializeField] GameObject EnforceItem; // 나중에 GameObject는 다른 형태의 스크립트 오브젝트로 대체


    // 레벨업시 강화창 띄우기
    void PopUpEnforceCanvas()
    {
        
    }
}
