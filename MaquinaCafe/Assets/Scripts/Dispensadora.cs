using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Dispensadora : MonoBehaviour 
{
    [SerializeField] MaquinaDeCafe maquinaDeCafe;
    private int cantidadParaDispensar = 1;
    public Cafe Dispensar(Cafe cafe) { 
        
        if(cafe.estado == Estados.Servido)
        {
            Debug.Log("El cafe ya ha sido servido");
            return cafe;
        }
        Cafe cafeServido = cafe;
        Debug.Log("El cafe se está dispensando");
        cafeServido.estado = Estados.Servido;
        maquinaDeCafe.SiguienteEtapa(cafeServido);
        return cafeServido;
    }
    
}
