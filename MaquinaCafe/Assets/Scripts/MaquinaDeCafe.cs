using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;

public class MaquinaDeCafe : MonoBehaviour
{
    [SerializeField] private Dispensadora dispensadora;
    [SerializeField] private Mezcladora mezcladora;
    [SerializeField] private Filtradora filtradora;
    [SerializeField] private Display display;
    [SerializeField] private Recibo recibo;

    [SerializeField] public SoundController soundController;

    [SerializeField] private AudioClip audioClipSucces;
    public void EmpezarCafe(RecetaCafe tipoCafe, Tamanios tamanioCafe)
    {
        Cafe cafe = new Cafe(tipoCafe, tamanioCafe, Estados.SinHacer, new Endulzante(true, TipoEndulzantes.Azucar));
        SiguienteEtapa(cafe); 
        recibo.gameObject.SetActive(false);
        display.EnableSliderCafe(false);

    }
    public void SiguienteEtapa(Cafe cafe)
    {
        switch (cafe.estado)
        {
            case Estados.SinHacer:
                filtradora.FiltrarCafe(cafe); break;
            case Estados.Filtrando:
                mezcladora.Mezclar(cafe); break;
            case Estados.Mezclando:
                dispensadora.Dispensar(cafe); break;
            case Estados.Dispensando:
                recibo.gameObject.SetActive(true);
                recibo.MostrarCafe(cafe); 
                CambiarEstado(Estados.Listo);
                soundController.PlaySonido(audioClipSucces);
                display.ActivarDisplayCanvas(true);
                break;

                

        }
    }
    public void EmpezarCuentaRegresiva(int tiempoCuenta, Estados estado)
    {
        if (estado != Estados.Dispensando) StartCoroutine(display.CuentaRegresiva(tiempoCuenta, false));
        else StartCoroutine(display.CuentaRegresiva(tiempoCuenta, true));



    }
    public void CambiarEstado(Estados estado)
    {
        string estadoString = estado.ToString();
        display.CambiarEstadoDisplayed(estadoString);
    }
}
