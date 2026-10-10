using System;

Console.WriteLine("SISTEMA DE INSPECCIÓN DE LOTE");
Console.WriteLine();

// Crear un objeto de la clase LotePiezas
LotePiezas lote1 = new LotePiezas();

// Capturar la información con un ciclo for (10 piezas)
for (int i = 1; i <= 10; i++)
{
    int estado = -1;

    // Ciclo para rechazar valores inválidos
    while (estado != 0 && estado != 1)
    {
        Console.Write($"Ingrese el estado de la pieza {i} (1 = Correcta, 0 = Defectuosa): ");

        try
        {
            estado = Convert.ToInt32(Console.ReadLine());

            if (estado != 0 && estado != 1)
            {
                Console.WriteLine("Valor inválido. Solo se acepta 1 o 0.");
            }
        }
        catch
        {
            Console.WriteLine("Error: Ingrese un valor numérico (1 o 0).");
            estado = -1;
        }
    }

    if (estado == 1)
    {
        lote1.PiezasCorrectas++;
    }
    else
    {
        lote1.PiezasDefectuosas++;
    }
}

// Solicitar al objeto que calcule su porcentaje
double porcentaje = lote1.CalcularPorcentaje();

// Mostrar resultados
Console.WriteLine();
Console.WriteLine($"Piezas correctas: {lote1.PiezasCorrectas} pcs");
Console.WriteLine($"Piezas defectuosas: {lote1.PiezasDefectuosas} pcs");
Console.WriteLine($"Porcentaje: {porcentaje:F2} %");
Console.WriteLine($"Estado del lote: {lote1.ObtenerEstado()}");


// Definición de la clase
class LotePiezas
{
    // Propiedades
    public int PiezasCorrectas { get; set; } = 0;

    public int PiezasDefectuosas { get; set; } = 0;


    // Método para calcular el porcentaje
    public double CalcularPorcentaje()
    {
        double porcentaje;
        int total = PiezasCorrectas + PiezasDefectuosas;

        if (total == 0)
        {
            return 0.0;
        }

        porcentaje = (Convert.ToDouble(PiezasCorrectas) / total) * 100.0;

        return porcentaje;
    }


    // Método para determinar el estado
    public string ObtenerEstado()
    {
        double porcentaje = CalcularPorcentaje();

        if (porcentaje >= 90)
        {
            return "ACEPTADO";
        }
        else
        {
            return "RECHAZADO";
        }
    }
}