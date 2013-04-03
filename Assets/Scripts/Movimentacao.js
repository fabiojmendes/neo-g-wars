#pragma strict

var Velocidade: Vector3;

var ConstanteZ: float;

var ConstanteX: float;

function Start () {

}

function Update () {



if (Input.mousePosition.x<=5 || Input.mousePosition.x>=Screen.width-5)
 {
   if (Input.GetAxis("Mouse X")!=0)
   {
   if (Input.GetAxis("Mouse X")>0 && Input.mousePosition.x>=Screen.width-5)
   {
    ConstanteX=2;
   } 
   else
   {
    if (Input.mousePosition.x<=5)
    {
      ConstanteX=-2;
     }
   }
  
    
    
    Velocidade.x = ConstanteX*50*Time.deltaTime;
   }
 }
 else
 {
 Velocidade.x=0;
 }

if (Input.mousePosition.y<=5 || Input.mousePosition.y>=Screen.height-5)
 {
  if (Input.GetAxis("Mouse Y")!=0)
   {
    if (Input.GetAxis("Mouse Y")>0 && Input.mousePosition.y>=Screen.height-5)
   {
    ConstanteZ=2;
   } 
   else
   {
    if (Input.mousePosition.y<=5)
    {
      ConstanteZ=-2;
     }
   }
  }
    Velocidade.z = ConstanteZ*50*Time.deltaTime;
   
 }
 else
 {
 Velocidade.z=0;
 }
 Velocidade.y = -Input.GetAxis("Mouse ScrollWheel")*1000*Time.deltaTime ;
transform.Translate(Velocidade);
}