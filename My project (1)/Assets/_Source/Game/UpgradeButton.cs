using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private PointsSystem pointsSystem; 

    public void OnUpgradeClick()
    {
        pointsSystem.TryUnlockNextClicker(); 
    }
}