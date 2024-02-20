using System;
using MySqlConnector;
using System.Collections.Generic;

namespace Loja.Models;

public class Repository
{
    
    private const string DadosConexao = "Database = Loja; Data Source = localhost; User Id = root";

    public void Inserir(Property property)
    {
        MySqlConnection Conexao = new MySqlConnection(DadosConexao);
        Conexao.Open();

        string Query = "INSERT INTO Cadastros(Nome, Email, Rua, Numero, Bairro, Cidade, Cep, Estado, Pais, Pedido, Entrada, Total, Data, Registros) VALUES (@Nome, @Email, @Rua, @Numero, @Bairro, @Cidade, @Cep, @Estado, @Pais, @Pedido, @Entrada, @Total, @Data, @Registros);";
        MySqlCommand Comando = new MySqlCommand(Query,Conexao);

        Comando.Parameters.AddWithValue("@Nome",property.Nome);
        Comando.Parameters.AddWithValue("@Email",property.Email);
        Comando.Parameters.AddWithValue("@Rua",property.Rua);
        Comando.Parameters.AddWithValue("@Numero",property.Numero);
        Comando.Parameters.AddWithValue("@Bairro",property.Bairro);
        Comando.Parameters.AddWithValue("@Cidade",property.Cidade);
        Comando.Parameters.AddWithValue("@Cep",property.Cep);
        Comando.Parameters.AddWithValue("@Estado",property.Estado);
        Comando.Parameters.AddWithValue("@Pais",property.Pais);
        Comando.Parameters.AddWithValue("@Pedido",property.Pedido);
        Comando.Parameters.AddWithValue("@Entrada",property.Entrada);
        Comando.Parameters.AddWithValue("@Total",property.Total);
        Comando.Parameters.AddWithValue("@Data",property.Data);
        Comando.Parameters.AddWithValue("@Registros",property.Registros);

        Comando.ExecuteNonQuery();
        Conexao.Close();
    }
    //READ (LEITURA)
    public List<Property> Listar()
    {
        List<Property> Lista = new List<Property>();
        MySqlConnection Conexao = new MySqlConnection(DadosConexao);
        Conexao.Open();
        string Query = "SELECT * FROM Cadastros;";//SINTAXE PARA SELECIONAR A TABELA Property
        MySqlCommand Comando = new MySqlCommand(Query,Conexao);
        
        MySqlDataReader Reader = Comando.ExecuteReader();
        
        while(Reader.Read())
        {
            
            Property property = new Property();
            property.IdProperty = Reader.GetInt32("IdProperty");
        
            if(! Reader.IsDBNull(Reader.GetOrdinal("Nome")))
            {
                property.Nome = Reader.GetString("Nome");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Email")))
            {
                property.Email = Reader.GetString("Email");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Rua")))
            {
                property.Rua = Reader.GetString("Rua");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Numero")))
            {
                property.Numero = Reader.GetInt32("Numero");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Bairro")))
            {
                property.Bairro = Reader.GetString("Bairro");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Cidade")))
            {
                property.Cidade = Reader.GetString("Cidade");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Cep")))
            {
                property.Cep = Reader.GetInt32("Cep");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Estado")))
            {
                property.Estado = Reader.GetString("Estado");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Pais")))
            {
                property.Pais = Reader.GetString("Pais");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Pedido")))
            {
                property.Pedido = Reader.GetString("Pedido");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Entrada")))
            {
                property.Entrada = Reader.GetDouble("Entrada");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Total")))
            {
                property.Total = Reader.GetDouble("Total");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Data")))
            {
                property.Data = Reader.GetDateTime("Data");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Registros")))
            {
                property.Registros = Reader.GetString("Registros");
            }

            property.Restante = Reader.GetDouble("Total") - Reader.GetDouble("Entrada"); 

            Lista.Add(property);
        }
        
        Lista.Reverse();
        Conexao.Close();
        return Lista;
    }
    //UPDATE (EDITAR) 
    public void Editar(Property property)
    {
        MySqlConnection Conexao = new MySqlConnection(DadosConexao);
        Conexao.Open();
        string Query = "UPDATE Cadastros SET Nome = @Nome, Email = @Email, Rua = @Rua, Numero = @Numero, Bairro = @Bairro, Cidade = @Cidade, Cep = @Cep, Estado = @Estado, Pais = @Pais, Pedido = @Pedido, Entrada = @Entrada, Total = @Total, Data = @Data, Registros = @Registros WHERE IdProperty = @IdProperty";
        MySqlCommand Comando = new MySqlCommand(Query,Conexao);
        
        Comando.Parameters.AddWithValue("@IdProperty",property.IdProperty);


        Comando.Parameters.AddWithValue("@Nome",property.Nome);
        Comando.Parameters.AddWithValue("@Email",property.Email);
        Comando.Parameters.AddWithValue("@Rua",property.Rua);
        Comando.Parameters.AddWithValue("@Numero",property.Numero);
        Comando.Parameters.AddWithValue("@Bairro",property.Bairro);
        Comando.Parameters.AddWithValue("@Cidade",property.Cidade);
        Comando.Parameters.AddWithValue("@Cep",property.Cep);
        Comando.Parameters.AddWithValue("@Estado",property.Estado);
        Comando.Parameters.AddWithValue("@Pais",property.Pais);
        Comando.Parameters.AddWithValue("@Pedido",property.Pedido);
        Comando.Parameters.AddWithValue("@Entrada",property.Entrada);
        Comando.Parameters.AddWithValue("@Total",property.Total);
        Comando.Parameters.AddWithValue("@Data",property.Data.ToString("yyyy-MM-dd HH:mm"));
        Comando.Parameters.AddWithValue("@Registros",property.Registros);

        Comando.ExecuteNonQuery();
        Conexao.Close();
    }
    //BUSCA POR ID COM INFORMAÇÕES
    public Property BuscaPorId(int Id)
    {
        MySqlConnection Conexao = new MySqlConnection(DadosConexao);
        Conexao.Open();
        string Query = "SELECT * FROM Cadastros WHERE IdProperty = @IdProperty";
        MySqlCommand Comando = new MySqlCommand(Query,Conexao);
        Comando.Parameters.AddWithValue("@IdProperty",Id);
        MySqlDataReader Reader = Comando.ExecuteReader();
        Property property = new Property();
        while(Reader.Read())
        {
            property.IdProperty = Reader.GetInt32("IdProperty");

            if(! Reader.IsDBNull(Reader.GetOrdinal("Nome")))
            {
                property.Nome = Reader.GetString("Nome");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Email")))
            {
                property.Email = Reader.GetString("Email");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Rua")))
            {
                property.Rua = Reader.GetString("Rua");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Numero")))
            {
                property.Numero = Reader.GetInt32("Numero");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Bairro")))
            {
                property.Bairro = Reader.GetString("Bairro");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Cidade")))
            {
                property.Cidade = Reader.GetString("Cidade");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Cep")))
            {
                property.Cep = Reader.GetInt32("Cep");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Estado")))
            {
                property.Estado = Reader.GetString("Estado");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Pais")))
            {
                property.Pais = Reader.GetString("Pais");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Pedido")))
            {
                property.Pedido = Reader.GetString("Pedido");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Entrada")))
            {
                property.Entrada = Reader.GetDouble("Entrada");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Total")))
            {
                property.Total = Reader.GetDouble("Total");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Data")))
            {
                property.Data = Reader.GetDateTime("Data");
            }
            if(! Reader.IsDBNull(Reader.GetOrdinal("Registros")))
            {
                property.Registros = Reader.GetString("Registros");
            }
            
        }
        Conexao.Close();
        return property;
    }
    //DELETE (DELETAR)
    public void Deletar(int Id)
    {
        MySqlConnection Conexao = new MySqlConnection(DadosConexao);
        Conexao.Open();
        string Query = "DELETE FROM Cadastros WHERE IdProperty = @IdProperty";
        MySqlCommand Comando = new MySqlCommand(Query,Conexao);
        Comando.Parameters.AddWithValue("@IdProperty",Id);
        Comando.ExecuteNonQuery();
        Conexao.Close();
    }
}
