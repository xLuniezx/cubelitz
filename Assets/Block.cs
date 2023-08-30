using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    Level level;
    GameSession gameStatus;

    [SerializeField] int timesHit; // TODO only serialized for debug

    
    private void Start()
    {
        gameStatus = FindObjectOfType<GameSession>();
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block Sprite is Missing from array" + gameObject.name);
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length +1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
            gameStatus.AddToScore();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void DestroyBlock()
    {   
            AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
            Destroy(gameObject);
            level.BlockDestroyed();
            TriggerSparklesVFX();

    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }

}
