using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] planta;
            try
            {
                Console.WriteLine("Digite o  tamanho de largura (X) da sua horta: ");
                int plantaValorX = int.Parse(Console.ReadLine());
                Console.WriteLine("\nDigite o tamanho de comprimento (Y) da sua horta: ");
                int plantaValorY = int.Parse(Console.ReadLine());
                planta = new int[plantaValorX, plantaValorY];

                Console.WriteLine("\nQual posição o robo iniciará? \n(Ex: 2,3 [x,y])");
                string posRb = Console.ReadLine();
                string[] posRbSplit = posRb.Split(',');
                int xRb = int.Parse(posRbSplit[0].Replace(" ", ""));
                int yRb = int.Parse(posRbSplit[1].Replace(" ", ""));

                Console.WriteLine("\nQual orientação o robo iniciará?\n" +
                    "(N) -> Norte\n" +
                    "(L) -> Leste\n" +
                    "(S) -> Sul\n" +
                    "(O) -> Oeste");
                string orientRb = Console.ReadLine();
                orientRb = orientRb.ToUpper();
                string orientIcon = directionIcon(orientRb);


                Console.WriteLine("\nDigite a quantidade de canteiros que necessitam irrigação:");
                int qtdCanteirosNeedIrrigacao = int.Parse(Console.ReadLine());
                string[] lugaresParaIrrigar = new string[qtdCanteirosNeedIrrigacao];
                for (int i = 0; i < qtdCanteirosNeedIrrigacao; i++)
                {
                    Console.WriteLine("\nDiga a coordenada do canteiro (X,Y) a ser irrigado:");
                    string posicaoXYIrrigar = Console.ReadLine();
                    lugaresParaIrrigar[i] = posicaoXYIrrigar;
                }

                showCase(plantaValorY, plantaValorX, posRb, lugaresParaIrrigar, orientIcon);

                string caminhoCmpl = "[ ";

                foreach (string lugar in lugaresParaIrrigar)
                {
                    string[] lugarSplit = lugar.Split(",");
                    int lugarX = int.Parse(lugarSplit[0]);
                    int lugarY = int.Parse(lugarSplit[1]);

                    while (lugar != posRb)
                    {
                        string movimento = "";


                        if (lugarX > xRb)
                        {
                            if (orientRb == "L")
                            {
                                //mover
                                xRb = xRb + 1;
                                movimento = "M";


                            }

                            else if (orientRb == "N" || orientRb == "O")
                            {
                                movimento = "D";
                                //mover 90º Direita
                                if (orientRb == "N")
                                {
                                    orientRb = "L";
                                }
                                else if (orientRb == "O")
                                {
                                    orientRb = "N";
                                }
                            }

                            else if (orientRb == "S")
                            {
                                movimento = "E";
                                //mover 90º Esquerda
                                orientRb = "L";
                            }
                        }
                        else if (lugarX < xRb)
                        {
                            if (orientRb == "O")
                            {
                                //mover
                                xRb = xRb - 1;
                                movimento = "M";

                            }

                            else if (orientRb == "N" || orientRb == "L")
                            {
                                movimento = "E";
                                //mover 90º Esquerda
                                if (orientRb == "N")
                                {
                                    orientRb = "O";
                                }
                                else if (orientRb == "L")
                                {
                                    orientRb = "N";
                                }

                            }

                            else if (orientRb == "S")
                            {
                                movimento = "D";
                                //mover 90º Direita
                                orientRb = "O";
                            }
                        }

                        else if (lugarX == xRb)
                        {
                            if (lugarY > yRb)
                            {
                                if (orientRb == "N")
                                {
                                    //mover
                                    yRb = yRb + 1;
                                    movimento = "M";

                                }

                                else if (orientRb == "S" || orientRb == "O")
                                {
                                    movimento = "D";
                                    //mover 90º Direita
                                    if (orientRb == "O")
                                    {
                                        orientRb = "N";
                                    }
                                    else if (orientRb == "S")
                                    {
                                        orientRb = "O";
                                    }
                                }

                                else if (orientRb == "L")
                                {
                                    movimento = "E";
                                    //mover 90º Esquerda
                                    orientRb = "N";
                                }
                            }
                            else if (lugarY < yRb)
                            {
                                if (orientRb == "S")
                                {
                                    //mover
                                    yRb = yRb - 1;
                                    movimento = "M";
                                }

                                else if (orientRb == "N" || orientRb == "O")
                                {
                                    movimento = "E";
                                    //mover 90º Esquerda
                                    if (orientRb == "N")
                                    {
                                        orientRb = "O";
                                    }
                                    else if (orientRb == "O")
                                    {
                                        orientRb = "S";
                                    }
                                }

                                else if (orientRb == "L")
                                {
                                    //mover 90º Direita
                                    orientRb = "S";
                                    movimento = "D";

                                }
                            }
                            
                        }

                        if (movimento == "M")
                        {
                            posRb = xRb.ToString() + "," + yRb.ToString();
                        }

                        //Final do While
                        caminhoCmpl += " " + movimento;
                    }

                    if (lugarY == yRb && lugarX == xRb)
                    {
                        //IRRIGAR
                        caminhoCmpl += " " + "I";

                    }
                }

                caminhoCmpl += " ]";
                Console.WriteLine("Caminho percorrido: " + caminhoCmpl + "\nOrientação final: " + orientRb);

            }
            catch (Exception erro)
            {
                Console.WriteLine("\nERRO: {0}", erro.Message);
                Console.WriteLine("Favor reiniciar a execução do código.");
            }

            static string directionIcon(string direcao)
                {
                    switch (direcao)
                    {
                        case "N":
                            return "^";
                        case "L":
                            return ">";
                        case "S":
                            return "v";
                        case "O":
                            return "<";
                        default:
                            return "?";
                    }
                }

            static void showCase(int plantaValorY, int plantaValorX, string posRb, string[] lugaresParaIrrigar, string orientIcon)
                {
                    Console.WriteLine("\n\n=================  Representação  =================\n\n" +
                        "lugaresParaIrrigar.lenght" + lugaresParaIrrigar.Length);

                    for (int i = plantaValorY - 1; i >= 0; i--)
                    {
                        for (int j = 0; j < plantaValorX; j++)
                        {
                            string posAtualConcat = j.ToString() + "," + i.ToString();
                            bool hasIrrigacao = false, hasRb = false;
                            if (posRb == posAtualConcat)
                            {
                                hasRb = true;
                            }
                            foreach (string lugar in lugaresParaIrrigar)
                            {
                                if (lugar == posAtualConcat)
                                {
                                    hasIrrigacao = true;
                                }
                            }

                            if (hasRb == true && hasIrrigacao == true)
                            {
                                Console.Write("| i" + orientIcon + " |");
                            }
                            else if (hasRb)
                            {
                                Console.Write("| " + orientIcon + " |");
                            }
                            else if (hasIrrigacao)
                            {
                                Console.Write("| i |");
                            }
                            else
                            {
                                Console.Write("| . |");
                            }
                        }
                        Console.WriteLine("");
                    }
                }
        }
    } 
}

