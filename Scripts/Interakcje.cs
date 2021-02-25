using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interakcje : MonoBehaviour
{
    private GameObject hero;
    private GameObject sword;
    public bool Have_sword;//to co widzisz
    public bool Have_bomb;//to co widzisz
    public bool Have_sandwich;//Zmienia cię w Hulka
    public bool Have_sonick;//I EM SPIIIID
    private SFX sfx;
    // Start is called before the first frame update
    void Start()
    {
        sword = GameObject.Find("Sword");
        hero = GameObject.Find("Hero");
        sfx = FindObjectOfType<SFX>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Have_sword!=true)
        {
            if (Vector3.Distance(sword.transform.position, hero.transform.position) < 1)
             {
             Have_sword = true;
              Destroy(sword.gameObject);
                sfx.Item.Play();
             }
        }
    }
}
