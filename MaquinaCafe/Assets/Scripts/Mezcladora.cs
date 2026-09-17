using System;
using System.Collections;
using UnityEngine;

public class Mezcladora : MonoBehaviour
{
    [SerializeField] MaquinaDeCafe maquinaDeCafe;
    [SerializeField] AudioClip audioClipMezcladora;
    public Cafe Mezclar(Cafe cafe)
    {
        if (cafe.estado == Estados.Mezclando)
        {
            Debug.Log("El cafe ya ha sido mezclado");
            return cafe;
        }
        Cafe cafeMezclado = cafe;
        cafeMezclado = SizeAdapt(cafeMezclado);
        cafeMezclado.estado = Estados.Mezclando;
        StartCoroutine(TiempoAEsperar(cafeMezclado, audioClipMezcladora.length));

        return cafeMezclado;
    }
    private IEnumerator TiempoAEsperar(Cafe cafeProcesado, float tiempoEsperar)
    {
        int tiempoEsperarInt = Convert.ToInt32(tiempoEsperar);
        maquinaDeCafe.EmpezarCuentaRegresiva(tiempoEsperarInt, cafeProcesado.estado);
        maquinaDeCafe.CambiarEstado(cafeProcesado.estado);

        maquinaDeCafe.soundController.PlaySonido(audioClipMezcladora);

        for (int i = tiempoEsperarInt; i > 0; i--)
        {
            yield return new WaitForSeconds(1);
        }
        maquinaDeCafe.SiguienteEtapa(cafeProcesado);

    }
    private Cafe SizeAdapt(Cafe cafe)
    {
        if(cafe.tamanio == Tamanios.Mediano)
        {
            foreach(Aniadido aniadido in cafe.recetaCafe.aniadidos)
            {
                aniadido.cantidad *= 2;
            }
        }
        else if (cafe.tamanio == Tamanios.Grande)
        {
            foreach (Aniadido aniadido in cafe.recetaCafe.aniadidos)
            {
                aniadido.cantidad *= 4;
            }
        }

        return cafe;
    }
}
