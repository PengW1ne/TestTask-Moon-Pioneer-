using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour{
   [SerializeField] private Rigidbody rigidbody;
   [SerializeField] private FixedJoystick joystick;

   [SerializeField] private float movementSpeed;

   private void FixedUpdate(){
      if (joystick.Horizontal != 0 && joystick.Vertical != 0){
         rigidbody.velocity = new Vector3(joystick.Horizontal * movementSpeed, 0, joystick.Vertical * movementSpeed);
         transform.rotation = Quaternion.LookRotation(rigidbody.velocity); 
      }
      else{
         rigidbody.velocity = Vector3.zero;
      }
   }
}
