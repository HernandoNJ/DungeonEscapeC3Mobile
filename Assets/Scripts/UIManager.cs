using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance => instance;

    public Text playerGemsCountText;
    public Image selectionImage;
    
    private void Awake()
    {
        instance = this;
        if(instance == null) Debug.LogError("UI Manager is null");
    }

    public void OpenShop(int gemsCount)
    {
        playerGemsCountText.text = gemsCount + " G";
    }
}
