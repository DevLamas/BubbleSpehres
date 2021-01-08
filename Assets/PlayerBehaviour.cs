using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{



    public float VitesseMouvement = 10f;
    public float VitesseRotation = 100f;
    public float SautVelocite = 20f;
    
    
    public float DistanceGround = 0.1f;
    public LayerMask groundLayer;
    private Rigidbody _rb;
    private SphereCollider _col;

    public float vInput;
    public float hInput;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<SphereCollider>();

    }

    // Update is called once per frame
    void Update()
    {

        vInput = Input.GetAxis("Vertical") * VitesseMouvement;
        hInput = Input.GetAxis("Horizontal") * VitesseRotation;


    }
    private void FixedUpdate()
    {

        Vector3 Rotation = Vector3.up * hInput;
        Quaternion angleRot = Quaternion.Euler(Rotation * Time.fixedDeltaTime);
        _rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);




    }


}
