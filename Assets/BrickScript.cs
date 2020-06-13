using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    public int points;
    public int hitsToBreak;
    public Sprite hitSprite;

    public void breakBrick() {
        hitsToBreak--;
    }

    public void changeColor() {
        GetComponent<SpriteRenderer>().color = new Color(0.6f, 0.2f, 0.35f);
    }
}
