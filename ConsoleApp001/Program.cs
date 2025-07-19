using ConsoleApp001;

Random rnd = new Random();

List<OperacionDivision> Valores = new List<OperacionDivision>();

for (int i = 0; i < 10; i++)
{
    int probabilidad = rnd.Next(1, 10);

    int numero1 = i + 1;
    double numero2;


    if (probabilidad < 2)
    {
        numero2 = rnd.NextDouble() * (i + 1);
        numero2 = 0;
    }
    else if (probabilidad > 2 && probabilidad < 6)
    {
        numero2 = -1;
    }
    else
    {
        numero2 = i + 1;
    }

    try
    {
        OperacionDivision operacion = new OperacionDivision(numero1, Convert.ToInt32(numero2));
        Valores.Add(operacion);

        Console.WriteLine($"División de {operacion.num1} entre {operacion.num2} es: {operacion.resultado}");
    }
    catch (Exception ex)
    {
        Console.Write("Excepción: ");
        Console.Write("Tipo: " + ex.GetType().Name);        // Nombre corto
        Console.Write("Tipo completo: " + ex.GetType().FullName);  // Nombre completo con namespace
        Console.Write("Mensaje: " + ex.Message+"\n");
    }        
}


    


