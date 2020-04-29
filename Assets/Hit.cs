using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hit : MonoBehaviour
{

    public Text hit;
    public Text hitCount;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter(Collision col)
    {
        Global.count++;
        hit.text = "You hit the target!";
        Invoke("Hide", 2);
        hitCount.text = "Targets Hit: " + Global.count/2; 
    }
    
    void Hide()
    {
        hit.text = "";
    }
    
}

public class Global 
{
    public static int count = 0;
}