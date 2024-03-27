using System;
namespace Punto
{
    public class Empleado
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public double SalarioBasico { get; set; }
        public int HorasExtras { get; set; }
        public double Deducciones { get; set; }
        public double Bonificacion { get; set; }

        public Empleado(int codigo, string nombre, double salarioBasico)
        {
            Codigo = codigo;
            Nombre = nombre;
            SalarioBasico = salarioBasico;
        }

        public double CalcularSalarioTotal()
        {
            double salarioTotal = SalarioBasico + ((SalarioBasico / 8) * (1.5)) - Deducciones + Bonificacion;
            double deduccionSalud = SalarioBasico * 0.07;
            double deduccionPension = SalarioBasico * 0.07;
            salarioTotal -= deduccionSalud + deduccionPension;
            return salarioTotal;
        }
    }

}