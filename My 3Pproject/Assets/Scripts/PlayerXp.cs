using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerXp : MonoBehaviour
{
    [SerializeField] Slider xpSlider;
    [SerializeField] protected float currentXp;
    [SerializeField] protected float startingXp=0f;
    [SerializeField] protected float totalXp;
    [SerializeField] protected GameObject sword;
    [SerializeField] protected float swordDamage;
    [SerializeField] protected GameObject LevelUpScreen;
    bool reachedMaxLevel;
    // Start is called before the first frame update
    void Start()
    {
        currentXp = startingXp;
        reachedMaxLevel= false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GiveXp(float amount)
    {
        currentXp += amount;
        xpSlider.value = currentXp;
        if (xpSlider.value>=totalXp && !reachedMaxLevel)
        {
            sword.GetComponent<SwordDamage>().damage = swordDamage;
            LevelUpScreen.SetActive(true);
            reachedMaxLevel = true;
        }
    }
}
