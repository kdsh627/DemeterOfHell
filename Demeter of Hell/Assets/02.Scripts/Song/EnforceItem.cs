using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnforceItem : MonoBehaviour
{
    public Image enforceItemImage;
    public TMP_Text fixedUp;
    public TMP_Text randomUp;


    public void SetItemContent(Sprite itemImage, string fixedtext, string randomtext)
    {
        enforceItemImage.sprite = itemImage;
        fixedUp.text = fixedtext;
        randomUp.text = randomtext;
    }
}
