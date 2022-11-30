using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoFenipo.Models;

namespace ProyectoFenipo.Controllers
{
    public class Informacion
    {
        ProyectoFenipoContainer db = new ProyectoFenipoContainer();
        public List<Competencia> Competencias { get; set; }

        public List<InscripcionAtletas> Atletas { get; set; }

        public List<InscripcionEquipo> Equipos { get; set; }

        public List<Intento> Intentos { get; set; }

        

        public List<InscripcionAtletas> ListaAtletas (int IdCompetencia)
        {
            Atletas = db.InscripcionAtletasSet.Where(x=> x.CompetenciaId == IdCompetencia).ToList();
            return Atletas; 
        }

        public List<InscripcionEquipo> ListaEquipos(int IdCompetencia)
        {
            Equipos = db.InscripcionEquipos.Where(x => x.CompetenciaId == IdCompetencia).ToList();
            return Equipos;
        }

        public List<Intento> ListaIntentosCompetencia(int idCompetencia)
        {
            Intentos = db.Intentos.Where(x => x.InscripcionAtletas.CompetenciaId == idCompetencia).ToList();
            return Intentos; 
        }

        //public List<IntentosOrdenados> OrdenarRecords()
        //{
        //    List<IntentosOrdenados> records = new List<IntentosOrdenados>();
        //    foreach (var cat in db.CategoriaPesos.Where(x => x.Genero == "Masculino"))
        //    {

        //        foreach (var atleta in db.Atletas)
        //        {
        //            foreach (var inscrip in db.InscripcionAtletasSet.Where(x => x.AtletaId == atleta.Id).ToList())
        //            {
        //                if (inscrip.CategoriaPesoId == cat.Id)
        //                {

        //                    records.add(db.Intentos.Where(x => x.InscripcionAtletasId == inscrip.AtletaId && x.InscripcionAtletas.CategoriaPesoId == cat.Id && x.StatusMovimiento.Status == "Valido" && x.Movimiento1.Nombre == "Sentadilla").Select(x => x.KilosMovimiento).ToString()))



        //                }
        //            }
        //        }  




        //    }
        //    return
        //}
        ////public List<Intento> MejoresSentadillas()
        ////{
        ////    List<Intento> MayoresDeCadaAtleta = new List<Intento>();


        ////    foreach (var atleta in db.Atletas)
        ////    {

        ////        foreach (var inscripcion in db.InscripcionAtletasSet.Where(x=>x.AtletaId == atleta.Id))
        ////        {

        ////            Intentos.Add(db.Intentos.Where(x => x.Movimiento1.Nombre == "Sentadilla" && x.StatusMovimiento.Status == "Valido" && x.InscripcionAtletasId == inscripcion.Id ).Max());

        ////        }

        ////    }

        ////    return MayoresDeCadaAtleta;   
        ////}
        //public List<Intento> MejoresPress()
        //{
        //    List<Intento> MayoresDeCadaAtleta = new List<Intento>();

        //    Intentos = db.Intentos.Where(x => x.Movimiento1.Nombre == "Press de Banca" && x.StatusMovimiento.Status == "Valido").ToList();
        //    foreach (var atleta in db.Atletas)
        //    {
        //        Intento intento = new Intento();
        //        foreach (var inscripcion in db.InscripcionAtletasSet.Where(x => x.AtletaId == atleta.Id))
        //        {
        //            foreach (var inten in Intentos.Where(x => x.InscripcionAtletasId == inscripcion.Id))
        //            {
        //                if (inten.KilosMovimiento < intento.KilosMovimiento)
        //                {
        //                    intento = inten;
        //                }
        //            }
        //        }
        //        MayoresDeCadaAtleta.Add(intento);
        //    }

        //    return MayoresDeCadaAtleta;
        //}
        //public List<Intento> MejoresMuerto()
        //{
        //    List<Intento> MayoresDeCadaAtleta = new List<Intento>();

        //    Intentos = db.Intentos.Where(x => x.Movimiento1.Nombre == "Peso Muerto" && x.StatusMovimiento.Status == "Valido").ToList();
        //    foreach (var atleta in db.Atletas)
        //    {
        //        Intento intento = new Intento();
        //        foreach (var inscripcion in db.InscripcionAtletasSet.Where(x => x.AtletaId == atleta.Id))
        //        {
        //            foreach (var inten in Intentos.Where(x => x.InscripcionAtletasId == inscripcion.Id))
        //            {
        //                if (inten.KilosMovimiento < intento.KilosMovimiento)
        //                {
        //                    intento = inten;
        //                }
        //            }
        //        }
        //        MayoresDeCadaAtleta.Add(intento);
        //    }

        //    return MayoresDeCadaAtleta;
        //}
    }

    public class IntentosOrdenados
    {
        public int Id { get; set; }


        public string Nombre { get; set; }

        public int Kilos { get; set;  }
    }

    public class CategoriasOrdenadas
    {

        public int id { get; set;  }
        public int Categoria { get; set;  }

        public string Sexo { get; set;  }
    }
}