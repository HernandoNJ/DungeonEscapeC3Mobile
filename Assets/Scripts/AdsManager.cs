using UnityEngine;

public enum AdsResult{Finished, Skipped, Failed}

public class AdsManager : MonoBehaviour
{
    private GameManager gm;
    private UIManager uiM;
    
    private void Start()
    {
        gm = GameManager.Instance;
        uiM = UIManager.Instance;
    }


    public void ShowRewardedAd()
    {
        Debug.Log("Ad with reward shown. +100G ");
        CustAdsHandler(AdsResult.Finished);
    }

    private void CustAdsHandler(AdsResult resultArg)
    {
        switch (resultArg)
        {
            case AdsResult.Finished:
                gm.Player.AddGems(100);
                uiM.OpenShop(gm.Player.diamonds);
                break;
            case AdsResult.Skipped: Debug.Log("Ad skipped"); break;
            case AdsResult.Failed: Debug.Log("Ad failed"); break;
        }
    }
}
