using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDataManager : MonoBehaviour
{

    [SerializeField]
    private Carro[] _listaDeCarros;

    [SerializeField]

    private CarroSO[] _carritosScriptableObjects;

    private GameObject[] _carrosGO;
    private GameObject[] _carrosGOS;
    //private ScriptableObject[] _carrosGOS;

    void Start() 
    {
        _carrosGO = new GameObject[_listaDeCarros.Length];
        _carrosGOS = new GameObject[_carritosScriptableObjects.Length];
        //_carrosGOS = new ScriptableObject[_carritosScriptableObjects.Length];

        // activarlos por primera vez
        for (int i = 0; i < _listaDeCarros.Length; i++)
        {
            _carrosGO[i] = CarPoolManager.Instance.Activar(Vector3.zero);
            // actualizar scriptable object de carrito
        }

        // Activacion para scriptable
        for (int i = 0; i < _carritosScriptableObjects.Length; i++)
        {
            //_carrosGOS[i] = CarPoolManager.Instance.Activar(Vector3.zero);
            //_carrosGOS[i] = PosicionarCarrosS();
            // actualizar scriptable object de carrito

            _carrosGOS[i] = Instantiate(_carritosScriptableObjects[i].prefabDeModelo, Vector3.zero, Quaternion.identity) as GameObject;

            //_carrosGOS[i] = _carritosScriptableObjects[i];

            //_carrosGOS[i].SetActive(true);
            //_carrosGOS[i].transform.position = Vector3.zero;
        }

        //PosicionarCarros();
        PosicionarCarrosS();
    }

    private void PosicionarCarros() {
        // activar los 10 carritos en las posiciones congruentes
        for(int i = 0; i < _listaDeCarros.Length; i++) 
        {
            _carrosGO[i].transform.position = new Vector3(
                _listaDeCarros[i].x,
                _listaDeCarros[i].y,
                _listaDeCarros[i].z
            );
        }
    }

    private void PosicionarCarrosS() {
        // activar los 10 carritos en las posiciones congruentes
        for (int i = 0; i < _carritosScriptableObjects.Length; i++) 
        {
            _carrosGOS[i].transform.position = new Vector3(
               Random.Range(0f, 10f),
               Random.Range(0f, 10f),
               Random.Range(0f, 10f)
            );
            Debug.Log(i);
        }
    }

// Update is called once per frame
void Update()
    {
        // MUY IMPORTANTE
        // CENTRALIZAR ENTRADA
        if(Input.GetKeyDown(KeyCode.R)){

            // recalcular posiciones
            for(int i = 0; i < _listaDeCarros.Length; i++) 
            {
                _listaDeCarros[i] = new Carro();
                _listaDeCarros[i].id = 0;
                _listaDeCarros[i].x = Random.Range(0f, 10f);
                _listaDeCarros[i].y = Random.Range(0f, 10f);
                _listaDeCarros[i].z = Random.Range(0f, 10f);
            }

            // posicionar carritos en nuevo lugar
            PosicionarCarros();
        }

        //ScriptableObjects
        if (Input.GetKeyDown(KeyCode.T))
        {
            // posicionar carritos en nuevo lugar
            //Debug.Log(_carritosScriptableObjects.Length);
            PosicionarCarrosS();
        }
    }

    public void EscucharSinArgumentos() {

        print("EVENTO LANZADO SIN ARGUMENTOS");
    }

    public void EscucharConArgumentos(ListaCarro datos) {

        print("RECIBIDO: " + datos);

        // actualizar _listaDeCarros
        // invocar PosicionarCarros()
    }
}
