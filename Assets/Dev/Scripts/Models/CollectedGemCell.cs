using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CollectedGemCell : MonoBehaviour
{
    public Gem gem;
    public Image gemImage;
    public Text gemNameText, gemCollectCountText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        SetCell();
    }
    public void SetCell()
    {
        if (gem == null)
            return;

        if (gemImage)
            gemImage.sprite = gem.gemIcon;

        if (gemNameText)
            gemNameText.text = gem.gemName;

        if (gemCollectCountText)
            gemCollectCountText.text = PlayerPrefs.GetInt(gem.gemName).ToString();
    }
}
