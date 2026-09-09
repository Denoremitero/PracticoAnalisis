using UnityEngine;

public class MaquinaDeCafe : MonoBehaviour
{
    [SerializeField] private Dispensadora dispensadora;
    public void EmpezarCafe(RecetaCafe tipoCafe, Tamanios tamanioCafe)
    {
        Cafe cafe = new Cafe(tipoCafe, tamanioCafe, Estados.SinHacer, new Endulzante(true, TipoEndulzantes.Azucar)); 
        dispensadora.FiltrarCafe(cafe);

    }
}
