using PlayerNS;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public int gems;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<Player>();
            if (player != null) player.diamonds += gems;
            Destroy(gameObject);
        }
    }
}
