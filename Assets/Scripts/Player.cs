using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerAnimation playerAnim;
    private SpriteRenderer spriteRend;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private bool resetJump;
    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask groundLayerMask;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayerAnimation>();
        spriteRend = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        MovePlayer();
    }

    private bool Grounded()
    {
        var hitInfo = Physics2D.Raycast(origin: transform.position, direction: Vector2.down, distance: 0.8f,
                layerMask: groundLayerMask);

        if (hitInfo.collider != null)
        {
            if (resetJump == false)
            {
                playerAnim.SetJumpBool(false);
                return true;
            }
        }

        return false;
    }

    private void MovePlayer()
    {
        var moveH = Input.GetAxisRaw("Horizontal") * speed;
        spriteRend.flipX = moveH < 0;
        
        Grounded(); // for setJump to false

        if (Input.GetKeyDown(KeyCode.Space) && Grounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            StartCoroutine(ResetJumpRoutine());
            playerAnim.SetJumpBool(true);
        }
        
        rb.velocity = new Vector2(moveH, rb.velocity.y);
        playerAnim.SetSpeedFloat(moveH);
    }

    private IEnumerator ResetJumpRoutine()
    {
        resetJump = true;

        yield return new WaitForSeconds(0.1f);
        resetJump = false;
    }
}
