using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Proyecto1.Palindromo
{
    public class EsPalindromo
    {
        //el siguiente metodo determina si una palabra es palindroma o no y devuelve true si lo es, o false si no
        //recorre el parametro brindado comparando la primera letra con la ultima, cumpliendo asi la definicion de palindromo
        private static bool esPalindromo(string palabra)
        {
            int i;
            for (i = 0; i < (palabra.Length) / 2; i++)
            {
                if (!palabra[i].Equals(palabra[palabra.Length - i - 1]))
                {
                    return false;
                }
            }
            return true;
        }

        //el siguiente metodo separa el parametro brindado en palabras las cuales las almacena en la variable "palabras"
        //por fines de este ejercicio se a agreagdo el simbolo "$" a la manera de separar las palabras
        public static List <string> encontrarPalindromos(string entrada)
        {
            string[] palabras = entrada.Split(' ', '$');//agregar mas simbolos que delimitaran un token para ser procesado por el metodo EsPalindromo
            List<string> palindromasEncontradas = new List<string>();
            int i;
            for (i = 0; i < palabras.Length; i++)
            {
                if (palabras[i].Length > 1 && esPalindromo(palabras[i])==true)
                {
                    palindromasEncontradas.Add(palabras[i]);//si encuentra un palindromo lo a;ade a la lista de palidnromos
                }
            }

            return palindromasEncontradas;//lista de palindromos completa
        }

    }

}
