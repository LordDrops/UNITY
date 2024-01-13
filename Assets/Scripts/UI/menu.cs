using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    public GameObject hiddenAutorzy;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnLabelClick()
    {
        hiddenAutorzy.SetActive(true);  // Pokaż ukryty element
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
