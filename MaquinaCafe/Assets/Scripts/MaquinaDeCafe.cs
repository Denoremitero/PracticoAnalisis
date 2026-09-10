using UnityEngine;

public class MaquinaDeCafe : MonoBehaviour
{
    [SerializeField] private Dispensadora dispensadora;
    [SerializeField] private Mezcladora mezcladora;
    [SerializeField] private Filtradora filtradora;
    [SerializeField] private Recibo recibo;
    public void EmpezarCafe(RecetaCafe tipoCafe, Tamanios tamanioCafe)
    {
        Cafe cafe = new Cafe(tipoCafe, tamanioCafe, Estados.SinHacer, new Endulzante(true, TipoEndulzantes.Azucar)); 
        SiguienteEtapa(cafe);

    }
    public void SiguienteEtapa(Cafe cafe)
    {
        switch (cafe.estado)
        {
            case Estados.SinHacer:
                filtradora.FiltrarCafe(cafe); break;
            case Estados.Filtrado:
                mezcladora.Mezclar(cafe); break;
            case Estados.Mezclado:
                dispensadora.Dispensar(cafe); break;
            case Estados.Servido:
                recibo.MostrarCafe(cafe); break;

        }
    }
}
