using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    { get {
        if (instance == null) Debug.LogError("UI Manager is null");
        return instance; } }

    public Text playerGemsCountText;
    public Text gemCountText;
    public Image selectionImage;
    public Image[] healthBar;

    private void Awake()
    {
        instance = this;
        if (instance == null) Debug.LogError("UI Manager is null");
    }

    public void OpenShop(int gemsCount)
    {
        playerGemsCountText.text = gemsCount + " G";
    }

    public void UpdateShopSelection(int yPos)
    {
        var xPos = selectionImage.rectTransform.anchoredPosition.x;
        selectionImage.rectTransform.anchoredPosition = new Vector2(xPos, yPos);
    }

    public void UpdateGemsCount(int count)
    {
        gemCountText.text = "" + count;
    }

    public void UpdateLives(int livesRemaining)
    {
        for (int i = 0; i <= livesRemaining; i++)
        {
            if (i == livesRemaining) healthBar[i].enabled = false;

        } 
    }
    
}
