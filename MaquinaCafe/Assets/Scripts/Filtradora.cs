using System;
using System.Collections;
using UnityEngine;

public class Filtradora : MonoBehaviour
{
    [SerializeField] MaquinaDeCafe maquinaDeCafe;
    [SerializeField] AudioClip audioClipFiltradora;
    
    public Cafe FiltrarCafe(Cafe cafe)
    {
        if (cafe.estado == Estados.Filtrando)
        {
            return cafe;
        }
        Cafe cafeFiltrado = cafe;
        cafeFiltrado = SizeAdapt(cafeFiltrado);
        cafeFiltrado.estado = Estados.Filtrando;
        StartCoroutine(TiempoAEsperar(cafeFiltrado, audioClipFiltradora.length));
        
        return cafeFiltrado;
    }
    private IEnumerator TiempoAEsperar(Cafe cafeFiltrado, float tiempoEsperar)
    {
        int tiempoEsperarInt = Convert.ToInt32(tiempoEsperar);
        maquinaDeCafe.EmpezarCuentaRegresiva(tiempoEsperarInt, cafeFiltrado.estado);
        maquinaDeCafe.CambiarEstado(cafeFiltrado.estado);

        maquinaDeCafe.soundController.PlaySonido(audioClipFiltradora);

        for (int i = tiempoEsperarInt; i > 0; i--)
        {
            yield return new WaitForSeconds(1);
        }
        maquinaDeCafe.SiguienteEtapa(cafeFiltrado);

    }
    private Cafe SizeAdapt(Cafe cafe)
    {
        if (cafe.tamanio == Tamanios.Mediano)
        {
            cafe.recetaCafe.cantidadAgua *= 2;
            cafe.recetaCafe.cantidadCafe *= 2;


        }
        else if (cafe.tamanio == Tamanios.Grande)
        {
            cafe.recetaCafe.cantidadCafe *= 4;
            cafe.recetaCafe.cantidadAgua *= 4;
        }
        return cafe;
    }
}
