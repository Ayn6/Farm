using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float horizontal;
    private float vertical;
    private SpriteRenderer spriteRender;

    public Sprite front, left, right, back;

    private void Start()
    {
        spriteRender = this.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        transform.Translate(horizontal, vertical, 0);
    }

    public void OnRight()
    {
        spriteRender.sprite = right;
        horizontal = speed;
    }
    public void OnLeft()
    {
        spriteRender.sprite = left;
        horizontal = -speed;
    }
    public void OnUp()
    {
        spriteRender.sprite = back;
        vertical = speed;
    }
    public void UnDown()
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
