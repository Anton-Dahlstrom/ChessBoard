using System.Net.Quic;

namespace ChessBoard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Anton Dahlström .net 24

            int size;
            Console.WriteLine("Hur stort bräde?");
            string input = Console.ReadLine();
            bool validated = int.TryParse(input, out size);
            while (!validated) 
            {
                Console.WriteLine("Skriv in ett heltal!");
                input = Console.ReadLine();
                validated = int.TryParse(input, out size);
            }             
            
            Console.WriteLine("Hur ska svarta rutor se ut?");
            string black = Console.ReadLine();
            Console.WriteLine("Hur ska vita rutor se ut?");
            string white = Console.ReadLine();

            string userPiece;
            do
            {
                Console.WriteLine("Hur ska pjäsen se ut?");
                userPiece = Console.ReadLine();

            } while (userPiece.Length != 1);

            validated = false;
            int userRow = 0;
            int userCol = 0;
            while (!validated) 
            {
                Console.WriteLine("Var ska pjäsen stå?");
                input = Console.ReadLine();
                if (input.Length != 2)
                {
                    continue;
                }
                userCol = (int)char.ToLower(input[0]);
                userCol -= 97;
                validated = int.TryParse(input[1].ToString(), out userRow);
                userRow -= 1;
                if (validated && 0 <= userCol && userCol < size && 0 <= userCol && userCol < size)
                {
                    break;
                }
                validated = false;
            }


            string[,] board = new string[size, size];
            for (int i=0; i < size; i++)
            {
                for (int j = 0; j < size; j++) 
                {
                    if (i == userRow && j == userCol)
                    {
                        board[i, j] = userPiece;
                        continue;
                    }
                    int cur = (i + j) % 2;
                    if (cur>0)
                    {
                        board[i, j] = white;
                    }
                    else
                    {
                        board[i, j] = black;
                    }
                }
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(board[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
