using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cupboard : MonoBehaviour
{
    ElementsSpawner elementsSpawner;
    public Elements[] elementsInCupboard; 
    private Vector3 TargetLocation;
    public float speed = 3f;
    public Sprite open;
    BoxCollider2D box;

    public Sprite closed;
    int prevLevel = 0;
    public SpriteRenderer CupboardRenderer;
    bool openCupboard;
    public GameObject[] inCupboard;
    public Vector3[] CupboardLocations;
    // Start is called before the first frame update
    void Start()
    {
        CupboardLocations = new Vector3[] {new Vector3(2.2f, 1.76f, 0f), new Vector3(3.5f, 1.76f, 0f), new Vector3(2.2f, 0.56f, 0f), new Vector3(3.5f, 0.56f, 0f), new Vector3(2.2f, -0.76f, 0f),new Vector3(3.5f, -0.76f, 0f)};
        elementsSpawner = GameObject.FindGameObjectWithTag("ElementSpawner").GetComponent<ElementsSpawner>();
        box = GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseOver() {
        if(Input.GetMouseButtonDown(0)) {
            OpenCupboard(elementsSpawner.Level);
        }
    
    }
    void GenerateCupboard(){
        int x = 0;
        int elementstoSpawn;
        elementstoSpawn = 6;


        elementsInCupboard = new Elements[elementstoSpawn];
        inCupboard = new GameObject[elementstoSpawn];
        elementsInCupboard.Initialize();
        while(x < elementstoSpawn){
            
            elementsInCupboard[x] = elementsSpawner.Elements[Random.Range(0, 14)];
            x += 1;
            elementsInCupboard[1] = elementsSpawner.Elements[Random.Range(15, 17)];
            elementsInCupboard[2] = elementsSpawner.Elements[Random.Range(15, 17)];
            elementsInCupboard[3] = elementsSpawner.Elements[Random.Range(15, 17)];
            
        }
    }

    void OpenCupboard(int level) {
        //If The Level is differrent to the last level, recreate a cupboard.
        if (level != prevLevel){
            GenerateCupboard();
        }
        
        //If the Cupboard is closed, open it
        if(openCupboard == false) {
            CupboardRenderer.sprite = closed;
            transform.position = new Vector3(7, -3, 0);
            transform.position = new Vector3(3, 0, 0);
            transform.localScale = new Vector3(2, 2, 1);
            CupboardRenderer.sprite = open;
            displayElementsInCupboard();
            openCupboard = true;
           

        }

        //If the Cupboard is open, close it
        else if(openCupboard == true && level != prevLevel) {
            WaitForSeconds(1);
            CupboardRenderer.sprite = open;
            transform.position = new Vector3(3, 0, 0);
            transform.position = new Vector3(7, -3, 0);
            transform.localScale = new Vector3(1, 1, 1);
            CupboardRenderer.sprite = closed;
            
            cancelDisplayOfElements();
            openCupboard = false;
            
        }
        prevLevel = level;
        
        

    }
    IEnumerator WaitForSeconds(int wait) {
        yield return new WaitForSeconds(wait);
    }
    //Displays elements in the cupboard, by creating gameobjects, and adding colliders and a selectables script
    void displayElementsInCupboard() {
        int y;
        y = 0;
        while (y < 6){
            
            elementsSpawner.SpawnElement(elementsInCupboard[y], CupboardLocations[y], true);
            y++;

        }
    }
    //Destroys the elements in the cupboard to close it
    void cancelDisplayOfElements() {
        int y;
        y = 0;
        while (y < inCupboard.Length){

            Destroy(inCupboard[y], 0);
            y++;

        }
    
    }


}
