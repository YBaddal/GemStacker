using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SalesManager : MonoBehaviour
{
   
    float frequency = 0.1f;
    float frequencyCountdown;
    Player player;

    private void Start()
    {
        player = GameManager.instance.player;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            frequencyCountdown += Time.deltaTime;
            if (frequency <= frequencyCountdown)
            {
                frequencyCountdown = 0;
                Sell();
            }
            
        }
    }
    void Sell()
    {
        if (player == null)
            return;

        if (player.stackList.Count == 0)
            return;
        player.EarnGold(player.stackList.Last().gemPrice);
        int sellCount = PlayerPrefs.GetInt(player.stackList.Last().gem.gemName)+1;
        PlayerPrefs.SetInt(player.stackList.Last().gem.gemName, sellCount);
        Destroy(player.stackList.Last().gameObject);
        player.stackList.RemoveAt(player.stackList.Count - 1);
    }
}
