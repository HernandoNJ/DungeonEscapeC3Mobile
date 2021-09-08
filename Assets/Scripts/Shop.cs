using PlayerNS;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject playerSprite;
    [SerializeField] private GameObject swordArc;
    [SerializeField] private Player player;

    public int currentItem;
    public int currentItemCost;

    private void Start()
    {
        shopPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<Player>();
            if (player != null)
                UIManager.Instance.OpenShop(player.diamonds);
            ActivateShop(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) ActivateShop(false);
    }

    public void SelectedItem(int item)
    {
        // item 0:  - 1: Boots of flight 2 - Key to castle
        currentItem = item;
        var uiInst = UIManager.Instance;

        switch (item)
        {
            case 0: // Flame sword 
                uiInst.UpdateShopSelection(50);
                currentItemCost = 200;

                break;
            case 1: // Boots of flight 
                uiInst.UpdateShopSelection(-40);
                currentItemCost = 400;

                break;
            case 2: // Key to castle
                uiInst.UpdateShopSelection(-135);
                currentItemCost = 100;

                break;
        }
    }

    public void BuyItem()
    {
        if (player.diamonds >= currentItemCost)
        {
            // award item
            player.diamonds -= currentItemCost;
            Debug.Log("purchased item: " + currentItem);
            Debug.Log("remaining diamonds: " + player.diamonds);
            ActivateShop(false);
        }
        else
        {
            Debug.Log("Diamonds not enough");
            ActivateShop(false);
        }
    }

    private void ActivateShop(bool isOpen)
    {
        if (isOpen)
        {
            shopPanel.SetActive(true);
            playerSprite.SetActive(false);
            swordArc.SetActive(false);
        }
        else
        {
            shopPanel.SetActive(false);
            playerSprite.SetActive(true);
            swordArc.SetActive(true);
        }
    }
}
