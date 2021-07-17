using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Database_model.DB
{
    class db_Uitl
    {
        public static SqlConnection Conn { get; set; }
        public static bool Connect()
        {
            //Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = "D:\Document\MTA\Kì 1 năm 4\Git\Ky1Nam4\ELearningWebSite\C#\WebsiteElearning\Database_model\DB\db_ELearning.mdf"; Integrated Security = True
            string conString = "Data Source=DESKTOP-DE7MHF6;Initial Catalog=db_Elearning;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            Conn = new SqlConnection(conString);// Tạo một kết nối
            if(Conn.State != ConnectionState.Open)
            {
                Conn.Open();//Mở kết nối
            }    

            if (Conn.State == ConnectionState.Open)//Kiểm tra trạng thái kết nối
            {
                Console.WriteLine("Kết nối thành công!");
                return true;
            }
            else
            {
                Console.WriteLine("Kết nối không thành công!");
                return false;
            }

        }
        public static bool Close()
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool isLive()
        {
            if (Conn != null ){
                return Conn.State == ConnectionState.Open;
            }
            return false;
        }
    }
}
