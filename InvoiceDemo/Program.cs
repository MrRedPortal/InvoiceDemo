using InvoiceDemo;
using Microsoft.EntityFrameworkCore;

using System.Data;
using System.Text.Json;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AppDb");

builder.Services.AddDbContext<InvoiceDBContext>(x =>
    x.UseSqlServer(connectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

Main(null);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

    static void Main(string[] args)
    {
        string serverName = "35.197.174.125";
        string databaseName = "students";
        string username = "sqlserver";
        string password = "WYWM";

        string connectionString = $"Server={serverName};Database={databaseName};User Id={username};Password={password}; TrustServerCertificate=True;";
        
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                
                string sql = "SELECT * FROM Invoices";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Dictionary<string, object> row = new Dictionary<string, object>();
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        row.Add(column.ColumnName, dataRow[column]);
                    }
                    rows.Add(row);
                }

                string json = JsonSerializer.Serialize(rows);
                Console.WriteLine(json);
                
                Console.WriteLine("Connection successful!");
                
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }