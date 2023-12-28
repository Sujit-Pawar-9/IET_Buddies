using BOL;
using MySql.Data.MySqlClient;
namespace Connected;

public class DBManager{

    public static string conString="server=localhost;port=3306;user=root; password=root;database=test";       
    public  static List<Product> Getallproducts(){
            List<Product> getallproducts=new List<Product>();
            MySqlConnection conn=new MySqlConnection();
            conn.ConnectionString=conString;
            string query = "SELECT * FROM Product";
            try
            {
                MySqlCommand cmd = new MySqlCommand(query,conn);
                // cmd.Connection = conn;
                conn.Open();        
                // cmd.CommandText=query;
                MySqlDataReader reader=cmd.ExecuteReader();
                while(reader.Read()){
                    // int id=2;
                    int id = int.Parse(reader["pid"].ToString());
                    string name = reader["pname"].ToString();
                    int qty = int.Parse(reader["qty"].ToString());
                    float price=float.Parse(reader["price"].ToString());
                     Product p=new Product(id,name,qty,price);
                    // {
                    //                       id = id,
                    //                       name = name,  
                    //                       qty=qty,        
                    //                      Price  = price                   
                    // };
                    getallproducts.Add(p);
                }
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
            }
            finally{
                    conn.Close();
            }

            return getallproducts;
    }
    public static bool ValidateUser(string username, string password)
    {
        MySqlConnection conn=new MySqlConnection();
        conn.ConnectionString=conString;
        conn.Open();
        string query = "SELECT *  FROM user where uname=@username and password=@password";
        try{MySqlCommand cmd = new MySqlCommand(query,conn);
        cmd.Parameters.AddWithValue("@username",username);
        cmd.Parameters.AddWithValue("@password",password);
        MySqlDataReader reader=cmd.ExecuteReader();
        if(reader.Read()){
            return true;
        }}catch(Exception e){
            Console.WriteLine(e.Message);
        }
        finally{
            conn.Close();
        }
    return false;
    }
}

