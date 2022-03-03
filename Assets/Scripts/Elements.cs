using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(menuName = "Element")] 
public class Elements : ScriptableObject 
{
    public int score;
    public string elementName;
    public Sprite elementArt;
    public int reactivity;
    public bool isMetal;

}
