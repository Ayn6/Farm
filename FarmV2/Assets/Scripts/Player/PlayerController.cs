using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    private float horizontal, vertical;
    private SpriteRenderer spriteRender;
    public Sprite front, left, rigtht, back;

    private void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(horizontal, vertical, 0);
    }

    public void OnLeft()
    {
        spriteRender.sprite = left;
        horizontal = -speed;
    }    
    public void OnRight()
    {
        spriteRender.sprite = rigtht;
        horizontal = speed;
    }    
    public void OnUp()
    {
        spriteRender.sprite = back;
        vertical = speed;
    }    
    public void OnDown()
    {
        spriteRender.sprite = front;
        vertical = -speed;
    }

    public void Stop()
    {
        spriteRender.sprite = front;
        vertical = horizontal = 0;
    }

}
