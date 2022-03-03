using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class ElementsSpawner : MonoBehaviour
{

    int scoretotal;
    
    //Element Spawning
    public Elements[] Elements;
    int elementToSpawnLocInArray;
    
    //Score and time
    

    public PostProcessVolume m_Volume;
    public PostProcessProfile m_Profile;
    private Vignette m_Vignette;
    
    private Bloom m_Bloom;
    
    public TMP_Text ScoreText;
    public int Score = 10;
    public int HighScoreThisRun = 0;
    public int Level;
    float intervalBetweenSpawn = 1;
    float time = 0;
    float personalTime = 0;
    int heatNeeded;
    GameObject elementGameobject;
    public sscore sscore;
    [Header("Cupboard for element spawning")]
    public GameObject Cupboard;
    public bool canSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        sscore = ScriptableObject.CreateInstance<sscore>();
        Level = 1;
        m_Volume.profile.TryGetSettings(out m_Vignette);
        m_Volume.profile.TryGetSettings(out m_Bloom);    

        
        

     
        
        
        score();
    
    }
    //Get and set score 
    void score() {   
        HighScoreThisRun += Score;
        ScoreText.text = ("Heat: " + Score.ToString() + "    Level: " + Level.ToString() + "    Score: " + HighScoreThisRun.ToString());
        m_Vignette.intensity.value = Mathf.Clamp(((Score/100)), 0f, 1f);
        m_Vignette.color.value = new Color(Mathf.Clamp(Score*2f, 255f, 0f), 54, 0); 
        m_Bloom.intensity.value = Mathf.Clamp(((Score/1000) * 3), 0f, 1f);
        if(sscore.highScore < HighScoreThisRun) {
        sscore.highScore = HighScoreThisRun;}
    }
    public void SpawnElement(Elements elementToSpawn, Vector3 posToSpawn, bool canweSpawn){
        
        if (canweSpawn == true) {
        elementGameobject = new GameObject(elementToSpawn.name);
        elementGameobject.AddComponent<SpriteRenderer>().sprite = elementToSpawn.elementArt;
        elementGameobject.AddComponent<BoxCollider2D>().isTrigger = false;
        elementGameobject.AddComponent<Elementmovement>();
        elementGameobject.AddComponent<ElementCollision>();
        elementGameobject.transform.position = posToSpawn;
        elementGameobject.tag = "element";
        
        }
    }
    public void spawnAcid() {
            SpawnElement(Elements[Random.Range(15, 17)], new Vector3(6, -2, 0), true);
    }

    
    void Update() {
        time += Time.deltaTime;
        personalTime += Time.deltaTime;

        if (time >= intervalBetweenSpawn) {
          time = time - intervalBetweenSpawn;
          Score -= 1;
          score();
        }
        if(Score <= 0) {
            SceneManager.LoadScene("Start");
            
        }
        if(time == scoretotal){
            scoretotal += 2;

        }
        if(personalTime > 20) {
            Level += 1;
            personalTime = 0;
        }
        
        
        


    }
    
}
