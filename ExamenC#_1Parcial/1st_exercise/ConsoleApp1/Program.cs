using System;

class Ejercicio1
{
    static void Main()
    {
        // Pedimos los dos valores al usuario
        Console.Write("Digite el primer valor: ");
        double valor1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Digite el segundo valor: ");
        double valor2 = Convert.ToDouble(Console.ReadLine());

        // Mostramos la suma
        Console.WriteLine("\nSuma: " + (valor1 + valor2));

        // Mostramos la resta
        Console.WriteLine("Resta: " + (valor1 - valor2));

        // Mostramos la multiplicación
        Console.WriteLine("Multiplicación: " + (valor1 * valor2));

        // Verificamos que no se divida entre cero
        if (valor2 != 0)
        {
            Console.WriteLine("División: " + (valor1 / valor2));
        }
        else
        {
            Console.WriteLine("División: No se puede dividir entre cero.");
        }

        // Mostramos la raíz cuadrada del primer valor
        if (valor1 >= 0)
        {
            Console.WriteLine("Raíz cuadrada de " + valor1 + ": " + Math.Sqrt(valor1));
        }
        else
        {
            Console.WriteLine("El primer valor no tiene raíz cuadrada real.");
        }

        // Mostramos la raíz cuadrada del segundo valor
        if (valor2 >= 0)
        {
            Console.WriteLine("Raíz cuadrada de " + valor2 + ": " + Math.Sqrt(valor2));
        }
        else
        {
            Console.WriteLine("El segundo valor no tiene raíz cuadrada real.");
        }
    }
}