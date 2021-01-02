using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float fallMultiplier = 1.3f;
    [SerializeField]
    private float destroyTime = 10f;
    private SpriteRenderer sr;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Object.Destroy(gameObject, destroyTime);
        sr = gameObject.GetComponent<SpriteRenderer>();
        Init(Consts.currentSprite);
        rb.gravityScale = Consts.gravityScale;
    }
    public void Init(Sprite ballSprite, float fallMultiplier = 1.3f, float destroyTime = 10f)
    {
        sr.sprite = ballSprite;
        this.fallMultiplier = fallMultiplier;
        this.destroyTime = destroyTime;
        GetComponent<Ball>().DeactivateRB();
    }
    private void FixedUpdate()
    {
        if (rb.velocity.y < 0)
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
    }
    public void ActivateRB()
    {
        rb.isKinematic = false;
    }
    public void DeactivateRB()
    {
        rb.isKinematic = true;

        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
    }
}
