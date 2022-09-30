using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusSystem : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        LevelSpecificVariables.frameCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        LevelSpecificVariables.frameCounter += 1;
        if(LevelSpecificVariables.frameCounter == 3000){
            callEmergencyMeeting();
            LevelSpecificVariables.frameCounter = 0;
        }
        
    }

    void susActionDone(int increase){
        LevelSpecificVariables.suspicionLevel += increase;
    }

    void callEmergencyMeeting(){
        int prob = Random.Range(0,100);
        if(LevelSpecificVariables.suspicionLevel>prob){
            print(LevelSpecificVariables.suspicionLevel>prob);
            //Lose
        }
    }
}
