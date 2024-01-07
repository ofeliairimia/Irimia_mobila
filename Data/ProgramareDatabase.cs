using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Irimia_mobila.Models;

namespace Irimia_mobila.Data
{
    public class ProgramareDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ProgramareDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Programare>().Wait();
            _database.CreateTableAsync<Serviciu>().Wait();
            _database.CreateTableAsync<ListaServiciu>().Wait();
            _database.CreateTableAsync<Clinica>().Wait();
        }
        public Task<int> SaveServiciuAsync(Serviciu serviciu)
        {
            if (serviciu.ID != 0)
            {
                return _database.UpdateAsync(serviciu);
            }
            else
            {
                return _database.InsertAsync(serviciu);
            }
        }
        public Task<int> DeleteServiciuAsync(Serviciu serviciu)
        {
            return _database.DeleteAsync(serviciu);
        }
        public Task<List<Serviciu>> GetServiciiAsync()
        {
            return _database.Table<Serviciu>().ToListAsync();
        }
        public Task<int> DeleteListaServiciuAsync(ListaServiciu listas)
        {
            return _database.DeleteAsync(listas);
        }
        public Task<List<ListaServiciu>> GetListaServicii()
        {
            return _database.QueryAsync<ListaServiciu>("select * from ListaServiciu");
        }
        public Task<List<Programare>> GetProgramariAsync()
        {
            return _database.Table<Programare>().ToListAsync();
        }
        public Task<Programare> GetProgramareAsync(int id)
        {
            return _database.Table<Programare>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveProgramareAsync(Programare plist)
        {
            if (plist.ID != 0)
            {
                return _database.UpdateAsync(plist);
            }
            else
            {
                return _database.InsertAsync(plist);
            }
        }
        public Task<int> DeleteProgramareAsync(Programare plist)
        {
            return _database.DeleteAsync(plist);
        }
        public Task<int> SaveListaServiciuAsync(ListaServiciu listas)
        {
            if (listas.ID != 0)
            {
                return _database.UpdateAsync(listas);
            }
            else
            {
                return _database.InsertAsync(listas);
            }
        }
        public Task<List<Serviciu>> GetListaServiciiAsync(int programareid)
        {
            return _database.QueryAsync<Serviciu>(
            "select S.ID, S.Descriere from Serviciu S"
            + " inner join ListaServiciu LS"
            + " on S.ID = LS.ServiciuID where LS.ProgramareID = ?",
            programareid);
        }
        public Task<List<Clinica>> GetCliniciAsync()
        {
            return _database.Table<Clinica>().ToListAsync();
        }
        public Task<int> SaveClinicaAsync(Clinica clinica)
        {
            if (clinica.ID != 0)
            {
                return _database.UpdateAsync(clinica);
            }
            else
            {
                return _database.InsertAsync(clinica);
            }
        }

        public Task<int> DeleteClinicaAsync(Clinica clinica)
        {
            return _database.DeleteAsync(clinica);
        }
    }
}
