using System;

namespace Modelodelparcial
{
	class Program
	{

		struct DATOS
		{
			public int CEDULA;
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
						CONSULTA_SELECTIVA();

						break;
					case 4:
						ELIMINAR();

						break;
					case 5:
						MODIFICAR();

						break;
					case 6:
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
			Console.WriteLine("1. CAPTURA DE DATOS");
			System.Console.SetCursorPosition(29, 12);
			Console.WriteLine("2. CONSULTA  TIPO LISTADO");
			System.Console.SetCursorPosition(29, 13);
			Console.WriteLine("3. CONSULTA SELECTIVA");
			System.Console.SetCursorPosition(29, 14);
			Console.WriteLine("4. ELIMINAR ");
			System.Console.SetCursorPosition(29, 15);
			Console.WriteLine("5. MODIFICAR ");
			System.Console.SetCursorPosition(29, 17);
			Console.WriteLine("6. SALIR");

			do
			{
				System.Console.SetCursorPosition(22, 20);
				Console.WriteLine("SELECIONE UNA DE LAS ALTERNATIVAS : ");
				System.Console.SetCursorPosition(57, 20); OPCION = int.Parse(Console.ReadLine());
				System.Console.SetCursorPosition(30, 22);
				Console.WriteLine("VALOR FUERA DE RANGO");
			} while ((OPCION < 1) || (OPCION > 6));
			System.Console.SetCursorPosition(30, 22);
			Console.WriteLine("                          ");
			return OPCION;

		}
		static void CREAR()
		{
			char OP = 'S';

			while ((OP == 'S') && (NRO < 100))
			{
				Console.Clear();
				System.Console.SetCursorPosition(20, 6); Console.WriteLine("REGISTRAR PACIENTE");
				System.Console.SetCursorPosition(20, 11); Console.WriteLine("CEDULA   : ");
				System.Console.SetCursorPosition(20, 13); Console.WriteLine("NOMBRE   : ");
				System.Console.SetCursorPosition(20, 15); Console.WriteLine("TELEFONO : ");
				System.Console.SetCursorPosition(20, 17); Console.WriteLine("SEXO     : ");
				System.Console.SetCursorPosition(20, 19); Console.WriteLine("DIAGNOSTICO    : ");
				do
				{
					System.Console.SetCursorPosition(31, 11);
					Pacientes[NRO].CEDULA = int.Parse(Console.ReadLine());

					System.Console.SetCursorPosition(20, 24); Console.WriteLine("Error .... valor fuera de rango ");
				} while (Pacientes[NRO].CEDULA < 0);
				System.Console.SetCursorPosition(20, 24); Console.WriteLine("                                   ");

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
					System.Console.SetCursorPosition(31, 17); Pacientes[NRO].SEXO = char.Parse(Console.ReadLine());
					Pacientes[NRO].SEXO = (Pacientes[NRO].SEXO);
				} while ((Pacientes[NRO].SEXO != 'M') && (Pacientes[NRO].SEXO != 'F'));
				System.Console.SetCursorPosition(20, 24); Console.WriteLine("                                              ");

				System.Console.SetCursorPosition(37, 19);
				Pacientes[NRO].DIAGNOSTICO = Console.ReadLine();



				NRO = NRO + 1;
				do
				{
					System.Console.SetCursorPosition(28, 23); Console.WriteLine("DESEA CONTINUAR - S/N - ");
					System.Console.SetCursorPosition(52, 23); OP = char.Parse(Console.ReadLine());

				} while ((OP != 'S') && (OP != 'N'));
			}
		}

		static void CONSULTA_LISTADO()
		{
			int F, K;
			if (NRO == 0)
			{
				System.Console.SetCursorPosition(20, 24); Console.WriteLine("No hay datos ");
				Console.ReadKey();
			}
			else
			{
				F = 11;
				DETALLE();
				for (K = 0; K < NRO; K++)
				{
					System.Console.SetCursorPosition(12, F); Console.WriteLine(Pacientes[K].CEDULA);
					System.Console.SetCursorPosition(24, F); Console.WriteLine(Pacientes[K].NOMBRE);
					System.Console.SetCursorPosition(55, F); Console.WriteLine(Pacientes[K].TEL);
					System.Console.SetCursorPosition(68, F); Console.WriteLine(Pacientes[K].SEXO);
					System.Console.SetCursorPosition(76, F); Console.WriteLine(Pacientes[K].DIAGNOSTICO);
					if (F <= 24)
						F++;
					else
					{
						System.Console.SetCursorPosition(21, F += 3); Console.WriteLine("Pulse Cualquier tecla para Continuar");
						Console.ReadKey();
						F = 11;
						DETALLE();
					}
				}
				System.Console.SetCursorPosition(21, F += 3); Console.WriteLine("Pulse Cualquier tecla para Continuar");
				Console.ReadKey();
			}
		}
		static void CONSULTA_SELECTIVA()
		{
			long CED;
			int K, SW;
			char OPCION = 'S';
			if (NRO == 0)
			{
				System.Console.SetCursorPosition(20, 22); Console.WriteLine("No hay datos ");
				Console.ReadKey();
			}
			else
			{
				while (OPCION == 'S')
				{
					Console.Clear();
					System.Console.SetCursorPosition(29, 5); Console.WriteLine("REGISTRO MEDICO");
					System.Console.SetCursorPosition(31, 7); Console.WriteLine("BUSQUEDA SELECTIVA");
					System.Console.SetCursorPosition(25, 11); Console.WriteLine("CEDULA    : ");
					do
					{
						System.Console.SetCursorPosition(37, 11); CED = long.Parse(Console.ReadLine());
						System.Console.SetCursorPosition(20, 24); Console.WriteLine("Error .... valor fuera de rango ");
					} while (CED < 0);
					System.Console.SetCursorPosition(20, 24); Console.WriteLine("                                   ");
					SW = 0;
					for (K = 0; K < NRO && SW == 0; K++)
						if (CED == Pacientes[K].CEDULA)
						{
							SW = 1;
							System.Console.SetCursorPosition(25, 13); Console.WriteLine("NOMBRE    = " + Pacientes[K].NOMBRE);
							System.Console.SetCursorPosition(25, 15); Console.WriteLine("TELEFONO  = " + Pacientes[K].TEL);
							System.Console.SetCursorPosition(25, 17); Console.WriteLine("SEXO      = " + Pacientes[K].SEXO);
							System.Console.SetCursorPosition(25, 19); Console.WriteLine("SEXO      = " + Pacientes[K].DIAGNOSTICO);
						}
					if (SW == 0)
					{
						System.Console.SetCursorPosition(50, 11); Console.WriteLine("NO EXISTE REGISTRO");
					}
					do
					{
						System.Console.SetCursorPosition(28, 22); Console.WriteLine("DESEA CONTINUAR - S/N - ");
						System.Console.SetCursorPosition(52, 22); OPCION = char.Parse(Console.ReadLine());

					} while ((OPCION != 'S') && (OPCION != 'N'));
				}
			}
		}
		static void MODIFICAR()
		{

		}

		static void ELIMINAR()
		{
			char OP = 'S';
			long CED;
			int K, W, SW;
			while ((OP == 'S'))
			{
				if (NRO == 0)
				{
					System.Console.SetCursorPosition(20, 24); Console.WriteLine("No hay datos                        ");
					OP = 'N';
					Console.ReadKey();
				}
				else
				{
					Console.Clear();
					System.Console.SetCursorPosition(29, 5); Console.WriteLine("REGISTRO MEDICO");
					System.Console.SetCursorPosition(36, 7); Console.WriteLine("ELMINAR PACIENTE");
					System.Console.SetCursorPosition(25, 11); Console.WriteLine("CEDULA    : ");
					do
					{
						System.Console.SetCursorPosition(37, 11); CED = long.Parse(Console.ReadLine());
						System.Console.SetCursorPosition(20, 24); Console.WriteLine("Error .... valor fuera de rango ");
					} while (CED < 0);
					System.Console.SetCursorPosition(20, 24); Console.WriteLine("                                      ");
					SW = 0;
					for (K = 0; K < NRO && SW == 0; K++)
						if (CED == Pacientes[K].CEDULA)
						{
							System.Console.SetCursorPosition(25, 13); Console.WriteLine("NOMBRE    = " + Pacientes[K].NOMBRE);
							System.Console.SetCursorPosition(25, 15); Console.WriteLine("TELEFONO  = " + Pacientes[K].TEL);
							System.Console.SetCursorPosition(25, 17); Console.WriteLine("SEXO      = " + Pacientes[K].SEXO);
							System.Console.SetCursorPosition(25, 19); Console.WriteLine("SEXO      = " + Pacientes[K].DIAGNOSTICO);
							SW = 1;
							for (W = K; W < NRO; W++)
							{
								Pacientes[W].CEDULA = Pacientes[W + 1].CEDULA;
								Pacientes[W].NOMBRE = Pacientes[W + 1].NOMBRE;
								Pacientes[W].TEL = Pacientes[W + 1].TEL;
								Pacientes[W].SEXO = Pacientes[W + 1].SEXO;
							}
							NRO = NRO - 1;
							System.Console.SetCursorPosition(50, 11); Console.WriteLine("Elemento Eliminado");
						}
					if (SW == 0)
					{
						System.Console.SetCursorPosition(50, 11); Console.WriteLine("NO EXISTE REGISTRO");
					}
					do
					{
						System.Console.SetCursorPosition(28, 24); Console.WriteLine("DESEA CONTINUAR - S/N - ");
						System.Console.SetCursorPosition(52, 24); OP = char.Parse(Console.ReadLine());

					} while ((OP != 'S') && (OP != 'N'));
				}
			}
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
