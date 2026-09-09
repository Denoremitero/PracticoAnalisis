using System.Xml.Serialization;
using UnityEngine;

public class Display : MonoBehaviour
{
    [SerializeField] MaquinaDeCafe maquinaCafe;
    private RecetaCafe cafeSeleccionado;
    private Tamanios tamanioSeleccionado;

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

    private void Confirmar() 
    {
        if (coffeeAlreadySelected && sizeAlreadySelected)
        {
            maquinaCafe.EmpezarCafe(cafeSeleccionado, tamanioSeleccionado);
            coffeeAlreadySelected = false;
            sizeAlreadySelected= false;
        }
    }
}
