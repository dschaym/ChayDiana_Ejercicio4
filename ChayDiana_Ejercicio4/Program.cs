Console.WriteLine("CLASIFICACION DE INCIDENTE DE SEGURIDAD INFORMATICA");
Console.WriteLine("-Ingrese el tipo de incidente de seguridad informática:");
Console.WriteLine("1. Malware");
Console.WriteLine("2. Phishing");
Console.WriteLine("3. Acceso no autorizado");
Console.WriteLine("4. Fuga de informacion");
Console.WriteLine("Ingrese el tipo (1-4)");
int tipoIncidente = int.Parse(Console.ReadLine());

Console.WriteLine("-Activo afectado");
Console.WriteLine("1. PC");
Console.WriteLine("2. Servidor");
Console.WriteLine("3. Base de datos");
Console.WriteLine("4. Red");
Console.WriteLine("Ingrese el activo afectado (1-4)");
int activoAfectado = int.Parse(Console.ReadLine());

Console.WriteLine("-Datos comprendidos");
Console.WriteLine("1. Ninguno");
Console.WriteLine("2. Internos");
Console.WriteLine("3. Personales");
Console.WriteLine("4. Financieros");
Console.WriteLine("Ingrese los datos comprendidos (1-4)");
int datosComprendidos = int.Parse(Console.ReadLine());

Console.WriteLine("Persistencia detectada S/N?");
string persistenciaDetectada = Console.ReadLine();

Console.WriteLine("Numero de usuarios afectados:");
int usuariosAfectados = int.Parse(Console.ReadLine());

if (tipoIncidente < 1 || tipoIncidente > 4)
{
    Console.WriteLine("Entrada no válida. Por favor, ingrese un número entre 1 y 4.");
    return;
}
else if (activoAfectado < 1 || activoAfectado > 4)
{
    Console.WriteLine("Entrada no válida. Por favor, ingrese un número entre 1 y 4.");
    return;
}
else if (datosComprendidos < 1 || datosComprendidos > 4)
{
    Console.WriteLine("Entrada no válida. Por favor, ingrese un número entre 1 y 4.");
    return;
}
else if (persistenciaDetectada.ToUpper() != "S" && persistenciaDetectada.ToUpper() != "N")
{
    Console.WriteLine("Entrada no válida. Por favor, ingrese 'S' o 'N'.");
    return;
}
else if (usuariosAfectados < 0)
{
    Console.WriteLine("Entrada no válida. Por favor, ingrese un número positivo.");
    return;
}
else
{
    Console.WriteLine("Datos validos");
}

// Severidad: 1=Baja, 2=Media, 3=Alta, 4=Crítica
int severidad = 2; // por defecto

switch (tipoIncidente)
{
    case 1: // Malware
        switch (activoAfectado)
        {
            case 1: severidad = 2; break; // PC -> Media
            case 2: severidad = 3; break; // Servidor -> Alta
            case 3: severidad = 3; break; // Base de datos -> Alta
            case 4: severidad = 2; break; // Red -> Media
        }

        if (persistenciaDetectada == "S" && activoAfectado == 2)
        {
            severidad = 4;
        }
        else
        {
            if (persistenciaDetectada == "S" && severidad < 4)
                severidad = severidad + 1;
        }

        // Si hay datos personales/financieros comprometidos, ajustar
        if (datosComprendidos == 4) // financieros
            severidad = 4;
        else if (datosComprendidos == 3 && severidad < 3) // personales
            severidad = 3;
        break;
    case 2: // Phishing
        severidad = 1; // Baja
        if (datosComprendidos == 4)
            severidad = 4; // financieros -> Crítica
        else if (datosComprendidos == 3)
            severidad = 3; // personales -> Alta
        else
        {
            if (usuariosAfectados >= 20) 
                severidad = 2; 
        }
        break;

    case 3: // Acceso no autorizado
        severidad = 3;
        if (activoAfectado == 3 || datosComprendidos == 4)
            severidad = 4;
        else if (datosComprendidos == 3)
            severidad = 3;
        else if (datosComprendidos == 2 && severidad > 2)
            severidad = 2;

        if (persistenciaDetectada == "S" && severidad < 4)
            severidad = severidad + 1;
        break;

    case 4: // Fuga de información
        if (datosComprendidos == 4) severidad = 4;
        else if (datosComprendidos == 3) severidad = 3;
        else if (datosComprendidos == 2) severidad = 2;
        else
        {
            // Sin datos, severidad baja si afecta a pocos usuarios
            if (usuariosAfectados <= 5) severidad = 1;
            else severidad = 2;
        }
        break;
}