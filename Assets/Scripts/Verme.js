var TextoVida: TextMesh;
var Vida: int;
var Dano: Animator;

function Start () {

Vida= 100;

}

function Update () {

TextoVida = transform.GetComponentInChildren(TextMesh);
TextoVida.text = "Vida:"+Vida;

}

function OnCollisionEnter(collision: Collision)
{
	
	Dano = collision.transform.GetComponent("Animator");
	
	if (Dano.atack3)
	Vida=Vida-10;
	
	
}