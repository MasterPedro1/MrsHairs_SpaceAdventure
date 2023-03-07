using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [Tooltip("Gameobject tags that can interact with this")]
    public string[] toolTags;
    [Tooltip("Gameobject tags that can be combined with this")]
    public string[] ingredientTags;

    public bool isTreated;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
