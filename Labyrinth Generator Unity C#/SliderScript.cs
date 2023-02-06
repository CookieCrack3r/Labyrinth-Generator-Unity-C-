using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SliderScript : MonoBehaviour
{

    public Slider mainSliderX;
    public Slider mainSliderZ;
    //public GameObject mainSliderX;
    //public GameObject mainSliderZ;

    public Text mainTextX;
    public Text mainTextZ;
    public Vector3 _rotate;
    
    //public GameObject mainTextX;
    //public GameObject mainTextZ;
    GameObject test;
    GenerateMaze generateMaze;
        
    void Start()
    {
        //Slider holen
       mainSliderX = GameObject.Find("SliderX").GetComponent<Slider>();
       mainSliderZ = GameObject.Find("SliderZ").GetComponent<Slider>();

       test = GameObject.Find("Wall (4)"); //Für den blinkenden Würfel :D

       mainTextX = GameObject.Find("TextX").GetComponent<Text>();;
       mainTextZ = GameObject.Find("TextZ").GetComponent<Text>();
       //Color();
       
    }
        //Aufruf über On Value changed im Slider 
        public void Color(){
            test.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            //Invoke("Color", 2f);
        }

    // Update is called once per frame
    void Update()
    {
        test.GetComponent<Transform>().transform.Rotate(Vector3.up * Time.deltaTime * 20f);
        
        //test.transform.Translate(0f,0.01f,0f);

        if (Input.GetKeyDown (KeyCode.Space)){
            Debug.Log("Methode Call");
            LevelStart();
        }
        //GenerateMaze.countX = mainSliderX.value;
        //GenerateMaze.countZ = mainSliderZ.value;
       

        mainTextX.text = mainSliderX.value.ToString();
        mainTextZ.text = mainSliderZ.value.ToString();

    }

    public void LevelStart(){
        GenerateMaze.countX = mainSliderX.value;
        GenerateMaze.countZ = mainSliderZ.value;
        Debug.Log("Level Load");
        SceneManager.LoadScene(1);
    }
}
