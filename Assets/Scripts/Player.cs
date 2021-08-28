using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerAnimation playerAnim;
    private SpriteRenderer playerSpriteRend;

    [SerializeField] private GameObject swordArcGO;
    [SerializeField] private SpriteRenderer swordArcRend;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private bool resetJump;
    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask groundLayerMask;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayerAnimation>();
        playerSpriteRend = GameObject.Find("PlayerSprite").GetComponent<SpriteRenderer>();
        swordArcGO = GameObject.Find("SwordArc");
        swordArcRend = swordArcGO.GetComponent<SpriteRenderer>();

        if (rb == null || playerAnim == null || playerSpriteRend == null || swordArcGO == null || swordArcRend == null)
            Debug.LogWarning("Set required components in player script");
    }

    private void Update()
    {
        MovePlayer();
        CheckGrounded();
    }

    private void CheckGrounded()
    {
        Debug.DrawRay(transform.position, Vector3.down * 0.8f, Color.green);

        var hitInfo = Physics2D.Raycast(origin: transform.position, direction: Vector2.down, distance: 0.8f,
                layerMask: groundLayerMask);

        if (hitInfo.collider != null)
        {
            isGrounded = true;
            if (resetJump == false) playerAnim.SetJumpAnim(false);
        }
        else isGrounded = false;
    }

    private void MovePlayer()
    {
        var moveH = Input.GetAxisRaw("Horizontal") * speed;
        var flipped = moveH < 0;
        FlipPlayer(flipped);
       

        var spacePressed = Input.GetKeyDown(KeyCode.Space);
        var leftBtnPressed = Input.GetMouseButtonDown(0);

        if (spacePressed && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            StartCoroutine(ResetJumpRoutine());
            playerAnim.SetJumpAnim(true);
        }

        if (leftBtnPressed && isGrounded) playerAnim.SetAttackAnim();

        rb.velocity = new Vector2(moveH, rb.velocity.y);
        playerAnim.SetRunAnim(moveH);
    }

    private void FlipPlayer(bool isFlipped)
    {
        playerSpriteRend.flipX = isFlipped;
        swordArcRend.flipX = isFlipped;
        swordArcRend.flipY = isFlipped;
        
        var newPos = swordArcGO.transform.localPosition;
        if (isFlipped) newPos.x = -1f;
        else newPos.x = 1;
        swordArcGO.transform.localPosition = newPos;
    }

    private IEnumerator ResetJumpRoutine()
    {
        resetJump = true;

        yield return new WaitForSeconds(0.1f);
        resetJump = false;
    }
}
