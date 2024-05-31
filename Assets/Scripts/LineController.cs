
using UnityEngine;

public class LineController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] horizontal;
    [SerializeField] 
    private GameObject[] vertical;
    [SerializeField]
    private GameObject[] dioganal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenVertical(int index)
    {
        horizontal[index].SetActive(true);
    }
    public void OpenHorizontal(int index)
    {
        vertical[index].SetActive(true);
    }
    public void OpenDiagonal(int index)
    {
        dioganal[index].SetActive(true);
    }
}
