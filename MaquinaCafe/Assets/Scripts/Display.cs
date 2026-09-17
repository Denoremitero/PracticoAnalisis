using System.Collections;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    [SerializeField] MaquinaDeCafe maquinaCafe;
    [SerializeField] Slider sliderCafe;
    [SerializeField] GameObject displayCanvas;
    private RecetaCafe cafeSeleccionado;
    private Tamanios tamanioSeleccionado;

    [SerializeField] TextMeshProUGUI textoEstado;
    [SerializeField] TextMeshProUGUI cuentaRegresiva;

    bool coffeeAlreadySelected;
    bool sizeAlreadySelected;

    public void CafeSeleccionado(RecetaCafe cafe)
    {
        if (!coffeeAlreadySelected)
        {
            cafeSeleccionado = cafe;
            coffeeAlreadySelected = true;
            Confirmar();

        }
        
    }
    public void TamanioSeleccionado(Tamanios tamanio)
    {
        if (!sizeAlreadySelected)
        {
            tamanioSeleccionado = tamanio;
            sizeAlreadySelected = true;
            Confirmar();
        }
    }
    public void SeleccionarChico()
    {
        TamanioSeleccionado(Tamanios.Chico);
    }

    public void SeleccionarMediano()
    {
        TamanioSeleccionado(Tamanios.Mediano);
    }

    public void SeleccionarGrande()
    {
        TamanioSeleccionado(Tamanios.Grande);
    }

    public void ActivarDisplayCanvas(bool isActive)
    {
        displayCanvas.SetActive(isActive);
    }

    private void Confirmar() 
    {
        if (coffeeAlreadySelected && sizeAlreadySelected)
        {
            maquinaCafe.EmpezarCafe(cafeSeleccionado, tamanioSeleccionado);
            ActivarDisplayCanvas(false);
            coffeeAlreadySelected = false;
            sizeAlreadySelected= false;
        }
    }
    public void CambiarEstadoDisplayed(string estado)
    {
        textoEstado.text = estado;
    }
    public IEnumerator CuentaRegresiva(int tiempoEspera, bool isServingCafe)
    {
        if (isServingCafe) EnableSliderCafe(true);
        float amountToAdd = sliderCafe.maxValue / tiempoEspera;
        for (int i = tiempoEspera; i > 0; i--)
        {
            cuentaRegresiva.text = i.ToString();
            if (isServingCafe) SliderCafeFill(amountToAdd);
            yield return new WaitForSeconds(1);
        }
        
    }

    public void EnableSliderCafe(bool enabled)
    {
        sliderCafe.gameObject.SetActive(enabled);
    }
    public void SliderCafeFill(float amount)
    {
        sliderCafe.value += amount;
    }
}
