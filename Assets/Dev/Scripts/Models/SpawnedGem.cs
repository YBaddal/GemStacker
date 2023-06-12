using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class SpawnedGem : MonoBehaviour
{
    public Gem gem;
    public float gemPrice;
    // Start is called before the first frame update
    void Start()
    {
       BoxCollider collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = true;
        collider.size = Vector3.one;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Init() 
    {
        transform.DOScale(Vector3.one, 5);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            CollectGem();
    }

    void CollectGem()
    {
        if (transform.localScale.x > 0.25f)
        {
            transform.DOPause();
            transform.DOMove(GameManager.instance.player.transform.position, 0.1f).OnComplete(OnComplete); 
        }
    }

    void OnComplete()
    {
        CalculatePrice();
        transform.GetComponentInParent<GemSpawner>().Collected(gameObject);
        transform.SetParent(GameManager.instance.player.stackTransform);
        transform.localPosition = new Vector3(0, GameManager.instance.player.stackList.Count,0);
        GameManager.instance.player.stackList.Add(this);
    }
    void CalculatePrice()
    {
        double scale = Math.Round(transform.localScale.x,2);
        gemPrice = gem.gemStartPrice + (float)scale * 100;
    }
}
