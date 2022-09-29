using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusSystem : MonoBehaviour
{
    
    

    // Start is called before the first frame update
    void Start()
    {
        PublicVars.frameCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PublicVars.frameCounter += 1;
        if(PublicVars.frameCounter == 3000){
            PublicVars.frameCounter = 0;
        }
    }

    void TaskSabotage(){
        PublicVars.suspicionLevel += 5;
    }

    void callEmergencyMeeting(){
        
    }
}
