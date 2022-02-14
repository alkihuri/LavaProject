using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RagdollController : MonoBehaviour
{


    [SerializeField] List<Joint> ragDollList = new List<Joint>();
    // Start is called before the first frame update
    void Start()
    {
        ragDollList = GetComponentsInChildren<Joint>().ToList();
        RagDollSettings(false);
    }
    

    public void RagDollSettings(bool state)
    {
        foreach(Joint j in ragDollList)
        {
            j.enableCollision  = state ;
        }
    }
}
