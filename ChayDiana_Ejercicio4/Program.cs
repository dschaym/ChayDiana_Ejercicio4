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
