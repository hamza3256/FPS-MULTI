using UnityEngine;
using TMPro;



public class AmmoDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ammoTypeText;

    [SerializeField] TextMeshProUGUI ammoCountText;
    
    [SerializeField] TextMeshProUGUI clipCountText;


    public void UpdateAmmoCount(int count)
    {
        ammoCountText.text = count.ToString();

    }

   public void UpdateAmmoType(AmmoType ammoType)
    {
        ammoTypeText.text = ammoType.ToString();
    }

    public void UpdateClipCount(int count)
    {
        clipCountText.text = count.ToString();

    }

}
