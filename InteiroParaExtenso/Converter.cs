using System.Linq;
using System.Collections.Generic;

namespace InteiroParaExtenso
{
    public class Converter
    {
        private Dictionary<int, string> numeroDicionario = new Dictionary<int, string>()
        {
            { 1, "um" },
            { 2 ,"dois" },
            { 3, "três" },
            { 4, "quatro" },
            { 5, "cinco" },
            { 6, "seis" },
            { 7, "sete" },
            { 8, "oito" },
            { 9, "nove" },
            { 10, "dez" },
            { 11, "onze" },
            { 12, "doze" },
            { 13, "treze" },
            { 14, "catorze" },
            { 15, "quinze" },
            { 16, "dezesseis" },
            { 17, "dezessete" },
            { 18, "dezoito" },
            { 19, "dezenove" },

            { 20, "vinte" },
            { 30, "trinta" },
            { 40, "quarenta" },
            { 50, "cinquenta" },
            { 60, "sessenta" },
            { 70, "setenta" },
            { 80, "oitenta" },
            { 90, "noventa" },

            { 100, "cem" },
            { 200, "duzentos"},
            { 300, "trezentos"},
            { 400, "quatrocentos"},
            { 500, "quinhentos"},
            { 600, "seiscentos"},
            { 700, "setecentos"},
            { 800, "oitocentos"},
            { 900, "novecentos"}
        };

        private const string sufixoMilhar = " mil";
        private const string sufixoMilhao = " milhões(ão)";

        private string BuscaStringCentena(int centena)
        {
            if (centena == 100)
            {
                return "cento";
            }

            return numeroDicionario[centena];
        }

        private string BuscaString(int unidade, int? dezena = null, int? centena = null)
        {
            if (centena == 0 && dezena == 0 && unidade == 0)
            {
                return string.Empty;
            }
            else if (dezena == null)
            {
                return numeroDicionario[unidade];
            }
            else if (centena == null || centena == 0)
            {
                if (numeroDicionario.ContainsKey((int)dezena + unidade))
                {
                    return numeroDicionario[(int)dezena + unidade];
                }

                return numeroDicionario[(int)dezena] + " e " + numeroDicionario[unidade];
            }
            else
            {
                if (numeroDicionario.ContainsKey((int)centena + (int)dezena + unidade))
                {
                    return numeroDicionario[(int)centena + (int)dezena + unidade];
                }
                else if (numeroDicionario.ContainsKey((int)dezena + unidade))
                {
                    return BuscaStringCentena((int)centena) + " e " + numeroDicionario[(int)dezena + unidade];
                }
                else if (dezena > 1)
                {
                    return BuscaStringCentena((int)centena) + " e " + numeroDicionario[(int)dezena] + " e " + numeroDicionario[unidade];
                }
                else
                {
                    return BuscaStringCentena((int)centena) + " e " + numeroDicionario[unidade];
                }
            }
        }

        public string InteiroParaExtenso(int numero)
        {
            if (numeroDicionario.ContainsKey(numero))
            {
                return numeroDicionario[numero];
            }

            var listaNumero = numero.ToString().Select(digito => int.Parse(digito.ToString()));
            var listaNumeroCount = listaNumero.Count();

            string numeroExtenso = "";

            if (listaNumeroCount == 2)
            {
                int dezena = listaNumero.ElementAt(0) * 10;
                int unidade = listaNumero.ElementAt(1);

                numeroExtenso = numeroDicionario[dezena] + " e " + numeroDicionario[unidade];
            }
            else if (listaNumeroCount == 3)
            {
                int centena = listaNumero.ElementAt(0) * 100;
                int dezena = listaNumero.ElementAt(1) * 10;
                int unidade = listaNumero.ElementAt(2);

                numeroExtenso = BuscaString(unidade, dezena, centena);

            }
            else if (listaNumeroCount == 4)
            {
                int milhar = listaNumero.ElementAt(0);
                int centena = listaNumero.ElementAt(1) * 100;
                int dezena = listaNumero.ElementAt(2) * 10;
                int unidade = listaNumero.ElementAt(3);

                numeroExtenso = BuscaString(milhar) + sufixoMilhar;

                var primeiraClasse = BuscaString(unidade, dezena, centena);

                if (!primeiraClasse.Equals(""))
                {
                    numeroExtenso += " e " + primeiraClasse;
                }

            }
            else if (listaNumeroCount == 5)
            {
                int dezenaMilhar = listaNumero.ElementAt(0) * 10;
                int unidadeMilhar = listaNumero.ElementAt(1);
                int centena = listaNumero.ElementAt(2) * 100;
                int dezena = listaNumero.ElementAt(3) * 10;
                int unidade = listaNumero.ElementAt(4);

                numeroExtenso = BuscaString(unidadeMilhar, dezenaMilhar) + sufixoMilhar;

                var primeiraClasse = BuscaString(unidade, dezena, centena);

                if (!primeiraClasse.Equals(""))
                {
                    numeroExtenso += " e " + primeiraClasse;
                }
            }
            else if (listaNumeroCount == 6)
            {
                int centenaMilhar = listaNumero.ElementAt(0) * 100;
                int dezenaMilhar = listaNumero.ElementAt(1) * 10;
                int unidadeMilhar = listaNumero.ElementAt(2);
                int centena = listaNumero.ElementAt(3) * 100;
                int dezena = listaNumero.ElementAt(4) * 10;
                int unidade = listaNumero.ElementAt(5);

                numeroExtenso = BuscaString(unidadeMilhar, dezenaMilhar, centenaMilhar) + sufixoMilhar;

                var primeiraClasse = BuscaString(unidade, dezena, centena);

                if (!primeiraClasse.Equals(""))
                {
                    numeroExtenso += " e " + primeiraClasse;
                }
            }
            else if (listaNumeroCount == 7)
            {
                int unidadeMilhao = listaNumero.ElementAt(0);
                int centenaMilhar = listaNumero.ElementAt(1) * 100;
                int dezenaMilhar = listaNumero.ElementAt(2) * 10;
                int unidadeMilhar = listaNumero.ElementAt(3);
                int centena = listaNumero.ElementAt(4) * 100;
                int dezena = listaNumero.ElementAt(5) * 10;
                int unidade = listaNumero.ElementAt(6);

                numeroExtenso = BuscaString(unidadeMilhao) + sufixoMilhao;

                var classeMilhar = BuscaString(unidadeMilhar, dezenaMilhar, centenaMilhar);
                var primeiraClasse = BuscaString(unidade, dezena, centena);

                if (!classeMilhar.Equals(""))
                {
                    numeroExtenso += " e " + classeMilhar + sufixoMilhar;
                }

                if (!primeiraClasse.Equals(""))
                {
                    numeroExtenso += " e " + primeiraClasse;
                }
            }
            else if (listaNumeroCount == 8)
            {
                int dezenaMilhao = listaNumero.ElementAt(0) * 10;
                int unidadeMilhao = listaNumero.ElementAt(1);
                int centenaMilhar = listaNumero.ElementAt(2) * 100;
                int dezenaMilhar = listaNumero.ElementAt(3) * 10;
                int unidadeMilhar = listaNumero.ElementAt(4);
                int centena = listaNumero.ElementAt(5) * 100;
                int dezena = listaNumero.ElementAt(6) * 10;
                int unidade = listaNumero.ElementAt(7);

                numeroExtenso = BuscaString(unidadeMilhao, dezenaMilhao) + sufixoMilhao;

                var classeMilhar = BuscaString(unidadeMilhar, dezenaMilhar, centenaMilhar);
                var primeiraClasse = BuscaString(unidade, dezena, centena);

                if (!classeMilhar.Equals(""))
                {
                    numeroExtenso += " e " + classeMilhar + sufixoMilhar;
                }

                if (!primeiraClasse.Equals(""))
                {
                    numeroExtenso += " e " + primeiraClasse;
                }
            }
            else if (listaNumeroCount == 9)
            {
                int centenaMilhao = listaNumero.ElementAt(0) * 100;
                int dezenaMilhao = listaNumero.ElementAt(1) * 10;
                int unidadeMilhao = listaNumero.ElementAt(2);
                int centenaMilhar = listaNumero.ElementAt(3) * 100;
                int dezenaMilhar = listaNumero.ElementAt(4) * 10;
                int unidadeMilhar = listaNumero.ElementAt(5);
                int centena = listaNumero.ElementAt(6) * 100;
                int dezena = listaNumero.ElementAt(7) * 10;
                int unidade = listaNumero.ElementAt(8);

                numeroExtenso = BuscaString(unidadeMilhao, dezenaMilhao, centenaMilhao) + sufixoMilhao;

                var classeMilhar = BuscaString(unidadeMilhar, dezenaMilhar, centenaMilhar);
                var primeiraClasse = BuscaString(unidade, dezena, centena);

                if (!classeMilhar.Equals(""))
                {
                    numeroExtenso += " e " + classeMilhar + sufixoMilhar;
                }

                if (!primeiraClasse.Equals(""))
                {
                    numeroExtenso += " e " + primeiraClasse;
                }
            }

            return numeroExtenso;
        }
    }
}
