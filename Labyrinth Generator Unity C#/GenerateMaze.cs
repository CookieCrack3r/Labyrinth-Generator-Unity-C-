using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMaze : MonoBehaviour {
	
	public Transform wallItem; //für das Mauerstück 
	public GameObject player;
	public Transform spielFlaeche;
	public Transform aussenWallItem;
	//public Transform boden; //für die Spielfläche 
	public static float countX; //für die Anzahl in x- und z-Richtung 
	public static float countZ; //für die Anzahl in x- und z-Richtung 
	
	// Use this for initialization
	public void Start () {
		//einige Hilfsvariablen 
		float sizeX, sizeZ;
		float sizeBodenX; 
		float sizeaussenWallX;
		Vector3 posPlayer;
		Vector3 position, positionx, positionz, positionz2;
		Vector3 positionBoden;
		Vector3 positionaussenWallItem;
		//wurde ein Objekt übergeben? 

		if (wallItem == null || spielFlaeche == null) { 
			Debug.Log("Es wurde kein Objekt übergeben"); 
			return; 
		} 

		//zum Zwischenspeichern der Position 
		float newPosX = wallItem.position.x; 
		float newPosZ = wallItem.position.z; 
		float newPosBodenX = spielFlaeche.position.x; 
		float newPosBodenZ = spielFlaeche.position.z; 

		//das untergeordnete Objekt beschaffen 
		Transform myChild = wallItem.transform.GetChild(0); 
		if (myChild == null) { 
			Debug.Log("Es wurde kein untergeordnetes Objekt gefunden"); 
			return; 
		} 

		//die Größe beschaffen über den MeshFilter 
		MeshFilter meshFilter = myChild.GetComponent<MeshFilter>();
		MeshFilter meshFilterBoden = spielFlaeche.GetComponent<MeshFilter>();
		MeshFilter meshaussenWallItem = aussenWallItem.GetComponent<MeshFilter>();
		
		//hat das Objekt einen MeshFilter?
		if (meshFilter == null || meshFilterBoden == null || meshaussenWallItem == null) {
			Debug.Log("Es wird ein Objekt mit Mesh benötigt");
			return;
		}

		Mesh mesh = meshFilter.mesh; //das Mesh über den MeshFilter beschaffen
		Vector3 meshSize = mesh.bounds.size; //Mesh size
		Vector3 scale = myChild.transform.localScale; //die Skalierung beschaffen 
		sizeX = meshSize.x * (scale.x); //die Größe berechnen 
		

		

		Mesh meshBoden = meshFilterBoden.mesh; //das Mesh über den MeshFilter beschaffen
		Vector3 meshSizeBoden = meshBoden.bounds.size; //Mesh size
		Vector3 scaleBoden = spielFlaeche.transform.localScale; //die Skalierung beschaffen 
		sizeBodenX = meshSizeBoden.x * (scaleBoden.x); //die Größe berechnen


		Mesh meshAussenWall = meshaussenWallItem.mesh; //das Mesh über den MeshFilter beschaffen
		Vector3 meshSizeAussenWall = meshAussenWall.bounds.size; //Mesh size
		Vector3 scaleAussenWall = aussenWallItem.transform.localScale; //die Skalierung beschaffen 
		sizeaussenWallX = meshSizeAussenWall.x * (scaleAussenWall.x); //die Größe berechnen
		sizeZ = meshSize.z * (scale.z); //die Größe berechnen
		
		//in einer geschachtelten Schleife werden die Mauerstücke erzeugt 

		for (int runX = 0; runX < countX+1; runX++) { 
			for (int runZ = 0; runZ < countZ+1; runZ++) { 
				newPosBodenX = spielFlaeche.position.x + sizeBodenX  * runX; 
				newPosBodenZ = spielFlaeche.position.z + sizeBodenX * runZ; 
				positionBoden = new Vector3(newPosBodenX, spielFlaeche.position.y, newPosBodenZ);
				Instantiate(spielFlaeche, positionBoden, Quaternion.Euler(0, Random.Range(0, 4) * 90, 0));
            }
        } 


		for (int runX = 0; runX < countX; runX++) { 
			for (int runZ = 0; runZ < countZ; runZ++) { 
				newPosX = wallItem.position.x + sizeX * runX; 
				newPosZ = wallItem.position.z + sizeX * runZ;
				position = new Vector3(newPosX, wallItem.position.y, newPosZ);
                Instantiate(wallItem, position, Quaternion.Euler(0, Random.Range(0, 4) * 90, 0));
            }
        } 
					//Run 1
			int a = (int)Random.Range(0,countX);

		for (int runX = 0; runX < countX+1; runX++) { 

			newPosX = aussenWallItem.position.x + sizeaussenWallX * runX; 
			position = new Vector3(newPosX, aussenWallItem.position.y, aussenWallItem.position.z);
            Instantiate(aussenWallItem, position, Quaternion.identity);

			if(runX == a){
				runX=runX+1;
				player.transform.position = new Vector3(newPosX, 2, -8);
			}
			
            
        } 
					//Run 2		 
		for (int runY = 0; runY < countZ+2; runY++) { 
			newPosX = aussenWallItem.position.x + sizeaussenWallX * countX+1; 
			newPosZ = aussenWallItem.position.z + sizeaussenWallX * runY;
			position = new Vector3(newPosX + sizeZ, aussenWallItem.position.y, newPosZ  + sizeZ);
            Instantiate(aussenWallItem, position, Quaternion.Euler(0, 90, 0));
        }
					//Run 3
			int b = (int)Random.Range(0,countX);
		for (int runZ = 0; runZ < countX+1; runZ++) { 
			newPosX = aussenWallItem.position.x + sizeaussenWallX * runZ; 
			newPosZ = aussenWallItem.position.z + sizeaussenWallX + sizeBodenX * countZ+1; 
			position = new Vector3(newPosX, aussenWallItem.position.y, newPosZ);
            Instantiate(aussenWallItem, position, Quaternion.Euler(0, 0, 0));
			
			if(runZ == b){
				runZ=runZ+1;
			}
        }

					//Run 4
		for (int runV = 0; runV < countZ+2; runV++) { 

			newPosX = aussenWallItem.position.x - (1 + sizeZ); 
			newPosZ = aussenWallItem.position.z + sizeaussenWallX  * runV + sizeZ;

			position = new Vector3(newPosX, aussenWallItem.position.y, newPosZ);
            Instantiate(aussenWallItem, position, Quaternion.Euler(0, 90, 0));
        }

		int c = (int)Random.Range(0,countX) / 2;
		int d = (int)Random.Range(0,countZ) / 2;
		
	}
}
