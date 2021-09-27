using System;
using System.Text;
using System.IO;
namespace Modelodelparcial
{

	class Program
	{

		struct DATOS
		{
			public string CEDULA;
			public string NOMBRE;
			public int TEL;
			public char SEXO;
			public string DIAGNOSTICO;


		}

		static DATOS[] Pacientes = new DATOS[100];
		static int NRO = 0;


		static void Main(string[] args)
		{


			char OP = 'S';
			int TIPO;
			while (OP == 'S')
			{
				TIPO = MENU();
				switch (TIPO)
				{
					case 1:
						CREAR();

						break;
					case 2:
						CONSULTA_LISTADO();

					     break;
					case 3:
						ELIMINAR();

						break;
					case 4:
						MODIFICAR();

						break;
					case 5:
						OP = 'N';

						break;


				}

			}
		}

		static int MENU()
		{

			int OPCION;

			Console.Clear();
			System.Console.SetCursorPosition(29, 6);
			Console.WriteLine("REGISTRO MEDICO");
			System.Console.SetCursorPosition(32, 8);
			Console.WriteLine("CAPTURA DE DATOS");
			System.Console.SetCursorPosition(25, 10);
			Console.WriteLine("                                                  ");
			System.Console.SetCursorPosition(29, 11);
			Console.WriteLine("1. Registro Del Paciente");
			System.Console.SetCursorPosition(29, 12);
			Console.WriteLine("2. CONSULTA  REGISTRO ");
			System.Console.SetCursorPosition(29, 13);
			Console.WriteLine("3. ELIMINAR ");
			System.Console.SetCursorPosition(29, 14);
			Console.WriteLine("4. MODIFICAR ");
			System.Console.SetCursorPosition(29, 15);
			Console.WriteLine("5. SALIR");

			do
			{
				System.Console.SetCursorPosition(22, 20);
				Console.WriteLine("SELECIONE UNA DE LAS ALTERNATIVAS : ");
				System.Console.SetCursorPosition(57, 20); 
				OPCION = int.Parse(Console.ReadLine());
				System.Console.SetCursorPosition(30, 22);
				Console.WriteLine("VALOR FUERA DE RANGO");
			} while ((OPCION < 1) || (OPCION > 6));
			System.Console.SetCursorPosition(30, 22);
			Console.WriteLine("                          ");
			return OPCION;

		}

		static void CREAR()

		{
			TextWriter escribir;
			escribir = new StreamWriter("datos.txt");

			char OP = 'S';
			int SW;
			

			while ((OP == 'S') && (NRO < 100))

			{
				Console.Clear();
				System.Console.SetCursorPosition(20, 6); Console.WriteLine("REGISTRAR PACIENTE");
				System.Console.SetCursorPosition(20, 11); Console.WriteLine("CEDULA   : ");
				System.Console.SetCursorPosition(20, 13); Console.WriteLine("NOMBRE   : ");
				System.Console.SetCursorPosition(20, 15); Console.WriteLine("TELEFONO : ");
				System.Console.SetCursorPosition(20, 17); Console.WriteLine("SEXO     : ");
				System.Console.SetCursorPosition(20, 19); Console.WriteLine("DIAGNOSTICO    : ");

				Console.SetCursorPosition(31, 11); Pacientes[NRO].CEDULA = Console.ReadLine();
				SW = 0;
				for (int K = 0; K < NRO & SW == 0; K++)
				{
					do
					{
						if (Pacientes[NRO].CEDULA == Pacientes[K].CEDULA)
						{
							SW = 1;
							Console.SetCursorPosition(15, 23); Console.WriteLine(" YA SE ENCUENTRA REGISTRADO");
							Console.ReadKey();
							Console.SetCursorPosition(15, 23); Console.WriteLine("                                   ");
							Console.SetCursorPosition(31, 11); Console.WriteLine("                           ");
							Console.SetCursorPosition(31, 11); Pacientes[NRO].CEDULA = Console.ReadLine();

						}
					} while (Pacientes[NRO].CEDULA == Pacientes[K].CEDULA);


				}


				System.Console.SetCursorPosition(31, 13);
				Pacientes[NRO].NOMBRE = Console.ReadLine();
				System.Console.SetCursorPosition(31, 13); Console.WriteLine((Pacientes[NRO].NOMBRE));
				do
				{
					System.Console.SetCursorPosition(31, 15);
					Pacientes[NRO].TEL = int.Parse(Console.ReadLine());
					System.Console.SetCursorPosition(20, 24); Console.WriteLine("Error .... valor fuera de rango ");
				} while (Pacientes[NRO].TEL < 0);
				System.Console.SetCursorPosition(20, 24); Console.WriteLine("                                   ");
				do
				{
					System.Console.SetCursorPosition(31, 17); Console.WriteLine(" ");
					System.Console.SetCursorPosition(20, 24); Console.WriteLine(" Digite : M-> Masculino o F -> Femenino ");
					System.Console.SetCursorPosition(31, 17); 
					Pacientes[NRO].SEXO = char.Parse(Console.ReadLine());
					Pacientes[NRO].SEXO = (Pacientes[NRO].SEXO);

				} while ((Pacientes[NRO].SEXO != 'M') && (Pacientes[NRO].SEXO != 'F'));
				System.Console.SetCursorPosition(20, 24); Console.WriteLine("                                              ");
				System.Console.SetCursorPosition(37, 19);
				Pacientes[NRO].DIAGNOSTICO = Console.ReadLine();
				escribir.WriteLine("");
				escribir.WriteLine(Pacientes[NRO].CEDULA + "," + Pacientes[NRO].NOMBRE + "," + Pacientes[NRO].TEL + "," + Pacientes[NRO].SEXO + "," + Pacientes[NRO].DIAGNOSTICO);

				NRO = NRO + 1;



				do
				{
					System.Console.SetCursorPosition(28, 23); Console.WriteLine("DESEA CONTINUAR - S/N - ");
					System.Console.SetCursorPosition(52, 23); OP = char.Parse(Console.ReadLine());


				} while ((OP != 'S') && (OP != 'N'));



			}
			escribir.Close();
		}

		static void CONSULTA_LISTADO()
		{
			using (StreamReader leer = new StreamReader("datos.txt"))
				
			{

				System.Console.SetCursorPosition(0, 28); Console.WriteLine("REGISTRO DE PACIENTES");
				System.Console.SetCursorPosition(0, 29); Console.WriteLine("CEDULA    NOMBRE    TELEFONO   SEXO    DIAGNOSTICO");
				while (!leer.EndOfStream) 
				{
					string x = leer.ReadLine();
					
					Console.WriteLine(x);
				}
				Console.ReadKey();
			}
            
		}

		
		static void MODIFICAR()
		{
			int K, SW, TEL;
			char cambiar, OPCION = 'S';
			string NOMBRE, DIAG;
			char SEXO;
			string CED;
			TextWriter escribir;
			escribir = new StreamWriter("datosMOD.txt");
			if (NRO == 0)
			{
				System.Console.SetCursorPosition(20, 24); Console.WriteLine("No hay datos ");
				Console.ReadKey();
			}
			else
			{
				while (OPCION == 'S')
				{
					Console.Clear();
					System.Console.SetCursorPosition(36, 5); Console.WriteLine("REGISTRO MEDICO");
					System.Console.SetCursorPosition(36, 6); Console.WriteLine("MODIFICAR");
					System.Console.SetCursorPosition(20, 11); Console.WriteLine("CEDULA   : ");

					System.Console.SetCursorPosition(31, 11); CED = (Console.ReadLine());


					SW = 0;
					for (K = 0; K < NRO && SW == 0; K++)
						if (CED == Pacientes[K].CEDULA)
						{
							SW = 1;
							System.Console.SetCursorPosition(20, 13); Console.WriteLine("NOMBRE   = " + Pacientes[K].NOMBRE);
							System.Console.SetCursorPosition(20, 15); Console.WriteLine("TELEFONO = " + Pacientes[K].TEL);
							System.Console.SetCursorPosition(20, 17); Console.WriteLine("SEXO     = " + Pacientes[K].SEXO);
							System.Console.SetCursorPosition(20, 19); Console.WriteLine("DIAGNOSTICO   = " + Pacientes[K].DIAGNOSTICO);
							System.Console.SetCursorPosition(5, 22); Console.WriteLine("N-> NOMBRE, T-> TELEFENO, S-> SEXO, D-> DIAGNOSTICO");
							System.Console.SetCursorPosition(60, 11); Console.WriteLine("¿QUE CAMPO QUIERE MODIFICAR? : ");
							System.Console.SetCursorPosition(93, 11); cambiar = char.Parse(Console.ReadLine());


							switch (cambiar)
							{
								case 'N':
									System.Console.SetCursorPosition(60, 13); Console.WriteLine("DIGITE NUEVO NOMBRE : ");
									System.Console.SetCursorPosition(81, 13); NOMBRE = Console.ReadLine();
									Pacientes[K].NOMBRE = NOMBRE;
									break;

								case 'T':
									System.Console.SetCursorPosition(60, 13); Console.WriteLine("DIGITE NUEVO TELEFENO : ");
									System.Console.SetCursorPosition(84, 13); TEL = int.Parse(Console.ReadLine());
									Pacientes[K].TEL = TEL;
									break;

								case 'S':
									System.Console.SetCursorPosition(60, 13); Console.WriteLine("DIGITE SEXO : ");
									System.Console.SetCursorPosition(84, 13); SEXO = char.Parse(Console.ReadLine());
									Pacientes[K].SEXO = SEXO;
									break;

								case 'D':
									System.Console.SetCursorPosition(60, 13); Console.WriteLine("DIGITE NUEVO DIAGNOSTICO : ");
									System.Console.SetCursorPosition(88, 13); DIAG = Console.ReadLine();
									Pacientes[K].DIAGNOSTICO = DIAG;
									break;
							}

							System.Console.SetCursorPosition(60, 17); Console.WriteLine("REGISTRO MODIFICADO");
						}
					if (SW == 0)
					{
						System.Console.SetCursorPosition(50, 18); Console.WriteLine("NO EXISTE REGISTRO");
					}
					
					do
					{
						System.Console.SetCursorPosition(28, 24); Console.WriteLine("DESEA CONTINUAR - S/N - ");
						System.Console.SetCursorPosition(52, 24); OPCION = char.Parse(Console.ReadLine());
					} while ((OPCION != 'S') && (OPCION != 'N'));
				}escribir.Close();
				File.Delete("datos.txt");
				File.Move("datosMOD.txt", "datos.txt");
			}
		}

		static void ELIMINAR()

		{
			char OP = 'S';
			string CED;
			int K, W, SW;
			string cadena, cadena1;
			StreamReader lectura = File.OpenText("datos.txt");
			StreamWriter escribir = File.CreateText("tempo.txt");
			bool encontrado;
			encontrado = false;
			String[] campos = new string[5];
			char[] separador = { ',' };
			
			while ((OP == 'S'))

			{
				
				
					Console.Clear();
					System.Console.SetCursorPosition(29, 5); Console.WriteLine("REGISTRO MEDICO");
					System.Console.SetCursorPosition(36, 7); Console.WriteLine("ELMINAR PACIENTE");
					System.Console.SetCursorPosition(25, 11); Console.WriteLine("CEDULA    : ");
					System.Console.SetCursorPosition(37, 11); CED = (Console.ReadLine());
				cadena = lectura.ReadLine();

				while (cadena != null)
					{
						campos = cadena.Split(separador);
						if (campos[0].Trim().Equals(CED))
						{

							encontrado = true;

						}
						else
						{
							escribir.WriteLine(cadena);
						}
						cadena = lectura.ReadLine();
					}

						if (encontrado == false)
						{
							Console.WriteLine("el paciente de cedula: " + CED + "no se encuentra");
						}


						do
						{
							System.Console.SetCursorPosition(28, 24); Console.WriteLine("DESEA CONTINUAR - S/N - ");
							System.Console.SetCursorPosition(52, 24); OP = char.Parse(Console.ReadLine());

						} while ((OP != 'S') && (OP != 'N'));
						lectura.Close();
						escribir.Close();
						File.Delete("datos.txt");
						File.Move("tempo.txt", "datos.txt");
					}
					Console.ReadKey(true);
				

			   
			}
			static void DETALLE()
			{
				Console.Clear();
				System.Console.SetCursorPosition(38, 3); Console.WriteLine("REGISTRO MEDICO");
				System.Console.SetCursorPosition(30, 5); Console.WriteLine("LISTA DE PACIENTES REGISTRADOS");
				System.Console.SetCursorPosition(12, 9); Console.WriteLine("CEDULA      NOMBRE                         TELEFONO     SEXO    DIAGNOSTICO ");
			}



		}



	}
