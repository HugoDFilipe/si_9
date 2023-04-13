using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Experimental.Rendering.Universal;

public class TilemapShadowCaster2D : MonoBehaviour
{
    public GameObject sc;
    public Tilemap tm;
    public GameObject shadowCasterContainer;
    public void Start()
    {
        int i = 0;
        foreach (Vector3Int position in tm.cellBounds.allPositionsWithin)
        {
            if (tm.GetTile(position) == null)
                continue;

            GameObject shadowCaster = GameObject.Instantiate(sc, shadowCasterContainer.transform);
            shadowCaster.transform.position = tm.CellToWorld(position) + new Vector3(0.5f,0.5f);
            shadowCaster.name = "shadow_caster_" + i;
            i++;
        }
    }
}
