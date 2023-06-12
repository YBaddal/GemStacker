using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;
    public List<Gem> gemList;
    public Text goldText;

    public Transform collectedGemContent;
    public GameObject collectedGemCellPrefab;
    private void Awake()
    {
        if(instance == null)
           instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateCollectedPopUp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenerateCollectedPopUp()
    {
        foreach(Gem gem in gemList)
        {
            GameObject obj = Instantiate(collectedGemCellPrefab, collectedGemContent);
            obj.GetComponent<CollectedGemCell>().gem = gem;
            obj.SetActive(true);
        }
    }
}
