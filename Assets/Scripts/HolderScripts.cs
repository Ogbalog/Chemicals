using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolderScripts : MonoBehaviour
{
    public ElementsSpawner elementsSpawner;
    public Elements elementToReact;
    public BoxCollider2D box;
    public GameObject rightSpawn;
    public GameObject leftSpawn;
    public GameObject toDestroy;
    // Start is called before the first frame update
    void Start()
    {
         box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == ("element")){
            int y = 0;
            while(y < elementsSpawner.Elements.Length){
                if(col.gameObject.name == elementsSpawner.Elements[y].elementName) {
                    if (elementsSpawner.Elements[y].isMetal == true && gameObject == rightSpawn) {
                        Debug.Log("Impossible");
                        Destroy(col.gameObject, 0);
                    }
                    else if (elementsSpawner.Elements[y].isMetal == false && gameObject == leftSpawn) {
                        Debug.Log("Impossible");
                        Destroy(col.gameObject, 0);
                    }
                    else {
                        elementToReact = elementsSpawner.Elements[y];
                        toDestroy = col.gameObject;
                        Debug.Log(elementToReact);
                        
                    }
                
                
                }


                y++;
            }
        }



    }
}
