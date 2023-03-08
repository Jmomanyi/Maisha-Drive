using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin1 : MonoBehaviour
{
  public GameObject originalWheel;
  

  void Update(){
    transform.rotation=originalWheel.transform.rotation;
  }
  
  }
