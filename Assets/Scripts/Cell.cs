using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private SpriteRenderer spriteRender;
    [SerializeField]
    private Sprite[] sprites;
    private GameManager gameManager;
    private CellStatus currentStatus;
    [SerializeField]
    private int col;
    [SerializeField]
    private int row;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameObject");
        gameManager = gameManagerObject.GetComponent<GameManager>();
        spriteRender = GetComponentInParent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (currentStatus == CellStatus.None && gameManager.isGameOver == false)
        {
            SetSkin(gameManager.NextStatus());
            ChangeStatuse(gameManager.NextStatus());
        }
    }
    private void SetSkin(CellStatus status)
    {
        if(status == CellStatus.Circle)
            spriteRender.sprite = sprites[0];
        if(status == CellStatus.Cross)
            spriteRender.sprite = sprites[1];
    }
    private void ChangeStatuse(CellStatus status)
    {
        currentStatus = status;
        gameManager.Move(status,row,col);
    }
}
public enum CellStatus
{
    None,
    Cross,
    Circle
}

