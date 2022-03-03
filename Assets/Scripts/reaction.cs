using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class reaction : MonoBehaviour
{
    
    public CameraShake cameraShake;
    public ParticleSystem explosionEffect;
    public Elements[] ElementsinArea;
    public HolderScripts leftHolderScript;
    public HolderScripts rightHolderScript;
    public int explosion;
    public GameObject leftHolder;
    public GameObject rightHolder;
    public ElementsSpawner elements;
    // Start is called before the first frame update
    void Start()
    {
        explosionEffect.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp("space")) {

            React(leftHolderScript.elementToReact, rightHolderScript.elementToReact);

        }    
    }
        void React(Elements element1, Elements element2) {
        int totalReactivity;
        totalReactivity = element1.reactivity + element2.reactivity * (elements.Score / 5);
        cameraShake.shakeDuration += 0.5f;
        cameraShake.shakeAmount = 0.3f;
        if (totalReactivity >= explosion){
            explosionEffect.Play();
            
            
            SceneManager.LoadScene("Start");
            

            
        }        
        else {
            elements.Score +=  totalReactivity;
        }
        Destroy(leftHolderScript.toDestroy, 0);
        Destroy(rightHolderScript.toDestroy, 0);
        

    }

}
