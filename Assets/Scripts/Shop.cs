using PlayerNS;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject shopPanel;

    private void Start()
    {
        shopPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<Player>();
            if(player != null) UIManager.Instance.OpenShop(player.diamonds);
            shopPanel.SetActive(true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player")) shopPanel.SetActive(false);
    }

    public void SelectedItem(int item)
    {
        // item 0: Flame sword - 1: Boots of flight 2 - Key to castle
        Debug.Log("Item selected: " + item);
    }

}
