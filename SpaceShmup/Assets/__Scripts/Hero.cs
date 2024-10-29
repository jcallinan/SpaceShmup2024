using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    static public Hero S { get; private set; } // Singleton property

    [Header("Inscribed")]
    // these fields will control the movement of the ship
    public float speed = 30;
    public float rollMult = -45;
    public float pitchMult = 30;

    [Header("Dynamic")]
    public float shieldLevel = 1;

    //whenever the application is 1. started or 2. brought back from hibernation
    private void Awake()
    {
        if (S == null)
        {
            S = this;
        } else
        {
            Debug.LogError("Hero.Awake() - Attempt to assign a second hero");
        }
    }


    // Update is called once per frame
    void Update()
    {
        // pull in info from the Input class
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector3 pos = transform.position;
        pos.x += hAxis * speed * Time.deltaTime;
        pos.y += vAxis * speed * Time.deltaTime;
        transform.position = pos;   

        transform.rotation = Quaternion.Euler(vAxis*pitchMult, hAxis* rollMult,0);

    }
}
