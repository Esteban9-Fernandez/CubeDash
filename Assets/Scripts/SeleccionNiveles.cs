using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class SeleccionNiveles : MonoBehaviour
{
    public void CargarNivel(string nombreNivel)
    {
        SceneManager.LoadSceneAsync(nombreNivel);
    }
}
