using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Singleton : MonoBehaviour{

    //インスタンスが存在するか？

    static bool existsInstance = false;

    void Awake(){

        if(existsInstance){

            Destroy(gameObject);

            return;

        }



        existsInstance = true;

        DontDestroyOnLoad(gameObject);

    }

    

}
