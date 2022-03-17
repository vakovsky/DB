            System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection();
            sqlConnection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                        AttachDbFilename=C:\Users\Student\Documents\data.mdf;
                        Integrated Security=True;Connect Timeout=30";
            sqlConnection.Open();

            System.Data.SqlClient.SqlCommand sqlCommand = new System.Data.SqlClient.SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM Users";

            System.Data.SqlClient.SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            //
            while (sqlDataReader.Read())
            {
                dataGridView1.Rows.Add(sqlDataReader.GetInt32(0),
                    sqlDataReader.GetString(1), sqlDataReader.GetString(2), sqlDataReader.GetString(3));
            }

            //
            /*DataTable dt = new DataTable();
            dt.Load(sqlDataReader);

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dt;

            dataGridView1.DataSource = bindingSource;

            textBox1.DataBindings.Add(new Binding("Text", bindingSource, "Name"));*/
            
/*
CREATE TABLE [dbo].[Users] (
[Id]    INT         IDENTITY (1, 1) NOT NULL,
[Name]  NCHAR (50)  NOT NULL,
[Email] NCHAR (50)  NOT NULL,
[Addr]  NCHAR (100) NOT NULL,
PRIMARY KEY CLUSTERED ([Id] ASC)
);
*/
