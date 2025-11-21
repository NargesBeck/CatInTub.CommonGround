using UnityEngine;

public class FlowerView : MonoBehaviour
{
    [SerializeField] private GameObject GOPick;
    [SerializeField] private GameObject GOWater;
    
    public void ShowPickToWater()
    {
        GOPick.SetActive(false);
        GOWater.SetActive(true);
    }

    public void ShowWaterToPick()
    {
        GOPick.SetActive(true);
        GOWater.SetActive(false);
    }

    public void Init()
    {
        GOPick.SetActive(true);
        GOWater.SetActive(false);
    }
}
