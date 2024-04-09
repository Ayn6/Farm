using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bed : MonoBehaviour
{

    [SerializeField] private Sprite select;
    [SerializeField] private Sprite bed;

    private int STEP_EMPTY = 0;
    private int STEP_GROWS = 1;
    private int STEP_READY = 2;
    private int STEP_PLOW = 3;
    private int STEP_WEED = 4;

    public List<Item> items = new List<Item>();
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer spriteBed;

    private int step = 0;

    private GameObject player;
    private bool readyForAction;

    private float timeSinceLastUse = 0f;

    public Inventory Plant;

    void Start()
    {
        spriteBed = GetComponent<SpriteRenderer>();
        spriteRenderer = GetComponentsInChildren<SpriteRenderer>()[1];
        player = GameObject.FindWithTag("Player");

    }

    private void FixedUpdate()
    {
        timeSinceLastUse += Time.deltaTime;
        Weed();

        if (step != STEP_GROWS)
        {
            if(Vector3.Distance(this.transform.position, player.transform.position) < 0.3f)
            {
                readyForAction = true;
                spriteBed.sprite = select;
            }
            else
            {
                readyForAction = false;
                spriteBed.sprite = bed;
            }
        }
        else
        {
            spriteBed.sprite = bed;
        }
        
    }
    public void UseGarden()
    {
        timeSinceLastUse = 0f;
    }
    public void OnMouseDown()
    {

        if (readyForAction)
        {
            if (step == STEP_EMPTY)
            {
                if (items[0].type == Item.TYPEFOOD)
                {
                    spriteRenderer.sprite = items[0].sprite;
                    step = STEP_GROWS;
                    StartCoroutine(Grow());
                    UseGarden();
                }
            }
            else if(step == STEP_READY)
            {

                spriteRenderer.sprite = Plant.items[0].sprite;
                step = STEP_PLOW;
                Plant.items[0].count = 2;
            }
            else if (step == STEP_WEED)
            {
                Off();
            }
        }


    }

    private void Weed()
    {
        if (step == STEP_EMPTY && timeSinceLastUse > 60f)
        {
            spriteRenderer.sprite = items[3].sprite;
            step = STEP_WEED;
            UseGarden();
        }
    }

    private IEnumerator Grow()
    {
        yield return new WaitForSeconds(items[1].time);
        spriteRenderer.sprite = items[1].sprite;
        step = STEP_READY;
        UseGarden();
    }
    private IEnumerator Off()
    {
        yield return new WaitForSeconds(5f);
        spriteRenderer.sprite = Plant.items[0].sprite;
        step = STEP_EMPTY;
    }

}
