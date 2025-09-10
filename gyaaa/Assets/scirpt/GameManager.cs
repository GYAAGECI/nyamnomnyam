using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class GameManager : MonoBehaviour{
    public GameObject[] guys;

    [Space(10)]
    [SerializeField] Transform startPos;
    [SerializeField] Transform checkPos;
    [SerializeField] Transform endPos;

    [Space(10)]
    [SerializeField] TextMeshProUGUI corrects;
    [SerializeField] TextMeshProUGUI inCorrects;

    [Space(10)]
    [SerializeField] GameObject correctLight;
    [SerializeField] GameObject incorrectLight;

    int correctCount;
    int incorrectCount;

    Guy currentGuy;
    Camera cam;

    void Start(){
        cam = Camera.main;
        SpawnNewGuy();
    }

    void Update(){
        if(Input.GetMouseButtonDown(0)){
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit)){
                if(hit.collider.gameObject.TryGetComponent<ColorButton>(out ColorButton cb)){
                    cb.ClickMe();
                }
            }
        }
    }

    public void SpawnNewGuy(){
        GameObject temp = Instantiate(guys[Random.Range(0, guys.Length)], startPos.position, Quaternion.identity);
        currentGuy = temp.GetComponent<Guy>();

        currentGuy.SetTarget(checkPos);
    }

    public void ClickButton(string clickedColor){
        if(clickedColor == currentGuy.myCol){
            currentGuy.SetTarget(endPos);
            Destroy(currentGuy, 5);
            correctCount++;
            corrects.text = $"Corrects: {correctCount}";

            StartCoroutine(FlashLight(correctLight));
        }else{
            currentGuy.SetTarget(endPos);
            Destroy(currentGuy, 5);
            incorrectCount++;
            inCorrects.text = $"Incorrects: {incorrectCount}";

            StartCoroutine(FlashLight(incorrectLight));
        }

        SpawnNewGuy();
    }

    public IEnumerator FlashLight(GameObject lightToFlash){
        lightToFlash.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        lightToFlash.SetActive(false);
    }
}