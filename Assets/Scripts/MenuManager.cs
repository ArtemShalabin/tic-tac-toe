
using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void SetPVP()
    {
        GameSettings.gameMode = GameMode.PVP;
        SceneManager.LoadScene("GameScene");
    }
    public void SetPVE()
    {
        GameSettings.gameMode = GameMode.PVE;
        SceneManager.LoadScene("GameScene");
    }
}
