using MongoDB.Bson;
using MongoDB.Driver;
using SteamRandomizer.src.Services;
using SteamRandomizer.src.View;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace SteamRandomizer;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{

    public App()
    {
        
        string databaseName = "steam-randomizer";
        string connectionUri = ReadMongoDBConfig();
        if (!string.IsNullOrEmpty(connectionUri))
        {
            this.ConnectToMongoDB(connectionUri, databaseName);
        }
        
        
    }

    private string ReadMongoDBConfig()
    {
        try
        {
            string configPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"SteamRandomizer", "config.dat");
            string encrypted = File.ReadAllText(configPath);
            return CryptoHelper.Decrypt(encrypted);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Exception: " + ex.Message + " " + ex.StackTrace + " " + ex.Source);
        }
        return "";
        
    }

    private void ConnectToMongoDB(string uri, string databaseName)
    {
        var settings = MongoClientSettings.FromConnectionString(uri);
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);

        var client = new MongoClient(settings);

        var database = client.GetDatabase(databaseName);

        try
        {
            var result = database.RunCommand<BsonDocument>(new BsonDocument("ping", 1));
            Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Fehler beim Verbinden: " + ex.Message);
        }

    }





}

