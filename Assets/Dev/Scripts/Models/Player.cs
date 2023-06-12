using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Player : MonoBehaviour
{
    public Transform stackTransform;
    public List<SpawnedGem> stackList;
    public float gold;
    // Start is called before the first frame update
    void Start()
    {
        gold =  PlayerPrefs.GetFloat("Gold");

        if (GameManager.instance.goldText)
            GameManager.instance.goldText.text = gold.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EarnGold(float price)
    {
        gold += price;
        PlayerPrefs.SetFloat("Gold",gold);

        if (GameManager.instance.goldText)
            GameManager.instance.goldText.text = gold.ToString();
    }
}
