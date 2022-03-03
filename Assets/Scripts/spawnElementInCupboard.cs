using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnElementInCupboard : MonoBehaviour
{

    public ElementsSpawner elementsSpawner;
    public cupboard Cupboard;
    private BoxCollider2D box;
    public int elementNum;
    // Start is called before the first frame update
    void Start()
    {
        box = gameObject.AddComponent<BoxCollider2D>();
        box.isTrigger = true;
        Cupboard = GameObject.FindGameObjectWithTag("cupboard").GetComponent<cupboard>();
        elementsSpawner = GameObject.FindGameObjectWithTag("ElementSpawner").GetComponent<ElementsSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseOver() {
        if (Input.GetMouseButtonUp(0)) {
            elementsSpawner.SpawnElement(Cupboard.elementsInCupboard[elementNum], Cupboard.CupboardLocations[elementNum], true);
            Cupboard.elementsInCupboard[elementNum] = ScriptableObject.CreateInstance<Elements>();
            Destroy(gameObject, 0);
            
        }
    }
}
