using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IDeveloperService
    {
        public IQueryable<DeveloperModel> Query(); //READ
        public ServiceBase Create(Developer record); //CREATE
        public ServiceBase Update(Developer record); //UPDATE
        public ServiceBase Delete(int Id); //DELETE

        //4 Main Methods To Manage CRUD Operations in an interface, in a Service


    }

    public class DeveloperService : ServiceBase, IDeveloperService //(INTERFACE)
    {
        public DeveloperService(Db db) : base(db) //CONSTRUCTOR CHAINING
        {

        }
        public IQueryable<DeveloperModel> Query()
        {
            return _db.Developers.OrderBy(p => p.Name).Select(p => new DeveloperModel() { Record = p });
            //Öncelikle Developers Db Set'e Erişiyor, Sonra İsme Göre Sıralıyor, Sonra ise Sonuçları Teker Teker Record'a Atıyor.
        }

        public ServiceBase Create(Developer record)
        {
            if (_db.Developers.Any(p => p.Name.ToUpper() == record.Name.ToUpper().Trim()))
            //Recorddaki Name'lerin Herhangi Biri, Recorddaki Name ile Aynı ise
            {
                Error("Developer with the same name exists!");
            }
            record.Name = record.Name.Trim(); //record'daki Boşlukları Siler
            _db.Developers.Add(record);
            _db.SaveChanges(); //Değişiklikleri Database'e Commit Eder.
            return Success("Developer created successfully!");
        }

        public ServiceBase Update(Developer record)
        {

            if (_db.Developers.Any(p => p.Id != record.Id && p.Name.ToUpper() == record.Name.ToUpper().Trim()))
            //Veritabanında Aynı Adda (Şu An Update Ettiğimiz Id Dışındakiler Kontrol Ediliyor) Başka Bir Veri Var Mı Kontrolü
            {
                Error("Developer with the same name exists! You cannot update with this name!");
            }
            var entity = _db.Developers.SingleOrDefault(s => s.Id == record.Id);
            //SingleOrDefault methodunu kullanarak Veritabanından; Record Id'si ile Aynı Olan Entity'e Eriştik.
            if (entity == null)
            {
                //Record, Id ile Bulunamadı. Bu Id'de Veri Yok.
                Error("Developer couldn't be found!");
            }
            entity.Name = record.Name.Trim(); //Oluşturmuş Olduğumuz Entity'nin Name'i, Record'un Name'i ile Değiştirildi.
            _db.Update(entity); //Veritabanı, Ayno Id'deki, Fakat Güncellenmiş İsimdeki Bu Entity ile Güncellendi.
            _db.SaveChanges(); //Değişiklikleri Database'e Commit Edildi. 
            return Success("Developer updated successfully!");
        }

        public ServiceBase Delete(int id)
        {
            var entity = _db.Developers.Include(p => p.GameDevelopers).SingleOrDefault(p => p.Id == id);
            //*** Entity'deki Navigational Property'lere Erişmek için: Erişmek İstediğimiz Property'leri "Include" ile Belirtmeliyiz. ***
            //*** BUNA "EAGER LOADING" DENİR.
            //SingleOrDefault methodunu kullanarak Veritabanından; Record Id'si ile Aynı Olan Entity'e Eriştik.
            if (entity == null)
            {
                Error("Developer couldn't be found!");
            }
            if (entity.GameDevelopers.Count() > 0) // if(entity.GameDevelopers.Any())    de Alternatif olarak kullanılabilir.
            //Veritabanında, Developer Tablosunda Olup, İçerisinde Oyun Olan Developer Var ise
            {
                return Error("Developer couldn't be deleted! There are games related with the Developer!");
            }
            _db.Remove(entity);
            _db.SaveChanges();
            return Success("Developer deleted successfully!");

        }
    }
}
