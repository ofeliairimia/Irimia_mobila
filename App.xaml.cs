using Irimia_mobila.Data;
using System;
using System.IO;

namespace Irimia_mobila;

public partial class App : Application
{
    static ProgramareDatabase database;
    public static ProgramareDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new ProgramareDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Programare.db3"));
            }
            return database;
        }
    }

    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}