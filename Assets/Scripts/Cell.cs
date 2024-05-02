using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private SpriteRenderer spriteRender;
    [SerializeField]
    private Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponentInParent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        spriteRender.sprite = sprites[1];
    }
}
