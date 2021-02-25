using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Destruction : MonoBehaviour
{

    public GameObject hero;
    private Tilemap tilemap;
    private float LastMoveX, LastMoveY;
    private Vector3Int SlashedTile;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (hero.GetComponent<Interakcje>().Have_sword == true)
            {
                LastMoveX = hero.GetComponent<Movement>().LastMoveX;
                LastMoveY = hero.GetComponent<Movement>().LastMoveY;
                if (LastMoveX > 0f || LastMoveX < 0f)
                {
                    SlashedTile = tilemap.WorldToCell(new Vector2(hero.transform.position.x + LastMoveX, hero.transform.position.y));
                }

                else if (LastMoveY > 0f || LastMoveY < 0f)
                {
                    SlashedTile = tilemap.WorldToCell(new Vector2(hero.transform.position.x, hero.transform.position.y + LastMoveY));
                }
                tilemap.SetTile(SlashedTile, null);
                tilemap.SetTile(SlashedTile + new Vector3Int(Mathf.RoundToInt(LastMoveX), Mathf.RoundToInt(LastMoveY), 0), null);
                if(LastMoveX != 0f)
                { 
                    tilemap.SetTile(tilemap.WorldToCell(new Vector2(SlashedTile.x, hero.transform.position.y + 0.75f)), null);
                    tilemap.SetTile(tilemap.WorldToCell(new Vector2(SlashedTile.x, hero.transform.position.y - 0.75f)), null);
                }

                else if (LastMoveX == 0f)
                {
                    tilemap.SetTile(tilemap.WorldToCell(new Vector2(SlashedTile.x + 0.75f, hero.transform.position.y)), null);
                    tilemap.SetTile(tilemap.WorldToCell(new Vector2(SlashedTile.x - 0.75f, hero.transform.position.y)), null);
                }
            }

        }

    }
}