using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMode : MonoBehaviour
{
    public bool pause;
    public static PauseMode instanse;

    // Start is called before the first frame update
    private void Awake()
    {
        pause = false;
        if (instanse == null)
        {

            instanse = this;
        }
    }
    

}
