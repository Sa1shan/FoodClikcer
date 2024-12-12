using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Unity.VisualScripting;

public class PointsSystem : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private Button backButton;
    [SerializeField] private int totalPoints = 0; 
    [SerializeField] private List<ButtonClicker> clickers; 
    [SerializeField] private Button upgradeButton; 
    [SerializeField] private Slider pointsSlider; 
    private int nextUnlockIndex = 1; 

    void Start()
    {
        upgradeButton.gameObject.SetActive(true); 
        clickers.AddRange(GameObject.FindObjectsOfType<ButtonClicker>());
        clickers[0].Unlock(1); 
        UpdatePointsUI(); 
        UpdateUpgradeButtonState(); 
        obj.SetActive(false);
        backButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (nextUnlockIndex >= clickers.Count)
        {
            upgradeButton.gameObject.SetActive(false); 
        }
        if (pointsSlider.value > 0.5)
        {
            obj.SetActive(true);
        }
        if (pointsSlider.value == 1)
        {
            backButton.gameObject.SetActive(true);
        }
    }
    
    public void AddPoints(int points)
    {
        totalPoints += points; 
        UpdatePointsUI(); 
        UpdateUpgradeButtonState(); 
    }
    
    private void UpdatePointsUI()
    {
        float maxPoints = 1000f; 
        pointsSlider.value = Mathf.Clamp01((float)totalPoints / maxPoints); 
    }

   
    private void UpdateUpgradeButtonState()
    {
        int unlockCost = 10 + nextUnlockIndex * 15; 
        
        if (nextUnlockIndex < clickers.Count && totalPoints >= unlockCost)
        {
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeButton.interactable = false; 
        }
    }
    
    public void TryUnlockNextClicker()
    {
        int unlockCost = 10 + nextUnlockIndex * 15;
        
        if (nextUnlockIndex < clickers.Count && totalPoints >= unlockCost)
        {
            totalPoints -= unlockCost; 
            
            clickers[nextUnlockIndex].Unlock(nextUnlockIndex + 1);

            nextUnlockIndex++;
            UpdatePointsUI(); 
            UpdateUpgradeButtonState(); 
        }
    }
}