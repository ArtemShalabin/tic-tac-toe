using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private CellStatus lastStatus;
    private CellStatus[,] board = new CellStatus[3,3];
    [SerializeField]
    private EndGame endGame;
    public bool isGameOver;
    [SerializeField]
    private LineController lineController;
    void Start()
    {
        Debug.Log(GameSettings.gameMode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public CellStatus NextStatus()
    {
        if(lastStatus == CellStatus.None)
        {
            return CellStatus.Cross;
        }
        if(lastStatus == CellStatus.Cross)
        {
            return CellStatus.Circle;
        }
        if (lastStatus == CellStatus.Circle)
        {
            return CellStatus.Cross;
        }
        return CellStatus.None;
    }
    private bool CheckWinner(CellStatus player)
    {
        for(int i = 0; i < 3; i++)
        {
            if (board[i,0] == player && board[i,1] == player && board[i,2] == player)
            {
                lineController.OpenVertical(i);
                return true;
            }
            if (board[0,i] == player && board[1, i] == player && board[2, i] == player)
            {
                lineController.OpenHorizontal(i);
                return true;
            }

        }
        if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
        {
            lineController.OpenDiagonal(0);
            return true;
        }
        if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
        {
            lineController.OpenDiagonal(1);
            return true;
        }
        return false;
    }
    private bool IsBoardFull()
    {
        for(int i = 0;i < 3; i++)
        {
            for (int j = 0;j < 3; j++)
            {
                if (board[i,j] == CellStatus.None)
                {
                    return false;
                }
            }
        }
        return true;
    }
    public void Move(CellStatus newStatus,int row,int col)
    {
        if (board[row,col] == CellStatus.None && isGameOver == false) {
            board[row,col] = newStatus;

            if (CheckWinner(newStatus) == true)
            {
                isGameOver = true;
                endGame.Display(newStatus);
                
                Debug.Log("Winner: " + newStatus);
            }
            else if(IsBoardFull() == true)
            {
                isGameOver = true;
                endGame.Display(CellStatus.None);
                
                Debug.Log("Draw");
            }
            else
            {
                lastStatus = newStatus;
            }

        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
