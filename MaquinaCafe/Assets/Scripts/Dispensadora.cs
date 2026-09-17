using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Dispensadora : MonoBehaviour 
{
    [SerializeField] MaquinaDeCafe maquinaDeCafe;
    [SerializeField] AudioClip audioClipDispensadora;
    private int cantidadParaDispensar = 1;
    public Cafe Dispensar(Cafe cafe) { 
        
        if(cafe.estado == Estados.Dispensando)
        {
            Debug.Log("El cafe ya ha sido servido");
            return cafe;
        }
        Cafe cafeServido = cafe;
        cafeServido.estado = Estados.Dispensando;

        StartCoroutine(TiempoAEsperar(cafeServido, audioClipDispensadora.length));
        return cafeServido;
    }
    private IEnumerator TiempoAEsperar(Cafe cafeProcesado, float tiempoEsperar)
    {
        int tiempoEsperarInt = Convert.ToInt32(tiempoEsperar);
        maquinaDeCafe.EmpezarCuentaRegresiva(tiempoEsperarInt, cafeProcesado.estado);
        maquinaDeCafe.CambiarEstado(cafeProcesado.estado);

        maquinaDeCafe.soundController.PlaySonido(audioClipDispensadora);

        for (int i = tiempoEsperarInt; i > 0; i--)
        {
            yield return new WaitForSeconds(1);
        }
        maquinaDeCafe.SiguienteEtapa(cafeProcesado);

    }

}
