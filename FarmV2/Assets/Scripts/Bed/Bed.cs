using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using static UnityEditor.Progress;


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

    [SerializeField] private ItemInstance _growItem;

    private float timeSinceLastUse = 0f;

    [FormerlySerializedAs("Plant")] public Inventory playerInventory;

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
            if (Vector3.Distance(this.transform.position, player.transform.position) < 0.3f)
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
        if ((step == STEP_EMPTY || step == STEP_PLOW) && playerInventory.items.Count < 1)
            return;

        // активный предмет
        var activeItem = playerInventory.items[0];

        if (readyForAction)
        {
            if (step == STEP_EMPTY)
            {
                //TODO добавить проверку на то, что это семечко
                if (activeItem.count <= 0)
                {
                    return;
                }

                spriteRenderer.sprite = items[0].sprite;
                step = STEP_GROWS;
                activeItem.count -= 1;
                StartCoroutine(Grow(playerInventory.items[0].item.time, activeItem.item, 2));
                UseGarden();
            }
            else if (step == STEP_READY)
            {
                if (_growItem != null && !playerInventory.TryAddItem(_growItem, 3))
                {
                    // если не получилось поместить в инвентарь по какой-то причине
                }
                else
                {
                    spriteRenderer.sprite = items[2].sprite;
                    step = STEP_PLOW;
                }
            }
            else if (step == STEP_WEED)
            {
                //TODO Это корутина? а где? 
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

    private IEnumerator Grow(float time, Item growItem, int count)
    {
        yield return new WaitForSeconds(time);
        spriteRenderer.sprite = growItem.sprite;
        _growItem = new ItemInstance() { item = growItem, count = count };
        step = STEP_READY;
        UseGarden();
    }

    private IEnumerator Off()
    {
        yield return new WaitForSeconds(5f);
        spriteRenderer.sprite = items[3].sprite;
        step = STEP_EMPTY;
    }
}