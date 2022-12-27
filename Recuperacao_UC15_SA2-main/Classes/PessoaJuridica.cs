namespace Recuperacao_UC15_SA2.Classes
{
    public class PessoaJuridica : Pessoa
    {
        public string? cnpj { get; set; }



    //xx.xxx.xxx/0001-xx
    public bool ValidarCnpj (string cnpj)
    {
        if (cnpj.Length == 18)
        {
            if (cnpj.Substring(11, 4) == "0001")
            {
                return true;
            }
        }

        return false;
    }

    public void Inserir(PessoaJuridica pj)
    {
        using (StreamWriter sw = new StreamWriter($"{pj.Nome}.txt"))
        {
            sw.WriteLine($"{pj.Nome},{pj.Rendimento},{pj.cnpj}");
        }
    }

    //"[Nome,Rendimento,CNPJ]" => 3 posições & [0,1,2]
    public PessoaJuridica Ler(string nomeArquivo)
    {
        PessoaJuridica pj = new PessoaJuridica();

        using (StreamReader sr = new StreamReader($"{nomeArquivo}.txt"))
        {
            string[] atributos = sr.ReadLine()!.Split(",");

            pj.Nome = atributos[0];
            pj.Rendimento = float.Parse(atributos[1]);
            pj.cnpj = atributos[2];
        }

        return pj;
    }

    }
}
