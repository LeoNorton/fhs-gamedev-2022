using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ApplyLevelSkin : MonoBehaviour
{
    [SerializeField] private List<GroundSkin> _groundSkins = new();
    void Start()
    {
        foreach(var skin in _groundSkins)
        {
            var groundParent = GameObject.Find(skin.ParentName).transform;
            var groundChildren = new List<SpriteRenderer>();
            for (int i = groundParent.childCount - 1; i >= 0; i--)
            {
                var instance = Instantiate(skin.SkinObject, groundParent.GetChild(i).transform.position, Quaternion.identity);
                instance.GetComponent<SpriteRenderer>().size = (Vector2)groundParent.GetChild(i).localScale * 2.5f * 0.96f;
                groundParent.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
                groundChildren.Add(instance.GetComponent<SpriteRenderer>());
            }
            groundChildren.OrderByDescending(s => s.size.magnitude);
            groundChildren.Reverse();
            var g = groundChildren.Count + 2; //+2 to give leeway with other objects in lower sorting layers
            foreach (var child in groundChildren)
            {
                child.GetComponent<SpriteRenderer>().sortingOrder = g;
                g--;
            }
        }
    }
    //i wasn't sure what sorting factor was, so i wrote a different method. hope this works, -elan
    void SkinTheLevels(GameObject _skinObject, string _parentName, int _sortingOrderFactor) // _sortingOrderFactor just decides which layer
                                                                                            // this is in, range of 1-31. multiplied by 1k.
                                                                                            // We are capped at 1k of each type of block in
                                                                                            // a level and 31 different types of blocks in a
                                                                                            // level due to the sorting layer cap of 2^15 - 1
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

[System.Serializable]
public struct GroundSkin
{
    public GameObject SkinObject;
    public string ParentName;
    public int SortingFactor;
}
