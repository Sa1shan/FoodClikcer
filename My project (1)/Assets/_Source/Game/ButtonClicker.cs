using UnityEngine;
using UnityEngine.UI;

public class ButtonClicker : MonoBehaviour
{
    [SerializeField] private int pointsPerClick = 1; 
    [SerializeField] private Button button;         
    private bool isUnlocked = false; 
    [SerializeField] private PointsSystem pointsSystem; 

    void Start()
    {
        UpdateButtonState();  
    }
    
    public void OnClick()
    {
        if (isUnlocked) 
        {
            pointsSystem.AddPoints(pointsPerClick);
        }
    }
    
    public void Unlock(int pointsForClick)
    {
        isUnlocked = true; 
        pointsPerClick = pointsForClick; 
        UpdateButtonState(); 
    }
    
    private void UpdateButtonState()
    {
        button.interactable = isUnlocked; 
    }
}